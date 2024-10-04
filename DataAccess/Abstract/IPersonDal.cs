using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IPersonDal
    {
        List<Person> GetList();
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
        List<Person> GetById(int id);
        
        
    }
}
