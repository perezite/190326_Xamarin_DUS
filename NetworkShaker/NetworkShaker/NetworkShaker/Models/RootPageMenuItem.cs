using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShaker.Models
{
    public class RootPageMenuItem
    {
        public RootPageMenuItem(Type TargetType,string Title)
        {
            this.Title = Title;
            this.TargetType = TargetType;
        }
        public string Title { get; set; }
        public Type TargetType { get; }
    }
}