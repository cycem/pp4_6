

namespace LibraryApp
{
    /// <summary>
    /// Точка входа: демонстрирует работу библиотеки и обработку ошибок.
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            var library = new Library();
            AddInitialBooks(library);

            Console.WriteLine("\nВыдача");
            Run(() => BorrowAndReport(library, 1));
            Run(() => BorrowAndReport(library, 1));
            Run(() => BorrowAndReport(library, 99));

            Console.WriteLine("\nВозврат");
            Run(() => ReturnAndReport(library, 1));
            Run(() => ReturnAndReport(library, 2));
            Run(() => ReturnAndReport(library, 99));

            Console.WriteLine("\nПоиск");
            Run(() => PrintBook(library, 2));
            Run(() => PrintBook(library, 99));

            Console.WriteLine("\nНажмите Enter для выхода");
            Console.ReadLine();
        }

        /// <summary>
        /// Добавляет стартовый набор книг.
        /// </summary>
        private static void AddInitialBooks(Library library)
        {

            library.AddBook(new Book(1, "Война и мир", "Л. Толстой"));
            library.AddBook(new Book(2, "Учебник по информатике 9 класс", "Ю. Поляков"));
            library.AddBook(new Book(3, "Басни", "И. Крылов"));

        }

        /// <summary>
        /// Выдаёт книгу и выводит результат.
        /// </summary>
        private static void BorrowAndReport(Library library, int id)
        {
            Book book = library.BorrowBook(id);
            Console.WriteLine($"Книга \"{book.Title}\" выдана");
        }

        /// <summary>
        /// Возвращает книгу и выводит результат.
        /// </summary>
        private static void ReturnAndReport(Library library, int id)
        {
            Book book = library.ReturnBook(id);
            Console.WriteLine($"Книга \"{book.Title}\" возвращена");
        }

        /// <summary>
        /// Выводит информацию о книге по Id.
        /// </summary>
        private static void PrintBook(Library library, int id)
        {
            Book book = library.FindBook(id) ?? throw new BookNotFoundException(id);
            string status = book.IsAvailable ? "да" : "нет";
            Console.WriteLine($"{book.Id}. \"{book.Title}\" — {book.Author}, доступна: {status}");
        }

        /// <summary>
        /// Выполняет действие и выводит понятное сообщение при ожидаемой ошибке.
        /// Неизвестные исключения намеренно не перехватываются, чтобы не скрывать баги.
        /// </summary>
        private static void Run(Action action)
        {
            try
            {
                action();
            }
            catch (LibraryException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Некорректные данные: {ex.Message}");
            }
        }
    }
}