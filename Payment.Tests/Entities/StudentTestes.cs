using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;

namespace Payment.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarSubscription()
        {
            var subscription = new Subscription(null);
            var student = new Student("Clayton","Almeida","123456789","claytonguimaraes@gmail.com");
            student.AddSubscription(subscription);

        }
    }
}

