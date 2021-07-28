using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.ValueObjects;

namespace Payment.Tests
{
    [TestClass]
    public class StudentTests
    {
        private Document _document;
        private Address _address;
        private Name _name;
        private Email _email;
        private Student _student;
        private Subscription _subscription;

        public StudentTests()
        {
            _document = new Document("12345678901",EDocumentType.CPF);
            _address = new Address("Rua 1","123","DownTown","Gothan","NY","USA","334455");
            _name = new Name("Bruce","Wayne");
            _email = new Email("batman@dc.com");
            _student = new Student(_name,_document,_email,_address);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("123456",DateTime.Now,DateTime.Now.AddDays(7),10,10,_address,_document,"Wayne Corp",_email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("123456",DateTime.Now,DateTime.Now.AddDays(7),10,10,_address,_document,"Wayne Corp",_email);
            _subscription.AddPayment(payment);
            
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.IsValid);
        }

    }
}

