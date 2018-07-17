using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMFIELD
    {
        public SMFIELD()
        {
            this.SMFIELD1 = new List<SMFIELD>();
        }

        [Display(Name = "主键", Order = 1)] 
        [Key]
        public int ID { get; set; }
        [Display(Name = "名称", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYTEXTS { get; set; }
        [ForeignKey("SMFIELD2")]
        [Display(Name = "父节点", Order = 3)]
        [StringLength(36, ErrorMessage = "长度不可超过36")]
        public int? PARENTID { get; set; }
        [Display(Name = "表名", Order = 4)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYTABLES { get; set; }
        [Display(Name = "字段", Order = 5)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string MYCOLUMS { get; set; }
        [Display(Name = "排序", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public decimal? SORT { get; set; }
        [Display(Name = "备注", Order = 7)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string REMARK { get; set; }
        [Display(Name = "创建时间", Order = 8)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }
        [Display(Name = "创建人", Order = 9)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string CREATEPERSON { get; set; }
        [Display(Name = "编辑时间", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }
        [Display(Name = "编辑人", Order = 11)]
        [StringLength(50, ErrorMessage = "长度不可超过50")]
        public string UPDATEPERSON { get; set; }
        public string MYVALUES { get; set; }
        
        #region 自定义属性，即由数据实体扩展的实体

        [NotMapped]
        [Display(Name = "父节点")] 
        public string ParentIdOld { get; set; }
        #endregion
    
        public virtual IList<SMFIELD> SMFIELD1 { get; set; }
        public virtual SMFIELD SMFIELD2 { get; set; }
    }
}
