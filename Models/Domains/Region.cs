﻿namespace TestDotnet.Models.Domains;

public class Region
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
    public string? Test { get; set; }
}
