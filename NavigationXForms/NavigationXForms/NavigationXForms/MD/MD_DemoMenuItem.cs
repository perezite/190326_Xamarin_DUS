using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationXForms.MD
{

    public class MD_DemoMenuItem
    {
        public MD_DemoMenuItem(Type TargetType)
        {
            this.TargetType = TargetType;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}