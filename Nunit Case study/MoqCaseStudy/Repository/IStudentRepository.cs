using MoqCaseStudy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqCaseStudy.Repository
{
    public interface IStudentRepository
    {

        List<Student> GetAll();

        Student GetByRollNo(int rollNo);

        Student GetByName(string anme);

        void Add(Student student);

        void Update(Student student);

        void Delete(int rollNo);
    }
}
