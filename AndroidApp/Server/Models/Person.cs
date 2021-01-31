using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AndroidApp
{
    /// <summary>
    /// Тип клиента
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Публичный конструктор клиента
        /// </summary>
        /// <param name="login"> Логин </param>
        /// <param name="password"> хэш пароля </param>
        /// <param name="email"> Email </param>
        /// <param name="name">Имя</param>
        /// <param name="sex">Пол </param>
        /// <param name="birthday">Дата рождения</param>
        public Person(string login, string password,string email, string name,Sex sex, DateTime birthday)
        {
            ID = Guid.NewGuid().ToString();
            ValidationLogin(login);
            Login = login;
            _password = password;
            ValidationEmail(email);
            Email = email;
            ValidationName(name);
            Name = name;
            ValidationSex(sex);
            Sex = sex;
            Birthday = birthday;
            _friends = new Dictionary<string, Person>();

        }
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public string ID { get; }
        /// <summary>
        /// Логин клиента
        /// </summary>
        public string Login { get; }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string SerName
        {
            get => _serName;
            set
            {
                ValidationName(value);
                _serName = value;
            }
        }
        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        public DateTime Birthday { get; }
        /// <summary>
        /// Электронная почта клиента
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// Флаг нахождения клиента в сети
        /// </summary>
        public bool Online { get; set; }
        /// <summary>
        /// Пол клиента
        /// </summary>
        public Sex Sex { get; }
        /// <summary>
        /// Добавляет клиента в список друзей
        /// </summary>
        /// <param name="friend">Пользователь- друг</param>
        public void AddFriend(Person friend)
        {
            if (friend is null)
                throw new ArgumentNullException("Added friend is null");
            _friends.Add(ID, friend);
        }
        /// <summary>
        /// Проверка на корректность электронной почты
        /// </summary>
        /// <param name="email"> Электронная почта</param>
        private void ValidationEmail(string email)
        {
            //TODO:Validation
        }
        /// <summary>
        /// Проверка на корректность введенного имени
        /// </summary>
        /// <param name="value"> Имя</param>
        private void ValidationName(string value)
        {
            if (value is null)
                throw new ArgumentNullException("Name cann't be null");
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cann't contain whitespaces");
            Regex regex=new Regex(@"[0-9]");
            if (regex.IsMatch(value) == false)
                throw new ArgumentException("Name cann't contain numbers");
        }
        /// <summary>
        /// Проверка на корректность ввода логина
        /// </summary>
        /// <param name="value">логин</param>
        private void ValidationLogin(string value)
        {
            if (value is null)
                throw new ArgumentNullException("Login cann't be null");
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Login cann't contain whitespaces");
            if (value.Length > 25 || value.Length < 5)
                throw new ArgumentException("Length of login must be \">5\" and \"< 25\".");
        }
        /// <summary>
        /// Проверка на корректность ввода пола
        /// </summary>
        /// <param name="sex">Пол</param>
        private void ValidationSex(Sex sex)
        {
            if (Enum.IsDefined(sex) == false)
                throw new ArgumentException("Incorrect type of sex");
        }
        private Dictionary<String,Person> _friends;
        private string _serName;
        private string _password;
    }
}
