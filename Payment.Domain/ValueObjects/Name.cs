using Flunt.Notifications;
using Flunt.Validations;
using Payment.Shared.ValueObjects;

namespace Payment.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(FirstName,3,"Name.FirstName","Nome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(FirstName,3,"Name.FirstName","Sobrenome deve conter pelo menos 3 caracteres")
                .IsLowerThan(FirstName,40,"Name.FirstName","Nome deve conter até 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
    }
}