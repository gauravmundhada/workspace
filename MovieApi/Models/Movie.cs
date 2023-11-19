using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
 
 
namespace MovieApi.Models;
 
public class Movie
{
    [Key]
    public int Id{get;set;}
    [Required]
    public string? Name {get;set;}
    public int YearRelease{get;set;}
    public int Rating{get;set;}
    public ICollection<Detail> ? Details{get;set;}
}