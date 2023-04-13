using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;
public class Book
{
    public int Id { get; set; }
	[Display(Name = "ISBN")]
	public string Isbn { get; set; }
    public string Title { get; set; }
    [MaxLength(4), MinLength(4, ErrorMessage = "Contoh inputan : 1999/2023")]
    [Required(ErrorMessage = "Tidak Boleh Kosong, Contoh inputan : 1999/2023")]
	[Display(Name = "Release Year")]
	public string ReleaseYear { get; set; }
    public string Synopsis { get; set; }
	[Display(Name = "Page Number")]
	public int PageNumber { get; set; }
    public string Genre { get; set; }
	[Display(Name = "Picture")]
	public string? PictureUrl { get; set; }
	[Display(Name = "Tokopedia")]
	public string? TokopediaUrl { get; set; }
	[Display(Name = "Shopee")]
	public string? ShopeeUrl { get; set; }
	[Display(Name = "Lazada")]
	public string? LazadaUrl { get; set; }
	public decimal? Rating { get; set; }
	public int PublisherId { get; set; }
    public int AuthorId { get; set; }
    public int LanguageId { get; set; }
}
