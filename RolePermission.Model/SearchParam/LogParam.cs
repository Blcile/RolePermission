using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.Model.SearchParam
{
    public class LogParam : BaseParam
    {
        public string LOG_DATETIMEStart_Time { get; set; }
        public string LOG_DATETIMEEnd_Time { get; set; }
        public string OPERATION_TYPE { get; set; }
    }
}
