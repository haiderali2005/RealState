﻿using System.ComponentModel.DataAnnotations;

namespace RealtorsPortal.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
