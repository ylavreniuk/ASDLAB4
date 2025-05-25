using System;
using System.Xml.Linq;

namespace DoublyLinkedListProject
{
    class Program
    {
        static void Main()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            while (true)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("1. Додати елемент");
                Console.WriteLine("2. Видалити елемент");
                Console.WriteLine("3. Пошук елемента");
                Console.WriteLine("4. Вивести список");
                Console.WriteLine("5. Вставити останній парний елемент після непарних (Завдання 1)");
                Console.WriteLine("6. Обчислити суму елементів >= 15 (Завдання 2)");
                Console.WriteLine("7. Вихід");
                Console.Write("Виберіть опцію (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть число (дійсне): ");
                        if (double.TryParse(Console.ReadLine(), out double valueToAdd))
                        {
                            list.Add(valueToAdd);
                            Console.WriteLine($"Елемент {valueToAdd} додано.");
                        }
                        else
                        {
                            Console.WriteLine("Невірне значення. Введіть дійсне число.");
                        }
                        break;

                    case "2":
                        Console.Write("Введіть число для видалення: ");
                        if (double.TryParse(Console.ReadLine(), out double valueToRemove))
                        {
                            if (list.Remove(valueToRemove))
                                Console.WriteLine($"Елемент {valueToRemove} видалено.");
                            else
                                Console.WriteLine($"Елемент {valueToRemove} не знайдено.");
                        }
                        else
                        {
                            Console.WriteLine("Невірне значення. Введіть дійсне число.");
                        }
                        break;

                    case "3":
                        Console.Write("Введіть число для пошуку: ");
                        if (double.TryParse(Console.ReadLine(), out double searchValue))
                        {
                            Node found = list.Search(searchValue);
                            if (found != null)
                                Console.WriteLine($"Елемент {searchValue} знайдено.");
                            else
                                Console.WriteLine($"Елемент {searchValue} не знайдено.");
                        }
                        else
                        {
                            Console.WriteLine("Невірне значення. Введіть дійсне число.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Поточний список:");
                        list.Print();
                        break;

                    case "5":
                        list.InsertLastEvenAfterOdd();
                        Console.WriteLine("Останній парний елемент вставлено після непарних.");
                        break;

                    case "6":
                        double sum = list.SumElementsGreaterOrEqual15();
                        Console.WriteLine($"Сума елементів >= 15: {sum}");
                        break;

                    case "7":
                        Console.WriteLine("Програма завершена.");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}