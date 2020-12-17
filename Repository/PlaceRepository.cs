using backendbrzina.Interfaces;
using backendbrzina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace backendbrzina.Repository
{
    public class PlaceRepository: IDisposable, IPlaceRepository
    {
      private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Place>  GetAll()
        {
            return db.Places;
        }

        public Place GetById(int id)
        {
            return db.Places.FirstOrDefault(g => g.Id == id);
        }
        public IEnumerable<Place> GetAllByPC(int postcode)
        {
            IEnumerable<Place> list = GetAll();
            return list.Where(p => p.PostalCode < postcode);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    };
}