using System.Collections.Generic;

namespace BRecruiter.Web.Core.Models
{
    public class CandidatesViewModel
    {
        public List<Candidate> Candidates { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
