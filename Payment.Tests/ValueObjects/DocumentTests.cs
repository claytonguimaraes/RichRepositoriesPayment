using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enums;
using Payment.Domain.ValueObjects;

namespace Payment.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShoulReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        public void ShoulReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("11111111111111", EDocumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ShoulReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("11111111111")]
        [DataRow("22222222222")]
        [DataRow("33333333333")]
        public void ShoulReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf,EDocumentType.CPF);
            Assert.IsTrue(doc.IsValid);
        }
        
    }
}

