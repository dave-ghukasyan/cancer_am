using System.Collections.Generic;

public interface IRepository <T>
{
    public T Get(int id);
    public void Update(T entity);
    public T Insert(T entity);

    public void Delete(int id);
}