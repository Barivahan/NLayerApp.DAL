using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public User Manager { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
