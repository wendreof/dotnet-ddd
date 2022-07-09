namespace Api.Domain.Models
{
    public static class Settings
    {
        public static string ConnectionString { get; set; }
        public static string Migration { get; set; }
        public static string Issuer { get; set; }
        public static string Audience { get; set; }
        public static string Seconds { get; set; }

    }
}
