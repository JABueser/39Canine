using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace canineProj.Models
{
    public interface IResultRepository
    {
        IEnumerable<Result> Results { get; }

        void SaveResult(Result result);

        Result DeleteResult(int resultID);
    }
}
