using DomainIriatTelaviv.Res_Req.Requests;
using DomainIriatTelaviv.Res_Req.Responses;
using DomainIriatTelaviv.Storedprocedures.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Interfaces
{
    public interface IgeneralService
    {
       public List<TestTableResponse> GetTestdataResponseById(int? id);

        public IssResponse GetIssResponse();

        public List<IssRequests> AddLocationTolist(IssRequests req);

    }
}
