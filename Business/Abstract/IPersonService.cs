using Business.DTO;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        List<PersonDto> GetAll();
        string Create(CreatePersonDto person);
        void Update(UpdatePersonDto person);
        void Delete(DeleteDto person);
        
    }
}
