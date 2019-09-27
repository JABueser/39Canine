using canineProj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public class EFResultRepository : IResultRepository
    {
        private ApplicationDbContext context;
        public EFResultRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Result> Results => context.Results;

        public void SaveResult(Result result)
        {
            if (result.ResultID == 0)
            {
                context.Results.Add(result);
            }
            else
            {
                Result dbEntry = context.Results.FirstOrDefault(r => r.ResultID == result.ResultID);
                if (dbEntry != null)
                {
                    dbEntry.DogID = result.DogID;
                    dbEntry.BreedID = result.BreedID;
                    dbEntry.DrugSensitivity = result.DrugSensitivity;
                    dbEntry.Eyes = result.Eyes;
                    dbEntry.Heart = result.Heart;
                    dbEntry.Sex = result.Sex;
                    dbEntry.Rkey = result.Rkey;
                }
            }
            context.SaveChanges();
        }

        public Result DeleteResult(int resultID)
        {
            Result dbEntry = context.Results.FirstOrDefault(r => r.ResultID == resultID);
            if (dbEntry != null)
            {
                context.Results.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
