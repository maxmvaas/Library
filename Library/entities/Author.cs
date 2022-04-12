namespace Library.entities
{
    internal class Author
    {
        private int id; // auto-generate
        private string name;
        private string surname;
        private string birthday;
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public Author(string name, string surname, string birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }
    }
}