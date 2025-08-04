
namespace GMAO
{
    public class UserSession
    {
        private static UserSession _instance;
        public static UserSession CurrentUser
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Statut { get; set; }

        private UserSession() { }

        public void SetUser(int id, string login, string statut)
        {
            Id = id;
            Login = login;
            Statut = statut;
        }

        public void Clear()
        {
            Id = 0;
            Login = null;
            Statut = null;
        }
    }
}
