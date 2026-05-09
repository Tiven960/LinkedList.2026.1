using double_list;
using System.ComponentModel.Design;

var list = new DoublyLinkedList<string>();

var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();

    switch (option)
    {
        case "1":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;

            list.Add(value);

            Console.WriteLine("Value added in ascending order.");
            break;

        case "2":
            Console.WriteLine("List forward:");
            list.ShowForward();
            break;

        case "3":
            Console.WriteLine("List backward:");
            list.ShowBackward();
            break;

        case "4":
            list.SortDescending();

            Console.WriteLine("List sorted descending.");
            break;

        case "5":
            list.ShowModes();
            break;

        case "6":
            list.ShowGraph();
            break;

        case "7":
            Console.Write("Enter value to search: ");
            value = Console.ReadLine() ?? string.Empty;

            if (list.Exists(value))
            {
                Console.WriteLine($"'{value}' exists in the list.");
            }
            else
            {
                Console.WriteLine($"'{value}' does not exist.");
            }

            break;

        case "8":
            Console.Write("Enter value to remove: ");
            value = Console.ReadLine() ?? string.Empty;

            list.RemoveOne(value);

            Console.WriteLine("First occurrence removed.");
            break;

        case "9":
            Console.Write("Enter value to remove all occurrences: ");
            value = Console.ReadLine() ?? string.Empty;

            list.RemoveAll(value);

            Console.WriteLine("All occurrences removed.");
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }

} while (option != "0");

string Menu()
{
    Console.WriteLine("\n===== MENU =====");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");

    Console.Write("Enter your option: ");

    return Console.ReadLine() ?? string.Empty;
}