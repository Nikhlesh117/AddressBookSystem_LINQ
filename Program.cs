namespace AddressBookSystem_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Address Book System Using LINQ");

            ContactDataManager contactDataManager = new ContactDataManager();
            contactDataManager.RetrieveDataBasedOnCityorState("Vizag", "AP");



        }
    }
}