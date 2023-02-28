﻿using CI_Platform.Entities.DataModels;
using CI_Platform.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Repository.Interface
{
   public interface ILogin
    {
        public IEnumerable<User> GetUsers();
        public int validateUser(LoginViewModel objlogin);
    }
}
