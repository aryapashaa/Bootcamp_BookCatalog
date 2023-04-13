using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models;
public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    [MaxLength(4), MinLength(4, ErrorMessage = "Contoh inputan : 1999/2023")]
    [Required(ErrorMessage = "Tidak Boleh Kosong, Contoh inputan : 1999/2023")]
    public string ReleaseYear { get; set; }
    public string Synopsis { get; set; }
    public int PageNumber { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    public string? PictureUrl { get; set; }
	public string? TokopediaUrl { get; set; }
	public string? ShopeeUrl { get; set; }
	public string? LazadaUrl { get; set; }
	public decimal? Rating { get; set; }
	public int PublisherId { get; set; }
    public int AuthorId { get; set; }
    public int LanguageId { get; set; }
}
