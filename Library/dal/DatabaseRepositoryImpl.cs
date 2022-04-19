using Library.entities;

using System.Data;
using System.Data.SQLite;
using System.Configuration;

using Dapper;

namespace Library.dal
{
    internal class DatabaseRepositoryImpl : IDatabaseRepository
    {
        private static IDbConnection database = new SQLiteConnection(LoadConnectionString());

        public DataTable LoadBooks()
        {
            DataTable dt = new DataTable();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books", (SQLiteConnection) database);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable LoadAuthors()
        {
            DataTable dt = new DataTable();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Authors", (SQLiteConnection) database);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public void Add(Book book)
        {
            database.Execute(
                "INSERT INTO Books (title, pagesCount, publisher, publicationTime, creationTime) values (@title, @pagesCount, @publisher, @publicationTime, @creationTime) ",
                book);
        }

        public void Add(Author author)
        {
            database.Execute(
                "INSERT INTO Authors (name, surname, birthday) values (@name, @surname, @birthday) ", author);
        }

        public void Clear(Tables choice)
        {
            if (choice == 0)
            {
                database.Execute("DELETE FROM Books");
                database.Execute("DELETE FROM sqlite_sequence WHERE name = 'Books'");
            }
            else
            {
                database.Execute("DELETE FROM Authors");
                database.Execute("DELETE FROM sqlite_sequence WHERE name = 'Authors'");
            }
        }

        private static string LoadConnectionString(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}