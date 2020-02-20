using Contracts;
using Entities.Context;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}