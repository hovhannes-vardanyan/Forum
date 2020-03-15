using ForumDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // unique user Id

       
        //Display is need for showing property names for UI
        [Display(Name ="First Name")]
        public string UserName { get;  set; }
        [Display(Name = "Last Name")]
      

        public string UserSurname { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage ="Enter username")]

        public string UserLogin { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage ="Enter the password")]
        
        public string UserPassword { get; set; }
        
        public ICollection<Post> Posts { get; set; }

        public List<Notification> Notifications { get; set; }
        
        public User()
        {

        }
        //creating user
        public User(string name, string surname, string login, string password, int id)
        {
            this.UserName = name;
            this.UserSurname = surname;
            this.UserLogin = login;
            this.UserPassword = password;
            this.UserId = id;
        }


    }
}