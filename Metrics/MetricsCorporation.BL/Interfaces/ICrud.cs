using System.Collections.Generic;

namespace MetricsCorporation.BL.Interfaces
{
    public interface ICrud<T> 
    {
        T Create(T value);
        void Update(T value);
        void Delete(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllById(int id);
        T Get(long id);
    }
}
