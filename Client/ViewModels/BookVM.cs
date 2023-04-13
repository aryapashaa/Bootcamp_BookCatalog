using System.ComponentModel.DataAnnotations;

namespace Client.ViewModels;

public class BookVM
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string ReleaseYear { get; set; }
    public string Synopsis { get; set; }
    public int PageNumber { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    public string? PictureUrl { get; set; }
    [Display(Name = "Publisher Name")]
    public string PublisherName { get; set; }
    [Display(Name = "Author Name")]
    public string AuthorName { get; set; }
    [Display(Name = "Language Name")]
    public string LanguageName { get; set; }
}
