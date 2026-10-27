namespace LibraryApp
{
    /// <summary>
    /// Базовое исключение для ошибок библиотеки.
    /// </summary>
    public class LibraryException : Exception
    {
        public LibraryException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Книга с указанным Id не найдена.
    /// </summary>
    public class BookNotFoundException : LibraryException
    {
        public BookNotFoundException(int id)
            : base($"Книга с id {id} не найдена")
        {
        }
    }

    /// <summary>
    /// Книга уже выдана и не может быть выдана повторно.
    /// </summary>
    public class BookUnavailableException : LibraryException
    {
        public BookUnavailableException(string title)
            : base($"Книги \"{title}\" нет в наличии, так как она уже выдана")
        {
        }
    }

    /// <summary>
    /// Попытка вернуть книгу, которая не выдавалась.
    /// </summary>
    public class BookNotBorrowedException : LibraryException
    {
        public BookNotBorrowedException(string title)
            : base($"Книга \"{title}\" не может быть возвращена, так как она не была выдана")
        {
        }
    }
}