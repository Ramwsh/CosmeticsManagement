namespace CosmeticsManagement.JetEFTest.CRUD
{
    // интерфейс для реализации поведения Controller.cs класса
    // Используются обобщенные типы, для простой задачи контекста Context.
    interface ICrudController<T>
    {
        public void Create(T model);
        public List<T> Read();
        public void Update(int targetIdValue, T updatedModel);
        public void Delete(T model);
    }
}
