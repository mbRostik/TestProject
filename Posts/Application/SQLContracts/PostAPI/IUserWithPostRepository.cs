﻿using Domain.PostAPI_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SQLContracts.PostAPI
{
    public interface IUserWithPostRepository : IGenericRepository<UserWithPost>
    {
    }
}