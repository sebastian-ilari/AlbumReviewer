using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using AlbumReviewerBackend.Interfaces;
using AlbumReviewerBackend.Models;

namespace AlbumReviewerBackend.Services
{
    [AspNetCompatibilityRequirements
    (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PersonService : IPersonService
    {
        List<Person> persons = new List<Person>() {
                new Person {
                    ID = 1,
                    Name = "Seba",
                    Age = "32",
                },
                new Person {
                    ID = 2,
                    Name = "Ceci",
                    Age = "34",
                },
            };
        int personCount = 0;

        public Person CreatePerson(Person createPerson)
        {
            createPerson.ID = ++personCount;
            persons.Add(createPerson);
            return createPerson;
        }

        public List<Person> GetAllPerson()
        {
            return persons.ToList();
        }

        public Stream GetAllPersonJSON()
        {
            string json = JsonConvert.SerializeObject(persons);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));            
        }

        public Person GetAPerson(string id)
        {
            return persons.FirstOrDefault(e => e.ID.ToString().Equals(id));
        }

        public Person UpdatePerson(string id, Person updatePerson)
        {
            Person p = persons.FirstOrDefault(e => e.ID.Equals(id));
            p.Name = updatePerson.Name;
            p.Age = updatePerson.Age;
            return p;
        }

        public void DeletePerson(string id)
        {
            persons.RemoveAll(e => e.ID.Equals(id));
        }
    }
}