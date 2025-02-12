﻿namespace Zigzag.Library.API.Controllers.Features.Books.Dtos;

public class BooksDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public DateOnly PublishedDate { get; set; }
}
