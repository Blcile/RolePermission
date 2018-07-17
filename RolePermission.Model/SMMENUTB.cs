
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
        [Display(Name = "����", Order = 1)]
        public int ID { get; set; }
        [Display(Name = "����", Order = 2)]
        [Required(ErrorMessage = "����Ϊ��")]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string NAME { get; set; }
        [ForeignKey("SMMENUTB2")]
        [Display(Name = "��ģ��", Order = 3)]
        public int? PARENTID { get; set; }
        [Display(Name = "��ַ", Order = 4)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string URL { get; set; }
        [Display(Name = "ͼ��", Order = 5)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string ICONIC { get; set; }
        [Display(Name = "����", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "��ֵ������Χ")]
        public int? SORT { get; set; }
        [Display(Name = "��ע", Order = 7)]
        [StringLength(4000, ErrorMessage = "���Ȳ��ɳ���4000")]
        public string REMARK { get; set; }
        [Display(Name = "״̬", Order = 8)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string STATE { get; set; }
        [Display(Name = "������", Order = 9)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string CREATEPERSON { get; set; }
        [Display(Name = "����ʱ��", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? CREATETIME { get; set; }
        [Display(Name = "�༭ʱ��", Order = 11)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? UPDATETIME { get; set; }
        [Display(Name = "�༭��", Order = 12)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string UPDATEPERSON { get; set; }
        [Display(Name = "Ҷ�ӽڵ�", Order = 9)]
        [StringLength(20, ErrorMessage = "���Ȳ��ɳ���20")]
        public string ISLEAF { get; set; }
        public int? MENULEVEL { get; set; }

        #region �Զ������ԣ���������ʵ����չ��ʵ��

        [Display(Name = "��ģ��")]
        [NotMapped]
        public string ParentIdOld { get; set; }

        [Display(Name = "����")]
        [NotMapped]
        public string SysOperationId { get; set; }
        [Display(Name = "����")]
        [NotMapped]
        public string SysOperationIdOld { get; set; }

        #endregion
    
        public virtual IList<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public virtual IList<SMMENUTB> SMMENUTB1 { get; set; }
        public virtual SMMENUTB SMMENUTB2 { get; set; }
        public virtual IList<MenuFunc> SMFUNCTB { get; set; }
    }
}
