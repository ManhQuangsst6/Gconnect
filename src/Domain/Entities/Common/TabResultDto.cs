public class TabResultDto
{
    public string Title { get; set; } = string.Empty;
    public long Value { get; set; }
    public List<TabResultItemDto> Items { get; set; } = new List<TabResultItemDto>();
}
public class TabResultItemDto
{
    public string Title { get; set; } = string.Empty;
    public long Value { get; set; }
    public int Level { get; set; } = 0;
}

