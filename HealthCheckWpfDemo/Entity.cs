using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCheckWpfDemo
{
    [Table("t_blood")]
    public class BloodItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<BloodItemDetails> details { get; set; }
        public BloodItem()
        {
            details = new List<BloodItemDetails>();
        }
    }

    [Table("t_blooditem")]
   public class BloodItemDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string standard { get; set; }
        public string unit { get; set; }
        public string higher { get; set; }
        public string lower { get; set; }
        [Column("bloodid")]
        public int bloodItemId { get; set; }
    }
    
    [Table("t_cancer")]
    public class CancerItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Treatment> treatments { get; set; }
        public CancerItem()
        {
            treatments = new List<Treatment>();
        }
    }
    [Table("t_item")]
    public class Treatment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string period { get; set; }
        public string desp { get; set; }
        [Column("cancerid")]
        public int cancerItemid { get; set; }
    }
}
