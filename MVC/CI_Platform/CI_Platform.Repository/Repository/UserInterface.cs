using CI_Platform.Entities.DataModels;
using CI_Platform.Entities.ViewModels;
using CI_Platform.Repository.Repository.Interface;

namespace CI_Platform.Repository.Repository
{
    public class UserInterface : IUserInterface
    {
        private readonly CIDbContext _objdb;

        public UserInterface(CIDbContext objdb)
        {
            _objdb = objdb;
        }
        public bool AddUser(RegistrationViewModel objuser)
        {
            var userexsists = _objdb.Users.Where(a => a.Email.Equals(objuser.Email)).FirstOrDefault();
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
        public bool ValideUserEmail(ForgotPasswordViewModel objFpvm, string token)
        {
            var userexsists = _objdb.Users.Where(a => a.Email.Equals(objFpvm.Email)).FirstOrDefault();
            if (userexsists != null)
            {
                // Store the token in the password resets table with the user's email
                var passwordReset_ = new PasswordReset()
                {
                    Email = objFpvm.Email,
                    Token = token
                };
                _objdb.PasswordResets.Add(passwordReset_);
                _objdb.SaveChanges();


                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(string email, string token)
        {
            var userexsists = _objdb.PasswordResets.Where(a => a.Email.Equals(email) && a.Token.Equals(token)).FirstOrDefault();

            if (userexsists == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool updatePassword(ResetPasswordViewModel objreset)
        {
            var userexsists = _objdb.Users.Where(a => a.Email.Equals(objreset.Email)).FirstOrDefault();
            if (userexsists == null)
            {
                return false;
            }
            else
            {
                userexsists.Password = objreset.Password;
                _objdb.Users.Update(userexsists);
                _objdb.SaveChanges();
                return true;
            }
        }


    }
}