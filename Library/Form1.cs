using System;
using System.Windows.Forms;
using Library.entities;
using Library.dal;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridViewBooks.DataSource = databaseRepository.LoadBooks();
            dataGridViewAuthors.DataSource = databaseRepository.LoadAuthors();
        }

        DatabaseRepositoryImpl databaseRepository = new DatabaseRepositoryImpl();

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            string pagesCount = textBoxPagesCount.Text;
            string publisher = textBoxPublisher.Text;
            string publicationTime = textBoxPublicationTime.Text;
            string creationTime = textBoxCreationTime.Text;
            databaseRepository.Add(new Book(title, int.Parse(pagesCount), publisher, publicationTime, creationTime));
            dataGridViewBooks.DataSource = databaseRepository.LoadBooks();
        }
        
        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string birthday = textBoxBirthday.Text;
            databaseRepository.Add(new Author(name, surname, birthday));
            dataGridViewAuthors.DataSource = databaseRepository.LoadAuthors();
        }

    }
}
