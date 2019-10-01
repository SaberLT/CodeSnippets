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
    }

    public enum AuthType : byte
    {
        STANDARD = 0,
        GITHUB = 1,
        VK = 2
    }

    public enum Role : byte
    {
        USER = 0,
        ADMIN = 1
    }
}
