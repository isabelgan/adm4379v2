namespace WMN.Models
{
    public class WMNDatabaseSettings : IWMNDatabaseSettings
    {
        public string EventRegistrationCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWMNDatabaseSettings
    {
        string EventRegistrationCollectionName { get; set; }
        string ContactCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
