namespace BazaDanych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Api t = new Api();
            t.GetData("London").Wait();

        }
    }
}
