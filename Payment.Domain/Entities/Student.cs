using System.Collections.Generic;
using System.Linq;
using Payment.Domain.ValueObjects;
using Payment.Shared.Entities;

namespace Payment.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get{return _subscriptions.ToArray();} }

        public void AddSubscription(Subscription subscription){
            
            var hasSubscriptionActive = false;
            foreach(var sub in _subscriptions){
                //sub.Inactivate();
                if(sub.Active)
                    hasSubscriptionActive = true;
            }

            if(hasSubscriptionActive)
                AddNotification("Student.Subscription","Você já tem uma assinatura ativa");
            else
                _subscriptions.Add(subscription);
        }
    }
}