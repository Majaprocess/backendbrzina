using backendbrzina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendbrzina.Interfaces
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAll();

        Place GetById(int id);

        IEnumerable<Place> GetAllByPC(int postcode);
    }
}
