namespace SK.FinalP.Domain.Entities;

public class Asm_Category : BaseEntityAsm
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public int? ParentId { get; set; }
}
