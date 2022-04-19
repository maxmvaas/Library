using Library.entities;
using System.Data;

namespace Library.dal
{

    public enum Tables : byte
    {
        BOOKS = 0,
        AUTHORS = 1
    }

    internal interface IDatabaseRepository
    {
        DataTable LoadBooks();

        DataTable LoadAuthors();

        void Add(Book book);

        void Add(Author author);

        void Clear(Tables choice);

    }
}
