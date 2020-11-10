using System;

namespace CSharpLearning
{
    class User
    {
        string _userName;
        string _password;
        public string Username { get
            {
                return _userName;
            }
            set {
                if(value.Length > 15)
                {
                    throw new ArgumentException("The length of text is over 15.");
                }
                _userName = value;
            } }
        public string Password { get
            {
                return _password;
            }
            set {
                if(value.Length < 8)
                {
                    throw new ArgumentException("The length of text is at least 8.");
                }
                _password = value;
            } }
    }
}
