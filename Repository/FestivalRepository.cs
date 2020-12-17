using backendbrzina.Interfaces;
using backendbrzina.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace backendbrzina.Repository
{
    public class FestivalRepository : IDisposable, IFestivalRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Festival festival)
        {
            db.Festivals.Add(festival);
            db.SaveChanges();
        }

        public void Delete(Festival festival)
        {
            db.Festivals.Remove(festival);
            db.SaveChanges();
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

        public IEnumerable<Festival> GetAll()
        {
            return db.Festivals.Include(p => p.Place);
        }

        public Festival GetById(int id)
        {
            return db.Festivals.Include(p => p.Place).FirstOrDefault(g => g.Id == id);
        }

        
        public IEnumerable<Festival> GetSmallestTwo()
        {
            IEnumerable<Festival> festivals = GetAll();
            return festivals.OrderByDescending(o => o.Price).Take(2);
          
           //return db.Products.Include(p => p.Cathegory).OrderByDescending(o => o.Price).Take(2).AsEnumerable();
        }

        public void Update(Festival festival)
        {
            db.Entry(festival).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            
        }

    

        public IEnumerable<Festival> GetByCathegory(string catFilter)
        {
            
            IEnumerable<Festival> products = GetAll();
            return products.Where(p => p.Place.Name == catFilter);
           
        }
        public IEnumerable<Festival> GetBySize(int start, int end)
	{
            IEnumerable<Festival> result = GetAll();
            return result.Where(g => g.YearStart >= start && g.YearStart <= end);

        }

    
    }
}