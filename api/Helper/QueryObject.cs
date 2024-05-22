﻿namespace api.Helper;

public class QueryObject
{
    public string? Name { get; set; }
    public string? Value { get; set; }
    public string? SortBy { get; set; } = null;
    public bool IsDecsending { get; set; } = false;

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
