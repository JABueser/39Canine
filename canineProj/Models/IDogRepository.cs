using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public interface IDogRepository 
    {
        IEnumerable<Dog> Dogs { get; }

        void SaveDog(Dog dog);

        Dog DeleteDog(int dogID);
    }
}
