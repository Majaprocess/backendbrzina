using backendbrzina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendbrzina.Interfaces
{
    public interface IFestivalRepository
    {
        void Add(Festival festival);

        void Delete(Festival festival);

        IEnumerable<Festival> GetAll();

      Festival GetById(int id);

        IEnumerable<Festival> GetSmallestTwo();

        void Update(Festival festival);

         IEnumerable<Festival> GetByCathegory(string catFilter);

         IEnumerable<Festival> GetBySize(int start, int end);
      
    }
}
