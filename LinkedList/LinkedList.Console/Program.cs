using SimpleList;
using System.ComponentModel.Design;

var List = new SinglyLinkedList<string>();
var option = string.Empty;
var value = string.Empty;
do 
{
    option = Menu();
    switch(option)
    {
        case "1":
            Console.WriteLine("Enter a value:  ");
            value = Console.ReadLine() ?? string.Empty;
            List.InsertAtBeginning(value);
            break;
        case "2":
            Console.WriteLine("Enter a value:  ");
            value = Console.ReadLine() ?? string.Empty;
            List.InsertAtEnding(value);
            break;
        case "3":
            Console.WriteLine("Enter a value:  ");
            value = Console.ReadLine() ?? string.Empty;
            var exists = List.Contains(value);
            if (exists)
            {
                Console.WriteLine($"Value '{value}' found in the list.");
            }
            else
            {
                Console.WriteLine($"Value '{value}' not found in the list.");
            }
            break;
        case "4":
            Console.WriteLine("Enter a value:  ");
            value = Console.ReadLine() ?? string.Empty;
            List.Remove(value);
            break;
        case "5":
            List.Reverse();
            break;
        case "6":
            Console.WriteLine(List);
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Inset at the beginning");
    Console.WriteLine("2. Inset at the ending");
    Console.WriteLine("3. Search for a value");
    Console.WriteLine("4. Remove a value");
    Console.WriteLine("5. Reverse List");
    Console.WriteLine("6. Show List");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}


