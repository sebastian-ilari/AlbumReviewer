using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using AlbumReviewerBackend.Models;

namespace AlbumReviewerBackend.Interfaces
{
    [ServiceContract]
    public interface IPersonService
    {
        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        Person CreatePerson(Person createPerson);

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "GetAllPerson")]
        List<Person> GetAllPerson();
        [OperationContract]
        [WebGet(UriTemplate = "GetAllPersonJSON")]
        Stream GetAllPersonJSON();
        [OperationContract]
        [WebGet(UriTemplate = "GetAPerson/{id}")]
        Person GetAPerson(string id);

        //PUT Operation
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        Person UpdatePerson(string id, Person updatePerson);

        //DELETE Operation
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void DeletePerson(string id);
    }
}