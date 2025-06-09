using NUnit;
using NUnit.Compatibility;
using NUnit.Framework;
using MoqCaseStudy.Business_Logic;
using MoqCaseStudy.Domain;
using MoqCaseStudy.Repository;
using System.Collections.Generic;
using Xunit;

namespace MoqCaseStudy.StudentTest
{
    public class StudentServiceTest
    {

        private readonly StudentService _service;

        public StudentServiceTest()
        {
            var repo = new IMemoryStudentRepository();
            _service = new StudentService(repo);
        }

        [Fact]
        public void AddStudent_ShouldAddSuccessfully()
        {
            var student = new Student { RollNo = 1, Name = "John", Email = "john@example.com" };
            _service.AddStudent(student);
            var result = _service.GetStudentByRollNo(1);
            Assert.Equals("John", result.Name);
        }

        [Fact]
        public void UpdateStudent_ShouldUpdateSuccessfully()
        {
            var student = new Student { RollNo = 2, Name = "Alice", Email = "alice@example.com" };
            _service.AddStudent(student);

            student.Name = "Alice Updated";
            _service.UpdateStudent(student);

            var updated = _service.GetStudentByRollNo(2);
            Assert.Equals("Alice Updated", updated.Name);
        }

        [Fact]
        public void DeleteStudent_ShouldDeleteSuccessfully()
        {
            var student = new Student { RollNo = 3, Name = "Bob", Email = "bob@example.com" };
            _service.AddStudent(student);

            _service.DeleteStudent(3);

            var result = _service.GetStudentByRollNo(3);
            
        }

        [Fact]
        public void GetAllStudents_ShouldReturnAll()
        {
            _service.AddStudent(new Student { RollNo = 4, Name = "A", Email = "a@example.com" });
            _service.AddStudent(new Student { RollNo = 5, Name = "B", Email = "b@example.com" });

            var result = _service.GetAllStudents();
            Assert.Equals(2, result.Count);
        }

    }
}
