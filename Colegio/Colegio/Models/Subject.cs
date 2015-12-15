using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    [Table("subjects")]
    public class Subject
    {
        [Key]
        public int SubjectID
        {
            get; set;
        }
        public string Name { set; get; }
        public virtual List<Student> ListaEstudiantes { get; set; }
    }
}