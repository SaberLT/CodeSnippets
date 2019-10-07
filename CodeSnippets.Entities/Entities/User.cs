using CodeSnippets.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Entities.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Username { get; set; }
        public AuthType AuthType { get; set; }
        public string AuthData { get; set; }
        public string UserInfo { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastActionDate { get; set; }
        public Role Role { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum AuthType : byte
    {
        Standard = 0,
        GitHub = 1,
        Vk = 2
    }

    public enum Role : byte
    {
        User = 0,
        Admin = 1
    }
}
