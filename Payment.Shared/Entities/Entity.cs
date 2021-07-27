using System;
using Flunt.Notifications;

namespace Payment.Shared.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; private set; }

        
    }
}