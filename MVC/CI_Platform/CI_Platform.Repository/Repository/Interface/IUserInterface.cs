using CI_Platform.Entities.DataModels;
using CI_Platform.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Repository.Interface
{
    public  interface IUserInterface
    {
        public bool AddUser(RegistrationViewModel objuservm);

        public bool ValideUserEmail(ForgotPasswordViewModel objFpvm, string token);

        public bool ResetPassword(string email, string token);

        public bool updatePassword(ResetPasswordViewModel objreset);
    }
}
