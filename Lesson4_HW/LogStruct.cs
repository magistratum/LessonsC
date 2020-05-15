using System.Diagnostics.Eventing.Reader;
using System.Windows.Markup;

namespace Lesson4_HW
{
    public struct Account
    {
        string _login;
        string _password;

        public Account(string login, string password)
        {
            _login = login;
            _password = password;
        }
        public string login
        {
            set { _login = value; }
            get { return _login; }
        }
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
    }

}