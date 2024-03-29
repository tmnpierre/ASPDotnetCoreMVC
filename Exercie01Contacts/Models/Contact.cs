﻿using System.ComponentModel;

namespace Exercie01Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public Contact() { }

        public Contact(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}