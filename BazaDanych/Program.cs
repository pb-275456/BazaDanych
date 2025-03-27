namespace BazaDanych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestApi t = new TestApi();
            t.GetData().Wait();
        }
    }
}
