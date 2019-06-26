namespace PAYNLFormsApp.Objects
{
    public class AppSettings
    {
        public string ApiToken { get; set; }
        public string ServiceId { get; set; }
        public string ApplicationJsonContentType { get; set; }
        public string WWWUrlContentType { get; set; }
        public string BaseAddress { get; set; }
        public bool UseProxy { get; set; }
        public string ProxyAddress { get; set; }
    }
}
