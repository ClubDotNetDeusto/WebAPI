using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class Address
    {
        [Key, ForeignKey("Student")]
        public int StudentId
        {
            get; set;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public virtual Student Student { get; set; }
    }
}