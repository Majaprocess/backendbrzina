using backendbrzina.Interfaces;
using backendbrzina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backendbrzina.Controllers
{
    public class FestivalController : ApiController
    {

     
        IFestivalRepository _repository { get; set; }

        public FestivalController(IFestivalRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Festival> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var festival = _repository.GetById(id);
            if (festival == null)
            {
                return NotFound();
            }
            return Ok(festival);
        }

        // GET api/gradovi?start=1000000&end=2000000
        public IEnumerable<Festival> GetBySize(int start, int end)
        {
            return _repository.GetBySize(start, end);
        }

        

        public IHttpActionResult Post(Festival festival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(festival);
            return CreatedAtRoute("DefaultApi", new { id = festival.Id }, festival);
        }
        public IHttpActionResult PostGitproba(Festival festival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(festival);
            return CreatedAtRoute("DefaultApi", new { id = festival.Id }, festival);
        }


        public IHttpActionResult Put(int id, Festival festival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != festival.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(festival);
            }
            catch
            {
                throw;
            }

            return Ok(festival);
        }

        public IHttpActionResult Delete(int id)
        {
            var festival = _repository.GetById(id);
            if (festival == null)
            {
                return NotFound();
            }

            _repository.Delete(festival);
            return Ok();
        }

        //new line
        //secondline
        //third line
        //vkjfdhszkfs'l;dJgakhgkhskljdfhgjlehtrkjhsklgtjireahgkndkjfoeikwaujroiuiuawu;'k['
        [Route("api/SmallestTwo")]
        public IEnumerable<Festival> GetSmallestTwo()
        {
           
            return _repository.GetSmallestTwo();

            //return db.Products.Include(p => p.Cathegory).OrderByDescending(o => o.Price).Take(2).AsEnumerable();
        }

       

        public IEnumerable<Festival> GetByCathegory(string catFilter)
        {

            return _repository.GetByCathegory(catFilter);

        }
        
    }
}
