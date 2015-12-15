using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Description { get; set; }      
        public virtual List<Pulsera> ListaPulseras { get; set; }
        public virtual List<Subject> ListaSubject { get; set; }
        public virtual Address StudentAddress { get; set; }

    }
}