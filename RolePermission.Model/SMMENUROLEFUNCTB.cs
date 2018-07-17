
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolePermission.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMMENUROLEFUNCTB
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("SMMENUTB")]
        public int? MENUID { get; set; }
        [ForeignKey("SMFUNCTB")]
        public int? FUNC_ID { get; set; }
        [ForeignKey("SMROLETB")]
        public int? ROLEID { get; set; }
    
        public virtual SMFUNCTB SMFUNCTB { get; set; }
        public virtual SMMENUTB SMMENUTB { get; set; }
        public virtual SMROLETB SMROLETB { get; set; }
    }
}
