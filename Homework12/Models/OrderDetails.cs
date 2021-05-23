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
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Commodity goods { get; set; }
        [Required]
        public int quantity { get; set; }
        [NotMapped]
        public int goodsNo { get => goods.no; set { goods.no = value; } }
        [NotMapped]
        public string goodsName { get => goods.name; set { goods.name = value; } }
        [NotMapped]
        public double goodsPrice { get=>goods.price; set { goods.price = value; } }
        public OrderDetails(Commodity goods,int quantity)
        {
            this.goods = goods;
            this.quantity = quantity;
        }
        public OrderDetails()
        {
            this.goods = new Commodity();
        }
        public override string ToString()
        {
            return $"{goods}\n{quantity}件\t共{goods.price*quantity}元\n";
        }
        public override int GetHashCode()
        {
            return goods.no;
        }
    }
}
