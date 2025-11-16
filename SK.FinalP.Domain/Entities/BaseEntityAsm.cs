namespace SK.FinalP.Domain.Entities;

public abstract class BaseEntityAsm : BaseEntity
{
    public int CreatedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
    public Adm_User? CreatedByUser { get; set; }
    public Adm_User? LastUpdatedByUser { get; set; }
}
