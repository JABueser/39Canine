using canineProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public class EFDogRepository : IDogRepository
    {
        private ApplicationDbContext context;
        public EFDogRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Dog> Dogs => context.Dogs;

        public void SaveDog(Dog dog)
        {
            if (dog.DogID == 0)
            {
                context.Dogs.Add(dog);
            }
            else
            {
                Dog dbEntry = context.Dogs.FirstOrDefault(d => d.DogID == dog.DogID);
                if (dbEntry != null)
                {
                    dbEntry.AccountID = dog.AccountID;
                    dbEntry.Name = dog.Name;
                    dbEntry.Rkey = dog.Rkey;
                }
            }
            context.SaveChanges();
        }
        public Dog DeleteDog(int dogID)
        {
            Dog dbEntry = context.Dogs.FirstOrDefault(d => d.DogID == dogID);
            if (dbEntry != null)
            {
                context.Dogs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
