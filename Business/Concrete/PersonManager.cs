using Business.Abstract;
using Business.DTO;
using DataAccess.Abstract;
using Entities.Concrete;
using KPSPublicSoapClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }


        public string Create(CreatePersonDto person)
        {
            bool durum = false;
            var client = new KPSPublicSoapClient.KPSPublicSoapClient(KPSPublicSoapClient.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var result = client.TCKimlikNoDogrulaAsync(
            Convert.ToInt64(person.Tc), 
            person.Ad.ToUpper(),        
            person.Soyad.ToUpper(),     
            person.Dogumyili            
        ).Result;

            durum = result.Body.TCKimlikNoDogrulaResult;

            if (durum)
            {
                var newPerson = new Person();
                newPerson.ad = person.Ad;
                newPerson.soyad = person.Soyad;
                newPerson.mail = person.Mail;
                newPerson.tc = person.Tc;
                newPerson.dogumyili = person.Dogumyili;

                _personDal.Add(newPerson);
                return "Kişi Ekleme Başarılı";
            }
            return "Kişi Ekleme Başarısız Eklemeye Çalıştığınız Kişi TC Vatandaşı Değil.";
        }

        public void Delete(DeleteDto person)
        {
            var newPerson = new Person();
            newPerson.id = person.id;
        }

        public List<PersonDto> GetAll()
        {
            var person =  _personDal.GetList()??new List<Person>();
            var result = person.Select(a => new PersonDto()
            {
                id = a.id,
                Ad = a.ad,
                Soyad = a.soyad,
                Mail = a.mail,
                Tc = a.tc

        }).ToList();

            return result;
        }


        public void Update(UpdatePersonDto person)
        {
            var newPerson = new Person();
            newPerson.id = person.id;
            newPerson.ad = person.Ad;
            newPerson.soyad = person.Soyad;
            newPerson.mail = person.Mail;
            newPerson.tc = person.Tc;
            _personDal.Update(newPerson);
        }
    }
}
