
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RolePermission.Model.Relationship;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMROLETB
    {
        public SMROLETB()
        {
            this.SMMENUROLEFUNCTB = new List<SMMENUROLEFUNCTB>();
            this.SMUSERTB2 = new List<UserRole>();
        }
    
        [Key]
        [Display(Name = "主键", Order = 1)]
        public int ROLE_ID { get; set; }
        [Display(Name = "角色名称", Order = 5)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        [Required(ErrorMessage = "不能为空")]
        public string ROLE_NAME { get; set; }
        [Display(Name = "创建时间", Order = 4)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATION_TIME { get; set; }
        [ForeignKey("SMUSERTB1")]
        [Display(Name = "创建人", Order = 7)]
        public int? CREATION_USER { get; set; }
        
        [Display(Name = "更新时间", Order = 4)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATE_TIME { get; set; }
        [ForeignKey("SMUSERTB")]
        [Display(Name = "更新人", Order = 7)]
        public int? UPDATE_USER { get; set; }
        [Display(Name = "说明", Order = 7)]
        [StringLength(100, ErrorMessage = "长度不可超过100")]
        public string REMARK { get; set; }
        [Display(Name = "角色状态", Order = 7)]
        [StringLength(2, ErrorMessage = "长度不可超过200")]
        [Required(ErrorMessage = "不能为空")]
        public string STATUS { get; set; }

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "人员")]
        [NotMapped]
        public string SysPersonId { get; set; }

        [Display(Name = "人员")]
        [NotMapped]
        public string SysPersonIdOld { get; set; }

        [Display(Name = "创建者")]
        [NotMapped]
        public string CreateUserName { get; set; }

        [Display(Name = "修改者")]
        [NotMapped]
        public string UpdateUserName { get; set; }

        [Display(Name = "状态")]
        [NotMapped]
        public string StatusName { get; set; }

        [NotMapped]
        public List<string> UserNames { get; set; }

        #endregion
    
        public virtual IList<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public virtual SMUSERTB SMUSERTB { get; set; }
        public virtual SMUSERTB SMUSERTB1 { get; set; }
        public virtual IList<UserRole> SMUSERTB2 { get; set; }
    }
}
