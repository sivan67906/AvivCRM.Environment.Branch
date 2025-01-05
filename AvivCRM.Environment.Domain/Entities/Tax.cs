﻿using AvivCRM.Environment.Domain.Entities.Common;

namespace AvivCRM.Environment.Domain.Entities;
public sealed class Tax : BaseEntity, IEntity
{
    public string? Name { get; set; } = default!;
    public float Rate { get; set; } = default!;
}