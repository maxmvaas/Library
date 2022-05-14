namespace Library.entities
{
    public class Book
    {
        private int id; // auto-generate
        private string title;
        private int pagesCount;
        private string publisher;
        private string publicationTime;
        private string creationTime;

        public Book(string title, int pagesCount, string publisher, string publicationTime, string creationTime)
        {
            Title = title;
            PagesCount = pagesCount;
            Publisher = publisher;
            PublicationTime = publicationTime;
            CreationTime = creationTime;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public int PagesCount
        {
            get => pagesCount;
            set => pagesCount = value;
        }

        public string Publisher
        {
            get => publisher;
            set => publisher = value;
        }

        public string PublicationTime
        {
            get => publicationTime;
            set => publicationTime = value;
        }

        public string CreationTime
        {
            get => creationTime;
            set => creationTime = value;
        }
    }
}