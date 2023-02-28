using CI_Platform.Entities.DataModels;
using CI_Platform.Entities.ViewModels;
using CI_Platform.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Repository
{
    public class UserInterface:IUserInterface
    {
        private readonly CIDbContext _objdb;

        public UserInterface(CIDbContext objdb)
        {
            _objdb = objdb;
        }
        public bool AddUser(RegistrationViewModel objuser)
        {
           var userexsists= _objdb.Users.Where(a => a.Email.Equals(objuser.Email)).FirstOrDefault();
            if (userexsists == null)
            {
                var user = new User()
                {
                    FirstName = objuser.FirstName,
                    LastName = objuser.LastName,
                    PhoneNumber = objuser.PhoneNumber,
                    Email = objuser.Email,
                    Password = objuser.Password,

                };
                _objdb.Users.Add(user);
                _objdb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValideUserEmail(ForgotPasswordViewModel objFpvm)
        {
            var userexsists = _objdb.Users.Where(a => a.Email.Equals(objFpvm.Email)).FirstOrDefault();
            if (userexsists != null)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(ResetPAsswordViewModel objresetuser)
        {
            var userexsists = _objdb.Users.Where(a => a.Email.Equals(objresetuser.Email)).FirstOrDefault();
            if (userexsists != null)
            {
                var user = new User()
                {
                    Email=objresetuser.Email,
                    Password = objresetuser.Password,

                };
                _objdb.Users.Update(user);
                _objdb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
