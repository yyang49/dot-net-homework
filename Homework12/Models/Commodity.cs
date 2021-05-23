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
    public class Commodity
    {
        [Key]
        public int Id { get; set; }
        public int no { get; set; }
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        public Commodity(int no, string name, double price)
        {
            this.no = no;
            this.name = name;
            this.price = price;
        }
        public Commodity() { }
        public override string ToString()
        {
            return $"{no}\t{name}\t{price}元/件";
        }
    }
}
