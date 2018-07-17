
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RolePermission.Model.Relationship;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMMENUTB
    {
        public SMMENUTB()
        {
            this.SMMENUROLEFUNCTB = new List<SMMENUROLEFUNCTB>();
            this.SMMENUTB1 = new List<SMMENUTB>();
            this.SMFUNCTB = new List<MenuFunc>();
        }
    
        [Key]
        [Display(Name = "主键", Order = 1)]
        public int ID { get; set; }
        [Display(Name = "名称", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string NAME { get; set; }
        [ForeignKey("SMMENUTB2")]
        [Display(Name = "父模块", Order = 3)]
        public int? PARENTID { get; set; }
        [Display(Name = "网址", Order = 4)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string URL { get; set; }
        [Display(Name = "图标", Order = 5)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string ICONIC { get; set; }
        [Display(Name = "排序", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? SORT { get; set; }
        [Display(Name = "备注", Order = 7)]
        [StringLength(4000, ErrorMessage = "长度不可超过4000")]
        public string REMARK { get; set; }
        [Display(Name = "状态", Order = 8)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string STATE { get; set; }
        [Display(Name = "创建人", Order = 9)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string CREATEPERSON { get; set; }
        [Display(Name = "创建时间", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }
        [Display(Name = "编辑时间", Order = 11)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }
        [Display(Name = "编辑人", Order = 12)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public string UPDATEPERSON { get; set; }
        [Display(Name = "叶子节点", Order = 9)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        public string ISLEAF { get; set; }
        public int? MENULEVEL { get; set; }

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "父模块")]
        [NotMapped]
        public string ParentIdOld { get; set; }

        [Display(Name = "操作")]
        [NotMapped]
        public string SysOperationId { get; set; }
        [Display(Name = "操作")]
        [NotMapped]
        public string SysOperationIdOld { get; set; }

        #endregion
    
        public virtual IList<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public virtual IList<SMMENUTB> SMMENUTB1 { get; set; }
        public virtual SMMENUTB SMMENUTB2 { get; set; }
        public virtual IList<MenuFunc> SMFUNCTB { get; set; }
    }
}
