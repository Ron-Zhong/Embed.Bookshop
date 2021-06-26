namespace Embed.Bookshop
{
    public static class Extension
    {
        public static bool IsValidEmail(this string text)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(text);
                return addr.Address == text;
            }
            catch
            {
                return false;
            }
        }
    }
}
