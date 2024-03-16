namespace CosmeticsManagement.JetEFTest
{
    // класс для хранения константы - строки подключения к БД. Используется в классе Context.
    public static class ConnectionHelper
    {
        public const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CosmeticsDb.mdb;";
    }
}
