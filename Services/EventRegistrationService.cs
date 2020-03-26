using WMN.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WMN.Services
{
    public class EventRegistrationService
    {
        private readonly IMongoCollection<EventRegistration> _eventRegistrations;

        public EventRegistrationService(IWMNDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _eventRegistrations = database.GetCollection<EventRegistration>(settings.EventRegistrationCollectionName);
        }

        public List<EventRegistration> Get() =>
            _eventRegistrations.Find(eventRegistration => true).ToList();

        public EventRegistration Get(string id) =>
            _eventRegistrations.Find<EventRegistration>(eventRegistration => eventRegistration.Id == id).FirstOrDefault();

        public EventRegistration Create(EventRegistration eventRegistration)
        {
            _eventRegistrations.InsertOne(eventRegistration);
            return eventRegistration;
        }

        public void Update(string id, EventRegistration eventRegistrationIn) =>
            _eventRegistrations.ReplaceOne(contact => contact.Id == id, eventRegistrationIn);

        public void Remove(EventRegistration eventRegistrationIn) =>
            _eventRegistrations.DeleteOne(eventRegistration => eventRegistration.Id == eventRegistrationIn.Id);

        public void Remove(string id) =>
            _eventRegistrations.DeleteOne(eventRegistration => eventRegistration.Id == id);
    }
}
