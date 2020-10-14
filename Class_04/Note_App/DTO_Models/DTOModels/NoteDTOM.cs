using Domain_Models.Enums;
using Domain_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO_Models.DTOModels
{
    public class NoteDTOM
    {
        public int Id { get; set; }
        public string Text { get; set; }        
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }        
        
    }
}
