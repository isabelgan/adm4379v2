﻿using WMN.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WMN.Services
{
    public class ContactService
    {
        private readonly IMongoCollection<Contact> _contacts;

        public ContactService(IWMNDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _contacts = database.GetCollection<Contact>(settings.ContactCollectionName);
        }

        public List<Contact> Get() =>
            _contacts.Find(contact => true).ToList();

        public Contact Get(string id) =>
            _contacts.Find<Contact>(contact => contact.Id == id).FirstOrDefault();

        public Contact Create(Contact contact)
        {
            _contacts.InsertOne(contact);
            return contact;
        }

        public void Update(string id, Contact contactIn) =>
            _contacts.ReplaceOne(contact => contact.Id == id, contactIn);

        public void Remove(Contact contactIn) =>
            _contacts.DeleteOne(contact => contact.Id == contactIn.Id);

        public void Remove(string id) =>
            _contacts.DeleteOne(contact => contact.Id == id);
    }
}