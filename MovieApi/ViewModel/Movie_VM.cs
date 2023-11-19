using System.ComponentModel.DataAnnotations;
 
namespace MovieAppapi.ViewModel;
 
public class Movie_VM
{
 
    public string Name{get;set;}
    public string Actor{get;set;}
    public string Role{get;set;}
    public int YearRelease{get;set;}
}