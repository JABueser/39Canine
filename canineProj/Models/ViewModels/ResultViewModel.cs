using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models.ViewModels
{
    public class ResultViewModel
    {
        public Result result { get; set; }
        public Breed breed { get; set; }
        public Dog dog { get; set; }
    }
}