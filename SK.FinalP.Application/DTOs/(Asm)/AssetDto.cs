using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Application.DTOs;

public class AssetDto : BaseDto
{
    public IEnumerable<Asm_Asset> Assets { get; set; } = [];
}
