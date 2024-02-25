namespace Comments.Models.ViewModels
{
    public class AllCommentsViewModel
    {
        public AllCommentsViewModel(int id, string text, string date, string author)
        {
            Id = id;
            Text = text;
            Date = date;
            Author = author;
        }
        public int Id { get; set; }

        public string Text { get; set; }

        public string Date { get; set; }

        public string Author { get; set; }
    }
}
