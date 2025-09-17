using System;

namespace ConsoleCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консольный календарь");
            ShowMenu();
        }

        // Функция 1: Показать меню
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1. Показать текущий месяц");
                Console.WriteLine("2. Показать конкретный месяц");
                Console.WriteLine("3. Перейти к конкретной дате");
                Console.WriteLine("4. Добавить событие");
                Console.WriteLine("5. Показать события на дату");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите опцию: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ShowCurrentMonth();
                            break;
                        case 2:
                            ShowSpecificMonth();
                            break;
                        case 3:
                            GoToSpecificDate();
                            break;
                        case 4:
                            AddEvent();
                            break;
                        case 5:
                            ShowEvents();
                            break;
                        case 6:
                            Console.WriteLine("До свидания!");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                }
            }
        }

        // Функция 2: Показать текущий месяц
        static void ShowCurrentMonth()
        {
            DateTime now = DateTime.Now;
            DisplayCalendar(now.Year, now.Month);
        }

        // Функция 3: Показать конкретный месяц
        static void ShowSpecificMonth()
        {
            Console.Write("Введите год: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Неверный формат года!");
                return;
            }

            Console.Write("Введите месяц (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12)
            {
                Console.WriteLine("Неверный формат месяца!");
                return;
            }

            DisplayCalendar(year, month);
        }

        // Функция 4: Перейти к конкретной дате
        static void GoToSpecificDate()
        {
            Console.Write("Введите дату (дд.мм.гггг): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine($"Выбранная дата: {date:dd.MM.yyyy}");
                Console.WriteLine($"День недели: {GetRussianDayOfWeek(date.DayOfWeek)}");
            }
            else
            {
                Console.WriteLine("Неверный формат даты!");
            }
        }

        // Функция 5: Добавить событие
        static void AddEvent()
        {
            Console.Write("Введите дату события (дд.мм.гггг): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime eventDate))
            {
                Console.WriteLine("Неверный формат даты!");
                return;
            }

            Console.Write("Введите описание события: ");
            string description = Console.ReadLine();

            // Здесь можно добавить сохранение в файл или базу данных
            Console.WriteLine($"Событие добавлено на {eventDate:dd.MM.yyyy}: {description}");
        }

        // Функция 6: Показать события (дополнительная)
        static void ShowEvents()
        {
            Console.Write("Введите дату для просмотра событий (дд.мм.гггг): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine($"События на {date:dd.MM.yyyy}:");
                // Здесь можно добавить загрузку из файла или базы данных
                Console.WriteLine("Пока нет событий для этой даты");
            }
            else
            {
                Console.WriteLine("Неверный формат даты!");
            }
        }

        // Вспомогательная функция: Отображение календаря
        static void DisplayCalendar(int year, int month)
        {
            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine($"\n{GetRussianMonthName(month)} {year}");
            Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");

            // Определяем день недели первого дня месяца
            int firstDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7; // Корректировка для понедельника

            // Печатаем пробелы для первых дней
            for (int i = 0; i < firstDayOfWeek; i++)
            {
                Console.Write("   ");
            }

            // Печатаем дни месяца
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day,2} ");
                if ((firstDayOfWeek + day) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        // Вспомогательная функция: Русское название месяца
        static string GetRussianMonthName(int month)
        {
            string[] months = {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };
            return months[month - 1];
        }

        // Вспомогательная функция: Русское название дня недели
        static string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            string[] days = {
                "Воскресенье", "Понедельник", "Вторник", "Среда",
                "Четверг", "Пятница", "Суббота"
            };
            return days[(int)dayOfWeek];
        }
    }
}