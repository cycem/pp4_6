using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    /// <summary>
    /// Класс, поисывающий свойства книги.
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book(int id, string title, string author)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Название не может быть пустым");
            }
            Id = id;
            Title = title;
            Author = author;
        }
    }
}
