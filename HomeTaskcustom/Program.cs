namespace HomeTaskcustom
{
    public class Program
    {
        static void Main()
        {

            CustomList<int> list = new CustomList<int>();


            list.Add(10);
            list.Add(999);
            list.AddRange(new int[] { 20, 30, 40 });

            list.Insert(1, 555);
            list.InsertRange(3, new int[] { 100, 200, 300 });

            Console.WriteLine("Elementler:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Capacity: {list.Capacity}");

            var found = list.Find(30);
            Console.WriteLine($"Tapilan: {found}");

            list.Remove(555);
            list.RemoveAt(0);

            Console.WriteLine("Silinmeden sonra:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            list.Clear();
            Console.WriteLine($"Clear-dan sonra Count: {list.Count}");
        }
    }
}
