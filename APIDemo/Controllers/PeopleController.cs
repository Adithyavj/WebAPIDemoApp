using APIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIDemo.Controllers
{
    /// <summary>
    /// This is where we give all the information about people
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Adithya", LastName = "Vijay", Id = 1 });
            people.Add(new Person { FirstName = "Arjun", LastName = "TT", Id = 2 });
            people.Add(new Person { FirstName = "Vishnu", LastName = "K", Id = 3 });
        }

        /// <summary>
        /// Gets a list of the FirstNames of all users
        /// </summary>
        /// <param name="UserId">The Unique identifier for this person</param>
        /// <param name="age">Age of this person</param>
        /// <returns>A List of FirstNames</returns>
        // Adding a custom Route..
        [Route("api/People/GetFirstNames/{UserId:int}/{Age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int UserId,int age)
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }

        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            // We use lambda expression here for - person.id==id that is passed in get command.
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        // PUT: api/People/5
        public void Put(int id, Person person)
        {
            people[id] = person;
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            people.RemoveAt(id);
        }
    }
}
