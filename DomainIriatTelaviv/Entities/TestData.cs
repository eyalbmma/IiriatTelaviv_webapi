using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Entities
{
    [Table("Test")]
    public class TestData
    {
        [Key]

        public int? id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Profession { get; set; }
    }
}
