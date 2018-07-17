using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMLOG
    {
        [Key]
        [Display(Name = "��־ID", Order = 1)]
        public int LOG_ID { get; set; }
        
        [Display(Name = "����ʱ��", Order = 2)]
        [DataType(DataType.DateTime, ErrorMessage = "ʱ���ʽ����ȷ")]
        public DateTime? LOG_DATETIME { get; set; }
        [ForeignKey("SMUSERTB")]
        [Display(Name = "�����û�", Order = 3)]
        public int? USER_ID { get; set; }
        
        [Display(Name = "ϵͳ����", Order = 4)]
        [StringLength(32, ErrorMessage = "���Ȳ��ɳ���32")]
        public string FUNC_CODE { get; set; }
        [Display(Name = "��������", Order = 6)]
        public string OPERATION_TYPE { get; set; }
        
        [Display(Name = "��������", Order = 7)]
        [StringLength(4000, ErrorMessage = "���Ȳ��ɳ���4000")]
        public string REMARK { get; set; }
        [Display(Name = "��������+������", Order = 5)]
        [StringLength(100, ErrorMessage = "���Ȳ��ɳ���100")]
        public string CLASSNAME { get; set; }

        #region �Զ������ԣ���������ʵ����չ��ʵ��

        [Display(Name = "��������")]
        [NotMapped]
        public string OperaterTypeName { get; set; }

        [Display(Name = "״̬")]
        [NotMapped]
        public string StatusName { get; set; }

        #endregion
    
        public virtual SMUSERTB SMUSERTB { get; set; }
    }
}
