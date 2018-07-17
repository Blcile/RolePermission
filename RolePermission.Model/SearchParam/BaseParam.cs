using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.Model.SearchParam
{
    public class BaseParam
    {
        public int page { get; set; }
        public int rows { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public int TotalCount { get; set; }
    }
}