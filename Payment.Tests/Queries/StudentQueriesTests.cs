using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.Queries;
using Payment.Domain.ValueObjects;

namespace Payment.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;
        
        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for(int i=0; i<10;i++){
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111"+i.ToString(),EDocumentType.CPF),
                    new Email(i.ToString() + "@gmail.com"),
                    new Address("Rua",i.ToString(),"Bairro","City","State","Country","Zip")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists(){
            var exp = StudentQueries.GetStudentInfo("21111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }
    }
}