using System.ComponentModel.DataAnnotations;

namespace Client.Models;
public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
	[Display(Name = "Website")]
	public string? Url { get; set; }
}
