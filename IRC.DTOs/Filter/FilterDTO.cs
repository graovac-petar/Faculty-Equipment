namespace IRC.DTOs.Filter;

public class FilterRequestDTO
{
    public List<FilterDTO> Filters { get; set; } = new();
}

public class FilterDTO
{
    public string Name { get; set; }
    public string Value { get; set; }
}
