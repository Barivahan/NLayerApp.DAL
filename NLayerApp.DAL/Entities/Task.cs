using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
