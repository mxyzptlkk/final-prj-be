using System;
using SK.FinalP.Shared;

namespace SK.FinalP.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedAt { get; set; }
    public int Version { get; set; } = Consts.InitialVersion;
    public bool IsNotDeleted { get; set; } = true;
}
