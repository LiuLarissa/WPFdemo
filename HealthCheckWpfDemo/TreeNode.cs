using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCheckWpfDemo
{
    public class TreeNode
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public List<TreeNode> childnodes { get; set; }
        public TreeNode()
        {
            childnodes = new List<TreeNode>();
        }
    }
}
