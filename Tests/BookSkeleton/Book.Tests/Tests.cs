namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void NameAndAuthorExceptionAndValid()
        {
            Book book = null;
            Book book2 = null;

            Book book3 = new Book("Bobi", "Asen");
            Assert.AreEqual(book3.BookName, "Bobi");
            Assert.AreEqual(book3.Author, "Asen");

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("", "Asen");
            }, $"Invalid {nameof(book.BookName)}!");

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(null, "Asen");
            }, $"Invalid {nameof(book2.BookName)}!");

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("Asen", "");
            }, $"Invalid {nameof(book.Author)}!");

            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book("Asen", null);
            }, $"Invalid {nameof(book2.Author)}!");
        }

        [Test]
        public void AddFootnoteExceptionAndValid()
        {
            Book book = new Book("LittlePrice", "George");

            book.AddFootnote(1, "Asen");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Gosho");
            }, "Footnote already exists!");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteExceptionAndValid()
        {
            Book book = new Book("LittlePrice", "George");

            book.AddFootnote(1, "Asen");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2);
            }, "Footnote doesn't exists!");

            Assert.AreEqual($"Footnote #{1}: {"Asen"}", book.FindFootnote(1));
        }

        [Test]
        public void AlterFootnoteExceptionAndValid()
        {
            Book book = new Book("LittlePrice", "George");

            book.AddFootnote(1, "Asen");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "Asen");
            }, "Footnote does not exists!");

            book.AlterFootnote(1, "Masha");
            Assert.AreEqual($"Footnote #{1}: {"Masha"}", book.FindFootnote(1));
        }
    }
}