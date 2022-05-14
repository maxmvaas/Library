using System;
using System.Windows.Forms;
using Library.entities;
using Library.dal;

namespace Library
{
    public partial class Main : Form
    {
        private readonly DatabaseRepositoryImpl _databaseRepository = new DatabaseRepositoryImpl();

        private const string DateFormat = "dd. MM. yyyy";

        public Main()
        {
            InitializeComponent();

            dataGridViewBooks.DataSource = _databaseRepository.LoadBooks();
            dataGridViewBooks.Columns["id"].HeaderText = "ID";
            dataGridViewBooks.Columns["title"].HeaderText = "Название";
            dataGridViewBooks.Columns["pagesCount"].HeaderText = "Количество страниц";
            dataGridViewBooks.Columns["publisher"].HeaderText = "Издательство";
            dataGridViewBooks.Columns["publicationTime"].HeaderText = "Дата публикации";
            dataGridViewBooks.Columns["creationTime"].HeaderText = "Дата создания";

            dataGridViewAuthors.DataSource = _databaseRepository.LoadAuthors();
            dataGridViewAuthors.Columns["id"].HeaderText = "ID";
            dataGridViewAuthors.Columns["name"].HeaderText = "Имя автора";
            dataGridViewAuthors.Columns["surname"].HeaderText = "Фамилия автора";
            dataGridViewAuthors.Columns["birthday"].HeaderText = "Дата рождения";
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            var title = textBoxTitle.Text;
            var pagesCount = numericUpDownPages.Value;
            var publisher = textBoxPublisher.Text;
            var publicationTime = dateTimePickerPublish.Value; //.Value.ToString(DateFormat);
            var creationTime = dateTimePickerCreation.Value; //.Value.ToString(DateFormat);
            if (!ValidateBook(title))
            {
                MessageBox.Show("Некорректное название книги!");
            }
            else
            {
                if (!ValidatePageCount(pagesCount))
                {
                    MessageBox.Show("Некорректное кол-во страниц книги (не может быть меньше или равно 0)!");
                }
                else
                {
                    if (!ValidateBookDates(creationTime, publicationTime))
                    {
                        MessageBox.Show("Книга не может быть выпущена раньше, чем она была создана!");
                    }
                    else
                    {
                        _databaseRepository.Add(new Book(title, decimal.ToInt32(pagesCount), publisher,
                            publicationTime.ToString(DateFormat),
                            creationTime.ToString(DateFormat)));
                        dataGridViewBooks.DataSource = _databaseRepository.LoadBooks();
                    }
                }
            }
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var surname = textBoxSurname.Text;
            var birthday = dateTimePickerBirthday.Value;
            if (!ValidateDate(birthday))
            {
                MessageBox.Show("Некорректная дата рождения автора!");
            }
            else
            {
                if (!ValidateAuthor(name))
                {
                    MessageBox.Show("Некорректное имя автора!");
                }
                else
                {
                    _databaseRepository.Add(new Author(name, surname, birthday.ToString(DateFormat)));
                    dataGridViewAuthors.DataSource = _databaseRepository.LoadAuthors();
                }
            }
        }

        private void buttonClearAuthors_Click(object sender, EventArgs e)
        {
            _databaseRepository.Clear(Tables.Authors);
            dataGridViewAuthors.DataSource = _databaseRepository.LoadAuthors();
        }

        private void buttonClearBooks_Click(object sender, EventArgs e)
        {
            _databaseRepository.Clear(Tables.Books);
            dataGridViewBooks.DataSource = _databaseRepository.LoadBooks();
        }

        public static bool ValidateDate(DateTime date)
        {
            return date <= DateTime.Today;
        }

        public static bool ValidatePageCount(decimal pages)
        {
            return pages >= 1;
        }

        public static bool ValidateBookDates(DateTime creation, DateTime publish)
        {
            return creation < publish;
        }

        public static bool ValidateBook(string title)
        {
            return title.Length != 0;
        }

        public static bool ValidateAuthor(string name)
        {
            return name.Length != 0;
        }
    }
}