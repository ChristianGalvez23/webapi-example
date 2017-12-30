using System.Collections.Generic;

namespace EventsPlace.Persistence.Interfaces {
    public interface IRepository<T> {
        void Insert (T entity);
        void Update (T product);
        void Delete (int id);
        List<T> SelectAll ();
    }
}