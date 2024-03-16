using Microsoft.EntityFrameworkCore;

namespace CosmeticsManagement.JetEFTest.Contexts
{
    // Класс, устанавливающий контекст работы с БД.
    // Контекст позваляет обращатся к определенным таблицам в БД
    // Класс является обобщенным, чтобы можно было использовать созданные сущности в Entities
    public class Context<T> : DbContext where T : class
    {
        // В качестве контейнера(списка), куда будут загружаться данные из БД
        // Используется ссылка DbSet с обобщенным типом
        public DbSet<T> DataContainer { get; set; }                

        // Переопределенный метод OnConfiguring позволяет установить подключение к базе данных
        // Строка подключения существует в классе ConnectionHelper.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConnectionHelper.ConnectionString;

            // UseJet() - метод, позволяющий использовать Jet-провайдер для работы с базой MS Access и Entity Framework Core.
            optionsBuilder.UseJet(connectionString);
        }
    }
}
