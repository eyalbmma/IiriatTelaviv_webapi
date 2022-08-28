using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Res_Req.Responses
{
    public class IssResponse
    {
        public string timestamp { get; set; }
        public string message { get; set; }
        public iss_position iss_position{ get; set; }
}

    public class iss_position
    {
       public string longitude { get; set; }
        public string latitude { get; set; }


    }



}
