using System.Text.Json;
namespace ExtensionForMyEnumerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var users = new List<Users>();

            for (int i = 1; i < 10; i++)
            {
                users.Add(new Users { Age = i });
            }

            var selectedNumbers = numbers.Top(30);

            Console.WriteLine(JsonSerializer.Serialize(selectedNumbers));

            var selectedUsers = users.Top(30, person => person.Age);
            Console.WriteLine(JsonSerializer.Serialize(selectedUsers));
        }
    }
}
