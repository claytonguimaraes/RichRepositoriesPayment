using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using Payment.Domain.Enums;
using Payment.Domain.Handlers;
using Payment.Tests.Mocks;

namespace Payment.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists(){
            
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            
            command.FirstName="Bruce";
            command.LastName="Wayne";
            command.Document="77777777777";
            command.Email="clayton1@gmail.com";
            command.BarCode="123456789012";
            command.BoletoNumber="123456";
            command.PaymentNumber="125465";
            command.PaidDate=DateTime.Now;
            command.ExpireDate=DateTime.Now.AddMonths(1);
            command.Total=60;
            command.TotalPaid=60;
            command.Payer="Clayton";
            command.PayerDocument="77777777777";
            command.PayerDocumentType=EDocumentType.CPF;
            command.PayerEmail="teste@gmail.com";
            command.Street="Rua 1";
            command.Number="77";
            command.Neighborhood="Bom Pastor";
            command.City="Divi";
            command.State="MG";
            command.Country="Brasil";
            command.ZipCode="35500000";

            handler.Handle(command);
            Assert.AreEqual(false,handler.IsValid);
        }
    }
}