﻿using System.ComponentModel.DataAnnotations;

namespace course_backend_entities;

public class Gender
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(maximumLength: 10)]
    [FirstLetterUppercase]
    public string Name { get; set; } = string.Empty;
}
