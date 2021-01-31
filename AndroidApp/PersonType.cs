using System;
using System.Collections.Generic;

namespace AndroidApp
{
    class PersonType
    {
        public int ID { get; set; }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                ValidationLogin(value);
                _login = value;
            }
        }
        public string Name
        {
            get {   return _name;}
            set
            {
                ValidationName(value);
                _name = value;
            }
        }
        public string SerName
        {
            get {   return _serName;}
            set
            {
                ValidationName(value);
                _serName = value;
            }
        }
        public DateTime Birthday { get; set; }
        public Boolean Online { get; set; }
        public SexEnum Sex { get; set; }
        public string Email {
            get
            {
                return _email;
            }
            set
            {
                //TODO:Validation
            }
        }
        public bool IsOnline(){ return Online.Equals(true); }
        public void AddFriend(PersonType friend)
        {
            if (friend is null)
                throw new ArgumentNullException("Added friend is null");
            _friends.Add(friend);
        }
        private void ValidationName(string value)
        {
            if (value is null)
                throw new ArgumentNullException("Name cann't be null");
            
            bool result=Int32.TryParse(value, out int number);
            if (result == false)
                throw new ArgumentException("Name cann't contain numbers");
        }
        private void ValidationLogin(string value)
        {
            if (value is null)
                throw new ArgumentNullException("Login cann't be null");
            if (value.Length > 25 || value.Length < 5)
                throw new ArgumentException("Length of login must be \">5\" and \"< 25\".");
        }

        private string _email;
        private List<PersonType> _friends;
        private string _serName;
        private string _name;
        private string _password;
        private string _login;
    }
}
