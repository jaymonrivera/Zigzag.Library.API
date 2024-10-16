namespace Zigzag.Library.API.Controllers.Features.Books.Dtos;

public class BookParamDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public DateTime PublishedDate { get; set; }
}
