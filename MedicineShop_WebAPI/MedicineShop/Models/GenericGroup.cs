using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShop.Models
{
    public class GenericGroup
    {
        public GenericGroup()
        {
            this.Medicines = new List<Medicine>();
        }
        public int Id { get; set; }
        public string GroupName { get; set; }

        //Navigation
        public ICollection<Medicine> Medicines { get; set; }
    }
}
