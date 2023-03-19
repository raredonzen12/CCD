using DataAcessLibrary.Models;

namespace CCD.Authentication
{
    public class UserAccountService
    {
        private List<UserModel> _users;

        public UserAccountService()
        {
            _users = new List<UserModel>
            {
                new UserModel { LoginName = "admin", Password = "admin", Role = "Administrator" },
                new UserModel { LoginName = "user", Password = "user", Role = "User" }
            };
            
        }

        public UserModel? GetByLoginName(string loginName)
        {
            return _users.FirstOrDefault(x => x.LoginName == loginName);
        }
    }
}
