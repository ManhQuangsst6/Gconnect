using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;
public class TreeSelectDto 
{
    public string Title { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string SelectValue { get; set; } = string.Empty;
    public int Level { get; set; } = 0;
    public string ParentId { get; set; } = string.Empty;
    public bool Selectable { get; set; } = true;
    public decimal? X { get; set; }

    public decimal? Y { get; set; }
    public List<TreeSelectDto> Children { get; set; }= new List<TreeSelectDto>();
}
