using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingManagement.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
            //Users = new List<string>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        //public List<string> Users { get; set; }
    }
}