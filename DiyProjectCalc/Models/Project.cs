﻿using System.ComponentModel.DataAnnotations;

namespace DiyProjectCalc.Models;

public class Project 
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    [Display(Name = "Project Name")]
    public string? Name { get; set; }

    public virtual ICollection<BasicShape> BasicShapes { get; set; } = new HashSet<BasicShape>();

    public double Area() => BasicShapes.Select(a => a.Area).Sum();
    public double Distance() => BasicShapes.Select(a => a.Distance).Sum();
}
