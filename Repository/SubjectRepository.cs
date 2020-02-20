using Contracts;
using Entities.Context;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}