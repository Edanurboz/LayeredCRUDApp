using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class PersonDal : IPersonDal
    {
        public void Add(Person person)
        {
            using(var context = new Proje()) 
            {
                var addedEntity = context.Entry(person);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Delete(Person person)
        {
            using (var context = new Proje())
            {
                var personToDelete = context.Person.Find(person);
                if (personToDelete != null)
                {                    
                    context.Person.Remove(personToDelete);
                    context.SaveChanges();
                }
            }
        }
        public List<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Person> GetList()
        {
            using (var context = new Proje())
            {
                return context.Person.ToList();

            }
        }
        public void Update(Person person)
        {
            using (var context = new Proje())
            {
                var updatedEntity = context.Entry(person);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
