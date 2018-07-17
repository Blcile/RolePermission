namespace RolePermission.Model.Relationship
{
    public class UserRole
    {
        public int UserId { get; set; }
        public virtual SMUSERTB User { get; set; }
        public int RoleId { get; set; }
        public virtual SMROLETB Role { get; set; }
    }
}