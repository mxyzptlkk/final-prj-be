namespace SK.FinalP.Domain.Entities;

public class Adm_Organization : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public int? ParentId { get; set; }
    public int CreatedBy { get; set; }
    public int? LastUpdatedBy { get; set; }
}
