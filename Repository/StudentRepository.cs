using Contracts;
using Entities.Context;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}