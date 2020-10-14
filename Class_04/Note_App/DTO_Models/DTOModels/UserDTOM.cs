using Domain_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Models.DTOModels
{
    public class UserDTOM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }     
        public string FullName => $"{FirstName} {LastName}";       
        public string UserName { get; set; }       
        public string Password { get; set; }
        public virtual List<NoteDTOM> Notes { get; set; } = new List<NoteDTOM>();
    }
}
