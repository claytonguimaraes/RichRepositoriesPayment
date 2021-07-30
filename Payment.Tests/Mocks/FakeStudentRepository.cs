using Payment.Domain.Entities;
using Payment.Domain.Repositories;

namespace Payment.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if(document == "77777777777")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email.Equals("clayton@gmail.com"))
                return true;

            return false;
        }
    }
}