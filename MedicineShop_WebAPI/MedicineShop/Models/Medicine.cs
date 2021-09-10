using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string MedicineName { get; set; }
        [ForeignKey("GenericGroup")]
        [Required]
        public int GenericGroupId { get; set; }
        [Required,Column(TypeName ="date")]
        public DateTime ExpireDate { get; set; }
        [Required,Column(TypeName ="money")]
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }

        //Navigation
        public GenericGroup GenericGroup { get; set; }
    }
}
