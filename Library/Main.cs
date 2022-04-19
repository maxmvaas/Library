using System;
using System.Windows.Forms;

using Library.entities;
using Library.dal;

namespace Library
{
    public partial class Main : Form
    {

        DatabaseRepositoryImpl databaseRepository = new DatabaseRepositoryImpl();

        public const string dateFormat = "dd. MM. yyyy";

        public Main()
        {
            InitializeComponent();      

            dataGridViewBooks.DataSource = databaseRepository.LoadBooks();
            dataGridViewBooks.Columns["id"].HeaderText = "ID";
            dataGridViewBooks.Columns["title"].HeaderText = "Название";
            dataGridViewBooks.Columns["pagesCount"].HeaderText = "Количество страниц";
            dataGridViewBooks.Columns["publisher"].HeaderText = "Издательство";
            dataGridViewBooks.Columns["publicationTime"].HeaderText = "Дата публикации";
            dataGridViewBooks.Columns["creationTime"].HeaderText = "Дата создания";

            dataGridViewAuthors.DataSource = databaseRepository.LoadAuthors();
            dataGridViewAuthors.Columns["id"].HeaderText= "ID";
            dataGridViewAuthors.Columns["name"].HeaderText = "Имя автора";
            dataGridViewAuthors.Columns["surname"].HeaderText = "Фамилия автора";
            dataGridViewAuthors.Columns["birthday"].HeaderText = "Дата рождения";
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            decimal pagesCount = numericUpDownPages.Value;
            string publisher = textBoxPublisher.Text;
            string publicationTime = dateTimePickerPublish.Value.ToString(dateFormat);
            string creationTime = dateTimePickerCreation.Value.ToString(dateFormat);
            databaseRepository.Add(new Book(title, decimal.ToInt32(pagesCount), publisher, publicationTime, creationTime));
            dataGridViewBooks.DataSource = databaseRepository.LoadBooks();
        }
        
        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string birthday = dateTimePickerBirthday.Value.ToString(dateFormat);
            databaseRepository.Add(new Author(name, surname, birthday));
            dataGridViewAuthors.DataSource = databaseRepository.LoadAuthors();
        }
        private void buttonClearAuthors_Click(object sender, EventArgs e)
        {
            databaseRepository.Clear(Tables.AUTHORS);
            dataGridViewAuthors.DataSource = databaseRepository.LoadAuthors();
        }

        private void buttonClearBooks_Click(object sender, EventArgs e)
        {
            databaseRepository.Clear(Tables.BOOKS);
            dataGridViewBooks.DataSource = databaseRepository.LoadBooks();
        }
    }
}
