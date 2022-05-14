using Library.entities;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using Dapper;

namespace Library.dal
{
    internal class DatabaseRepositoryImpl : IDatabaseRepository
    {
        private static readonly IDbConnection Database = new SQLiteConnection(LoadConnectionString());

        public DataTable LoadBooks()
        {
            var dt = new DataTable();
            var command = new SQLiteCommand("SELECT * FROM Books", (SQLiteConnection)Database);
            var adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable LoadAuthors()
        {
            var dt = new DataTable();
            var command = new SQLiteCommand("SELECT * FROM Authors", (SQLiteConnection)Database);
            var adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public void Add(Book book)
        {
            Database.Execute(
                "INSERT INTO Books (title, pagesCount, publisher, publicationTime, creationTime) values (@title, @pagesCount, @publisher, @publicationTime, @creationTime) ",
                book);
        }

        public void Add(Author author)
        {
            Database.Execute(
                "INSERT INTO Authors (name, surname, birthday) values (@name, @surname, @birthday) ", author);
        }

        public void Clear(Tables choice)
        {
            if (choice == 0)
            {
                Database.Execute("DELETE FROM Books");
                Database.Execute("DELETE FROM sqlite_sequence WHERE name = 'Books'");
            }
            else
            {
                Database.Execute("DELETE FROM Authors");
                Database.Execute("DELETE FROM sqlite_sequence WHERE name = 'Authors'");
            }
        }

        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}