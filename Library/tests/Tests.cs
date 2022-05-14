using System;
using Xunit;

namespace Library.tests
{
    public class Tests
    {
        [Fact]
        public void ValidateValidDate()
        {
            Assert.True(Main.ValidateDate(new DateTime(2021, 5, 14)));
        }

        [Fact]
        public void ValidatePageCount()
        {
            Assert.True(Main.ValidatePageCount(3));
        }

        [Fact]
        public void ValidateBookDates()
        {
            Assert.True(Main.ValidateBookDates(new DateTime(2000, 11, 04), DateTime.Now));
        }

        [Fact]
        public void ValidateBook()
        {
            Assert.True(Main.ValidateBook("Title"));
        }

        [Fact]
        public void ValidateAuthor()
        {
            Assert.True(Main.ValidateAuthor("John"));
        }
    }
}