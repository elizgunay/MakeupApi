using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public LoginVM() { }

        public LoginVM(UserDto userDto)
        {
            Id = userDto.Id;
            Username = userDto.Username;
            Password = userDto.Password;
        }
    }
}