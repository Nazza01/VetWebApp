using System.ComponentModel.DataAnnotations;

namespace VetWebApp.Models;

public class UserData
{
	public int Id { get; set; }
	public String? DogOrCat { get; set; }
}

