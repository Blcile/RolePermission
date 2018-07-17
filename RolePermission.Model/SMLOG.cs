using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMLOG
    {
        [Key]
        [Display(Name = "日志ID", Order = 1)]
        public int LOG_ID { get; set; }
        
        [Display(Name = "操作时间", Order = 2)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? LOG_DATETIME { get; set; }
        [ForeignKey("SMUSERTB")]
        [Display(Name = "操作用户", Order = 3)]
        public int? USER_ID { get; set; }
        
        [Display(Name = "系统功能", Order = 4)]
        [StringLength(32, ErrorMessage = "长度不可超过32")]
        public string FUNC_CODE { get; set; }
        [Display(Name = "操作类型", Order = 6)]
        public string OPERATION_TYPE { get; set; }
        
        [Display(Name = "操作描述", Order = 7)]
        [StringLength(4000, ErrorMessage = "长度不可超过4000")]
        public string REMARK { get; set; }
        [Display(Name = "操作的类+函数名", Order = 5)]
        [StringLength(100, ErrorMessage = "长度不可超过100")]
        public string CLASSNAME { get; set; }

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "操作类型")]
        [NotMapped]
        public string OperaterTypeName { get; set; }

        [Display(Name = "状态")]
        [NotMapped]
        public string StatusName { get; set; }

        #endregion
    
        public virtual SMUSERTB SMUSERTB { get; set; }
    }
}
