using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final
{
    public class Users
    {
        public int UserId = 0; // unique user Id
        public string UserName { get; private set; }
        public string UserSurname { get; private set; }
        public string UserLogin { get; private set; }
        public string UserPassword { get; private set; }


        //creating user
        public Users(string name, string surname, string login, string password)
        {
            this.UserName = name;
            this.UserSurname = surname;
            this.UserLogin = login;
            this.UserPassword = password;
            ++UserId; // getting unique ID
        }




    }
}