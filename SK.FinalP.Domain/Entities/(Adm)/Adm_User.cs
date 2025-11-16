namespace SK.FinalP.Domain.Entities;

public class Adm_User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int? OrganizationID { get; set; }
    public bool IsActive { get; set; }
    public int? CreatedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
}
