using CosmeticsManagement.JetEFTest.Contexts;

// Реализация Controller класса, при помощи которого можно выполнять CRUD операции в программе.

namespace CosmeticsManagement.JetEFTest.CRUD
{

    // Класс обобщенного типа. Обобщение здесь позволяет легко задать контекст работы с БД, указав соответствующий тип (класс).
    // Класс == таблица БД.

    public class Controller<T> : ICrudController<T> where T : class
    {        
        public void Create(T model)
        {
            using (Context<T> context = new Context<T>())
            {
                if (model != null)
                {
                    context.DataContainer.Add(model);
                    context.SaveChanges();                    
                }
            }
        }

        public void Delete(T model)
        {
            using (Context<T> context = new Context<T>())
            {
                if (model != null)
                {
                    context.DataContainer.Remove(model);
                    context.SaveChanges();
                }
            }
        }

        public List<T> Read()
        {
            using (Context<T> context = new Context<T>())
            {
                return context.DataContainer.ToList();
            }
        }


        // Так как мы используем обобщенные типы, то мы не можем явно указывать свойства, характеризующие Id объекта
        // Однако мы можем получить Id объекта, обратившись при вызове метода
        // Поэтому мы первым параметром передаем Id объекта, а затем обновленную модель объекта, которым заменяем целевой объект, 
        // методом удаления его старой копии, и замещением новой с новыми указанными свойствами

        public void Update(int targetIdValue, T updatedModel)
        {
            if (updatedModel != null)
            {                
                using (Context<T> context = new Context<T>())
                {
                    var targetModel = context.DataContainer.Find(targetIdValue);
                    if (targetModel != null)
                    {
                        context.DataContainer.Remove(targetModel);
                        context.DataContainer.Add(updatedModel);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
