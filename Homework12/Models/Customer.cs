using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework12.Models
{
    [Serializable]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public Customer(string name, string info)
        {
            this.name = name;
            this.info = info;
        }
        public Customer() { }
        public override string ToString()
        {
            return $"{name}\t{info}";
        }
    }
}
