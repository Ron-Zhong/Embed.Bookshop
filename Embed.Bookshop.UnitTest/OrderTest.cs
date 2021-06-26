using NUnit.Framework;
using Embed.Bookshop.Repos;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Embed.Bookshop.Shared.ApiClients;

namespace Embed.Bookshop.UnitTest
{
    public class Tests
    {
        BooshopApiClient ApiClient;

        [SetUp]
        public void Setup()
        {
            ApiClient = new();
        }

        /// <summary>
        /// Book B (8954884915612)
        /// BookStore (10e340a7-36ac-4a7d-d795-08d938603709)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task NewOrderTest()
        {
            //1. Arrange
            var isdn = "8954884915612";
            var bookstoreId = new Guid("10e340a7-36ac-4a7d-d795-08d938603709");
            var email = "ron.zhong@gmail.com";

            //2. Act
            var statusCode = await ApiClient.PlaceOrderAsync(isdn, bookstoreId, email);

            //3. Assert
            Assert.AreEqual(statusCode, StatusCodes.Status201Created);
        }

        /// <summary>
        /// Invalid ISDN "xxx"
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task InvalidBookIsdnTest()
        {
            //1. Arrange
            var isdn = "xxx";
            var bookstoreId = new Guid("10e340a7-36ac-4a7d-d795-08d938603709");
            var email = "ron.zhong@gmail.com";

            //2. Act
            var statusCode = await ApiClient.PlaceOrderAsync(isdn, bookstoreId, email);

            //3. Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Book ISDN: 4882978795968 (out of stock)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task UnavailableBookTest()
        {
            //1. Arrange
            var isdn = "4882978795968";
            var bookstoreId = new Guid("10e340a7-36ac-4a7d-d795-08d938603709");
            var email = "ron.zhong@gmail.com";

            //2. Act
            var statusCode = await ApiClient.PlaceOrderAsync(isdn, bookstoreId, email);

            //3. Assert
            Assert.AreEqual(statusCode, StatusCodes.Status400BadRequest);
        }
    }
}