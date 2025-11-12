namespace HomeTaskcustom
{
    public class Program
    {
        static void Main()
        {

            CustomList list = new CustomList();


            list.Add(10);
            list.Add("Salam");
            list.AddRange(new object[] { 20, 30, 40 });

            list.Insert(1, 999);
            list.InsertRange(3, new object[] { "A", "B", "C" });

            Console.WriteLine("Elementler");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("Capacity: " + list.Capacity);

            object found = list.Find("C");
            Console.WriteLine("Tapilan: " + found);

            list.Remove(999);
            list.RemoveAt(0);

            Console.WriteLine("Silinmeden sonra:");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            list.Clear();
            Console.WriteLine("Clear dan sonra Count: " + list.Count);
        }
    }
}
