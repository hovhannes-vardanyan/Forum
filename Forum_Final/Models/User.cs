using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum_Final.Models
{
    public class User
    {
        public int UserId = 0; // unique user Id

        //Display is need for showing property names for UI
        [Display(Name ="First Name")]
        public string UserName { get; private set; }
        [Display(Name = "Last Name")]

        public string UserSurname { get; private set; }
        [Display(Name = "Username")]
       public string UserLogin { get; private set; }
        [Display(Name = "Password")]

        public string UserPassword { get; private set; }
        
        
        public User()
        {

        }
        //creating user
        public User(string name, string surname, string login, string password)
        {
            this.UserName = name;
            this.UserSurname = surname;
            this.UserLogin = login;
            this.UserPassword = password;
            ++UserId; // getting unique ID
        }
    }
}