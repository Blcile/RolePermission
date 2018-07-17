
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
        [Display(Name = "�û�ID", Order = 1)]
        public int USER_ID { get; set; }
        [Display(Name = "�û���½��", Order = 2)]
        [Required(ErrorMessage = "����Ϊ��")]
        [StringLength(20, ErrorMessage = "���Ȳ��ɳ���20")]
        public string U_ID { get; set; }        

        [Display(Name = "��½����", Order = 4)]
        [Required(ErrorMessage = "����Ϊ��")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "���Ȳ���С��3")]
        [DataType(DataType.Password)]
        public string U_PASSWORD { get; set; }
        [Display(Name = "�Ա�", Order = 6)]
        [StringLength(2, ErrorMessage = "���Ȳ��ɳ���2")]
        public string GENDER { get; set; }
        [Display(Name = "����", Order = 3)]
        [StringLength(20, ErrorMessage = "���Ȳ��ɳ���20")]
        public string USER_NAME { get; set; }
        [Display(Name = "����ʱ��", Order = 18)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? CREATION_TIME { get; set; }
        [ForeignKey("SMUSERTB3")]
        [Display(Name = "������", Order = 19)]
        public int? CREATION_USER { get; set; }
        [Display(Name = "�޸�ʱ��", Order = 20)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? UPDATE_TIME { get; set; }
        [ForeignKey("SMUSERTB2")]
        [Display(Name = "�޸���", Order = 21)]
        public int? UPDATE_USER { get; set; }
        [Display(Name = "����״̬", Order = 3)]
        [Required(ErrorMessage = "����Ϊ��")]
        public string STATUS { get; set; }
        public int? COMPONENT_ID { get; set; }
        public int? ISAUDIT { get; set; }

        #region �Զ������ԣ���������ʵ����չ��ʵ��

        [Display(Name = "��ɫ")]
        [NotMapped]
        public string SysRoleIdOld { get; set; }

        [Display(Name = "������")]
        [NotMapped]
        public string CreateUserName { get; set; }

        [Display(Name = "������")]
        [NotMapped]
        public string UpdateUserName { get; set; }

        [Display(Name = "�Ա�")]
        [NotMapped]
        public string GenderName { get; set; }

        [Display(Name = "״̬")]
        [NotMapped]
        public string StatusName { get; set; }

        [Display(Name = "ѡ���ɫ")]
        [NotMapped]
        public string SysRoleId { get; set; }

        [Display(Name = "ȷ������", Order = 5)]
        [StringLength(20, ErrorMessage = "���Ȳ��ɳ���20")]
        [DataType(DataType.Password)]
        [Compare("U_PASSWORD", ErrorMessage = "�������벻һ��")]
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
