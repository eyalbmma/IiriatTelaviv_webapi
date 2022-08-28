using DomainIriatTelaviv.BaseRepository.Interfaces;
using DomainIriatTelaviv.Interfaces;
using DomainIriatTelaviv.Res_Req.Requests;
using DomainIriatTelaviv.Res_Req.Responses;
using DomainIriatTelaviv.Storedprocedures.Constants;
using DomainIriatTelaviv.Storedprocedures.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Classes
{
    public class generalService: IgeneralService
    {
        public static List<IssRequests> DBissList = new List<IssRequests>();

        public readonly IRepository<TelAvivContext> repository;
        public generalService(IRepository<TelAvivContext> repository)
        {
            this.repository = repository;
        }
        public List<TestTableResponse> GetTestdataResponseById(int? id)
        {
            try
            {
                
                var Id = new { Id = id };
                var res = repository.ExecuteGetSP<TestTableResponse>(ConstTelavivStoredProcedure.SP_GetTestData, Id);
                if (res != null)
                {
                    return res.ToList();
                }
                else
                    return null;




            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public List<IssRequests> AddLocationTolist(IssRequests req)
        {
            try
            {
                DBissList.Add(req);
                return DBissList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IssResponse GetIssResponse()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("http://api.open-notify.org/iss-now.json").Result;  // Blocking call!  
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                    Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                    // Get the response
                    var IssResponseJsonString = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine("Your response data is: " + IssResponseJsonString);

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    var deserialized = JsonConvert.DeserializeObject<IssResponse>(IssResponseJsonString);
                    // Do something with it
                    return deserialized;
                }
                else
                    return null;





            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }




}
