using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressPcArızaTakip.Models.viewmodel
{
    public class ProblemViewModel
    {
        public string Companies { get; set; }
        public string ProblemReason { get; set; }
        public string ProblemSituation { get; set; }
        public string Users { get; set; }
        public string ProblemDetails { get; set; }  
        public int Id { get; set; }  
        public int ProblemUserId { get; set; }
        public int ProblemReasonId { get; set; }
        public int ProblemSituationId { get; set; }
        public int ProblemCompanyId { get; set; }

            


    }
}