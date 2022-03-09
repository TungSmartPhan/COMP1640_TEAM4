using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COMP1640_TEAM4.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
     
        public string CreateBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Limitation
        {
            get { return StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString(); }
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
       
    }
}