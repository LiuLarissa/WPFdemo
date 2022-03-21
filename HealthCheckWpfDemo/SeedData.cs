using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCheckWpfDemo
{
    public class SeedData
    {
        public List<BloodItem> bloodItems { get; set; }
        public List<CancerItem> cancerItems { get; set; }

        public SeedData()
        {
            Init();
        }

        private void Init()
        {
            bloodItems = new List<BloodItem>()
            {
                new BloodItem
                {
                    id=1,
                    name="血常规",
                    details=new List<BloodItemDetails>()
                    {
                        new BloodItemDetails
                        {
                            id=1,
                            name="红细胞RBC",
                            standard="3.5-5.5",
                            unit="10-12/L",
                            higher="真性红细胞增多症、严重脱水、肺源性心脏病",
                            lower="贫血",
                            bloodItemId=1
                        }
                    }
                },
                new BloodItem
                {
                    id=2,
                    name="肝功",
                    details=new List<BloodItemDetails>()
                    {
                        new BloodItemDetails
                        {
                            id=10,
                            name="谷草转氨酶AST",
                            standard="<40",
                            unit="U/L",
                            higher="可见于急慢性肝炎等肝脏疾病及某些药物的毒副作用。",
                            lower="",
                            bloodItemId=2
                        }
                    }
                }
            };
            cancerItems = new List<CancerItem>()
            {
                new CancerItem
                {
                    id=1,
                    name="乳腺癌",
                    treatments=new List<Treatment>()
                    {
                        new Treatment
                        {
                            id=1,
                            name="乳腺钼靶",
                            period="2年1次",
                            desp="建议40岁以上开始检查，有家族史要尽早检查"
                        }
                    }
                },
                new CancerItem
                {
                    id=2,
                    name="肺癌",
                    treatments=new List<Treatment>()
                    {
                        new Treatment
                        {
                            id=3,
                            name="低剂量螺旋CT",
                            period="1年1次",
                            desp=" 结节<3mm，建议每年复查；3mm<=结节<10mm,3个月复查增强CT；另：遵医嘱"
                        }
                    }
                }
            };
        }
    }
}
