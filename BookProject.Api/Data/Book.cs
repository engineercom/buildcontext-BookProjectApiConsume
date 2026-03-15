namespace BookProject.Api.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public double Price { get; set; }
    }
}
