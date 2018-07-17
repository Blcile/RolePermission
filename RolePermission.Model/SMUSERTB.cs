
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using RolePermission.Common.HtmlHelpers;
using RolePermission.Model.Relationship;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMUSERTB
    {
        public SMUSERTB()
        {
            this.SMLOG = new List<SMLOG>();
            this.SMROLETB = new List<SMROLETB>();
            this.SMROLETB1 = new List<SMROLETB>();
            this.SMROLETB2 = new List<UserRole>();
        }
    
        [Key]
        [Display(Name = "用户ID", Order = 1)]
        public int USER_ID { get; set; }
        [Display(Name = "用户登陆名", Order = 2)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        public string U_ID { get; set; }        

        [Display(Name = "登陆密码", Order = 4)]
        [Required(ErrorMessage = "不能为空")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "长度不可小于3")]
        [DataType(DataType.Password)]
        public string U_PASSWORD { get; set; }
        [Display(Name = "性别", Order = 6)]
        [StringLength(2, ErrorMessage = "长度不可超过2")]
        public string GENDER { get; set; }
        [Display(Name = "姓名", Order = 3)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        public string USER_NAME { get; set; }
        [Display(Name = "创建时间", Order = 18)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATION_TIME { get; set; }
        [ForeignKey("SMUSERTB3")]
        [Display(Name = "创建人", Order = 19)]
        public int? CREATION_USER { get; set; }
        [Display(Name = "修改时间", Order = 20)]
        [DataType(DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATE_TIME { get; set; }
        [ForeignKey("SMUSERTB2")]
        [Display(Name = "修改人", Order = 21)]
        public int? UPDATE_USER { get; set; }
        [Display(Name = "启用状态", Order = 3)]
        [Required(ErrorMessage = "不能为空")]
        public string STATUS { get; set; }
        public int? COMPONENT_ID { get; set; }
        public int? ISAUDIT { get; set; }

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "角色")]
        [NotMapped]
        public string SysRoleIdOld { get; set; }

        [Display(Name = "创建人")]
        [NotMapped]
        public string CreateUserName { get; set; }

        [Display(Name = "更新人")]
        [NotMapped]
        public string UpdateUserName { get; set; }

        [Display(Name = "性别")]
        [NotMapped]
        public string GenderName { get; set; }

        [Display(Name = "状态")]
        [NotMapped]
        public string StatusName { get; set; }

        [Display(Name = "选择角色")]
        [NotMapped]
        public string SysRoleId { get; set; }

        [Display(Name = "确认密码", Order = 5)]
        [StringLength(20, ErrorMessage = "长度不可超过20")]
        [DataType(DataType.Password)]
        [Compare("U_PASSWORD", ErrorMessage = "两次密码不一致")]
        [NotMapped]
        public string SurePassword { get; set; }

        public SMUSERTB ToPoCo()
        {
            return new SMUSERTB
            {
                USER_ID = this.USER_ID,
                U_ID = this.U_ID,
                USER_NAME = this.USER_NAME,
                StatusName = this.STATUS.GetStatusName(),
                GenderName = this.GENDER.GetGenderName(),
                CREATION_TIME = this.CREATION_TIME,
                CREATION_USER = this.CREATION_USER,
                CreateUserName = this.CreateUserName
            };
        }
        public Account ToAccount()
        {
            return new Account { USER_NAME = this.USER_NAME, UID = this.U_ID, USER_ID = this.USER_ID, RoleIds = this.SMROLETB.Select(x => x.ROLE_ID).ToList() };
        }
        #endregion
        public virtual IList<SMLOG> SMLOG { get; set; }
        [InverseProperty("SMUSERTB")]
        public virtual IList<SMROLETB> SMROLETB { get; set; }
        [InverseProperty("SMUSERTB1")]
        public virtual IList<SMROLETB> SMROLETB1 { get; set; }
        public virtual SMUSERTB SMUSERTB2 { get; set; }
        public virtual SMUSERTB SMUSERTB3 { get; set; }
        public virtual IList<UserRole> SMROLETB2 { get; set; }
    }
    public class UserView : SMUSERTB
    {
        public List<string> RoleNames { get; set; }
    }
}
