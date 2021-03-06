﻿using Entities.Context;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IStudentRepository Student { get; }
        ITeacherRepository Teacher { get; }
        ISubjectRepository Subject { get; }

        ApplicationContext Context { get; }

        void SaveChanges();
    }
}