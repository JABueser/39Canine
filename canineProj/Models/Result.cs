using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public int DogID { get; set; }
        public int BreedID { get; set; }
        public string Sex { get; set; }
        public string DrugSensitivity { get; set; }
        public string Eyes { get; set; }
        public string Heart { get; set; }
        public int Rkey { get; set; }
    }
}
