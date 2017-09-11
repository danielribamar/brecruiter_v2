using System.Collections.Generic;

namespace BRecruiter.Web.Core.Models
{
    public class Candidate
    {
        public Candidate()
        {

        }
        public Candidate(int id)
        {
            Id = id;
            Languages = new List<string>();
            Tools = new List<string>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Wage { get; set; }
        public int Experience { get; set; }
        public bool Available { get; set; }
        public string Observations { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Tools { get; set; }
    }
}
