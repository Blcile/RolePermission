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

        [Display(Name = "����", Order = 1)] 
        [Key]
        public int ID { get; set; }
        [Display(Name = "����", Order = 2)]
        [Required(ErrorMessage = "����Ϊ��")]
        [StringLength(50, ErrorMessage = "���Ȳ��ɳ���50")]
        public string MYTEXTS { get; set; }
        [ForeignKey("SMFIELD2")]
        [Display(Name = "���ڵ�", Order = 3)]
        [StringLength(36, ErrorMessage = "���Ȳ��ɳ���36")]
        public int? PARENTID { get; set; }
        [Display(Name = "����", Order = 4)]
        [StringLength(50, ErrorMessage = "���Ȳ��ɳ���50")]
        public string MYTABLES { get; set; }
        [Display(Name = "�ֶ�", Order = 5)]
        [StringLength(50, ErrorMessage = "���Ȳ��ɳ���50")]
        public string MYCOLUMS { get; set; }
        [Display(Name = "����", Order = 6)]
        [Range(0, 2147483646, ErrorMessage = "��ֵ������Χ")]
        public decimal? SORT { get; set; }
        [Display(Name = "��ע", Order = 7)]
        [StringLength(200, ErrorMessage = "���Ȳ��ɳ���200")]
        public string REMARK { get; set; }
        [Display(Name = "����ʱ��", Order = 8)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? CREATETIME { get; set; }
        [Display(Name = "������", Order = 9)]
        [StringLength(50, ErrorMessage = "���Ȳ��ɳ���50")]
        public string CREATEPERSON { get; set; }
        [Display(Name = "�༭ʱ��", Order = 10)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? UPDATETIME { get; set; }
        [Display(Name = "�༭��", Order = 11)]
        [StringLength(50, ErrorMessage = "���Ȳ��ɳ���50")]
        public string UPDATEPERSON { get; set; }
        public string MYVALUES { get; set; }
        
        #region �Զ������ԣ���������ʵ����չ��ʵ��

        [NotMapped]
        [Display(Name = "���ڵ�")] 
        public string ParentIdOld { get; set; }
        #endregion
    
        public virtual IList<SMFIELD> SMFIELD1 { get; set; }
        public virtual SMFIELD SMFIELD2 { get; set; }
    }
}
