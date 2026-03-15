namespace BookProject.WebUI.Dtos;

public class EditBookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public double Price { get; set; }
}
