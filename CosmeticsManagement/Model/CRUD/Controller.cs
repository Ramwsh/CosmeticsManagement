using CosmeticsManagement.Model.Contexts;

namespace CosmeticsManagement.Model.CRUD
{
    public class Controller<T> : ICrudController<T> where T : class
    {
        public void Create(T model)
        {
            if (model != null)
            {
                using (Context<T> context = new Context<T>())
                {
                    context.DataContainer.Add(model);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(T model)
        {
            if (model != null)
            {
                using (Context<T> context = new Context<T>())
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
