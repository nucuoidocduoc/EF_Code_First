using Contracts;
using Entities.Context;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _applicationContext;
        private IStudentRepository _student;
        private ITeacherRepository _teacher;
        private ISubjectRepository _subject;

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IStudentRepository Student => _student ??= new StudentRepository(_applicationContext);

        public ITeacherRepository Teacher => _teacher ??= new TeacherRepository(_applicationContext);

        public ISubjectRepository Subject => _subject ??= new SubjectRepository(_applicationContext);

        public ApplicationContext Context => _applicationContext;

        public void SaveChanges()
        {
            _applicationContext.SaveChanges();
        }
    }
}