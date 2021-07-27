using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.ValueObjects;

namespace Payment.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarSubscription()
        {
            var name = new Name("Teste","teste");
            foreach(var not in name.Notifications){
                //not.Message;
                //not.Key;
            }
            //var subscription = new Subscription(null);
            //var student = new Student("Clayton","Almeida","123456789","claytonguimaraes@gmail.com");
            //student.AddSubscription(subscription);

        }
    }
}

