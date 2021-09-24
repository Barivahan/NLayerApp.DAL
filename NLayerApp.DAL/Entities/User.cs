using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class User
    {
        public enum UserType
        {
            Manager,
            TeamMamber
        }
        [Key]
        public int UserId { get; set; }
        public UserType userType { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
