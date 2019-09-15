using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Goal
    {
        [Key]
        public long TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] File { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public string Status { get; set; }
    }
}
