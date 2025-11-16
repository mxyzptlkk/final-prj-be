using SK.FinalP.Shared;

namespace SK.FinalP.Domain.Entities;

public class Asm_Asset : BaseEntityAsm
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public Enums.AssetStatus Status { get; set; }
    public int CategoryId { get; set; }
    public int OwnerId { get; set; }
    public Asm_Category? Category { get; set; }
    public Adm_User? Owner { get; set; }
}
