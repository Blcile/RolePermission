
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
        [Display(Name = "����", Order = 1)]
        public int ROLE_ID { get; set; }
        [Display(Name = "��ɫ����", Order = 5)]
        [StringLength(20, ErrorMessage = "���Ȳ��ɳ���20")]
        [Required(ErrorMessage = "����Ϊ��")]
        public string ROLE_NAME { get; set; }
        [Display(Name = "����ʱ��", Order = 4)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? CREATION_TIME { get; set; }
        [ForeignKey("SMUSERTB1")]
        [Display(Name = "������", Order = 7)]
        public int? CREATION_USER { get; set; }
        
        [Display(Name = "����ʱ��", Order = 4)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? UPDATE_TIME { get; set; }
        [ForeignKey("SMUSERTB")]
        [Display(Name = "������", Order = 7)]
        public int? UPDATE_USER { get; set; }
        [Display(Name = "˵��", Order = 7)]
        [StringLength(100, ErrorMessage = "���Ȳ��ɳ���100")]
        public string REMARK { get; set; }
        [Display(Name = "��ɫ״̬", Order = 7)]
        [StringLength(2, ErrorMessage = "���Ȳ��ɳ���200")]
        [Required(ErrorMessage = "����Ϊ��")]
        public string STATUS { get; set; }

        #region �Զ������ԣ���������ʵ����չ��ʵ��

        [Display(Name = "��Ա")]
        [NotMapped]
        public string SysPersonId { get; set; }

        [Display(Name = "��Ա")]
        [NotMapped]
        public string SysPersonIdOld { get; set; }

        [Display(Name = "������")]
        [NotMapped]
        public string CreateUserName { get; set; }

        [Display(Name = "�޸���")]
        [NotMapped]
        public string UpdateUserName { get; set; }

        [Display(Name = "״̬")]
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
