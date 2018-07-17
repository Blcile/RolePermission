namespace RolePermission.Model.Relationship
{
    public class MenuFunc
    {
        public int MenuId { get; set; }
        public virtual SMMENUTB Menu { get; set; }
        public int FuncId { get; set; }
        public virtual SMFUNCTB Func { get; set; }
    }
}