using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models.ViewModels
{
    public class DogsPageViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }
    }
}