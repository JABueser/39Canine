using canineProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public class EFBreedRepository : IBreedRepository
    {
        private ApplicationDbContext context;

        public EFBreedRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Breed> Breeds => context.Breeds;

        public void SaveBreed(Breed breed)
        {
            if (breed.BreedID == 0)
            {
                context.Breeds.Add(breed);
            }
            else
            {
                Breed dbEntry = context.Breeds.FirstOrDefault(b => b.BreedID == breed.BreedID);
                if (dbEntry != null)
                {
                    dbEntry.ResultID = breed.ResultID;
                    dbEntry.Breed1 = breed.Breed1;
                    dbEntry.Breed1Percent = breed.Breed1Percent;
                    dbEntry.Breed2 = breed.Breed2;
                    dbEntry.Breed2Percent = breed.Breed2Percent;
                    dbEntry.Breed3 = breed.Breed3;
                    dbEntry.Breed3Percent = breed.Breed3Percent;
                    dbEntry.Breed4 = breed.Breed4;
                    dbEntry.Breed4Percent = breed.Breed4Percent;
                    dbEntry.Breed5 = breed.Breed5;
                    dbEntry.Breed5Percent = breed.Breed5Percent;
                    dbEntry.BreedID = breed.BreedID;
                    dbEntry.Rkey = breed.Rkey;
                }
            }
            context.SaveChanges();
        }

        public Breed DeleteBreed(int breedID)
        {
            Breed dbEntry = context.Breeds.FirstOrDefault(b => b.BreedID == breedID);
            if (dbEntry != null)
            {
                context.Breeds.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
