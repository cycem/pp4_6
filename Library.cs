namespace LibraryApp
{
    /// <summary>
    /// Библиотека: хранит книги и управляет их выдачей и возвратом.
    /// Ошибки сообщаются исключениями, вывод на экран выполняет вызывающий код.
    /// </summary>
    public class Library
    {
        private readonly List<Book> _books = new List<Book>();

        /// <summary>
        /// Добавляет книгу в библиотеку.
        /// </summary>
        /// <param name="book">Книга для добавления.</param>
        public void AddBook(Book book)
        {
            ValidateNewBook(book);
            _books.Add(book);
        }

        /// <summary>
        /// Выдаёт книгу читателю.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <returns>Выданная книга.</returns>
        public Book BorrowBook(int id)
        {
            Book book = GetBookOrThrow(id);

            if (!book.IsAvailable)
            {
                throw new BookUnavailableException(book.Title);
            }

            book.IsAvailable = false;
            return book;
        }

        /// <summary>
        /// Принимает книгу обратно в библиотеку.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <returns>Возвращённая книга.</returns>
        public Book ReturnBook(int id)
        {
            Book book = GetBookOrThrow(id);

            if (book.IsAvailable)
            {
                throw new BookNotBorrowedException(book.Title);
            }

            book.IsAvailable = true;
            return book;
        }

        /// <summary>
        /// Ищет книгу по Id.
        /// </summary>
        /// <param name="id">Id книги.</param>
        /// <returns>Найденная книга или null, если её нет.</returns>
        public Book? FindBook(int id)
        {
            return _books.Find(b => b.Id == id);
        }

        /// <summary>
        /// Проверяет, что книгу можно добавить в библиотеку.
        /// </summary>
        private void ValidateNewBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (FindBook(book.Id) != null)
            {
                throw new ArgumentException($"Книга с id {book.Id} уже существует", nameof(book));
            }
        }

        /// <summary>
        /// Возвращает книгу по Id или выбрасывает исключение, если её нет.
        /// </summary>
        private Book GetBookOrThrow(int id)
        {
            return FindBook(id) ?? throw new BookNotFoundException(id);
        }
    }
}