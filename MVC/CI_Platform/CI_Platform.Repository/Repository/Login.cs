using CI_Platform.Entities.DataModels;
using CI_Platform.Entities.ViewModels;
using CI_Platform.Repository.Repository.Interface;


namespace CI_Platform.Repository.Repository
{
    public class Login:ILogin
    {
        private readonly CIDbContext _objdb;

        public Login(CIDbContext objdb)
        {
            _objdb = objdb;
        }
        public IEnumerable<User> GetUsers()
        {
            return _objdb.Users.ToList();
        }
        public int validateUser(LoginViewModel objlogin)
        {
            var user = _objdb.Users.Where(a => a.Email.Equals(objlogin.Email)).FirstOrDefault();
            if (user != null)
            {

                var obj = _objdb.Users.Where(a => a.Email.Equals(objlogin.Email) && a.Password.Equals(objlogin.Password)).FirstOrDefault();
                if (obj != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                
            }
            else
            {
                return 0;
            }
        }
    }
}
