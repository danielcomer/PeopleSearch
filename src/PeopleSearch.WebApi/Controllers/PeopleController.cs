using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using PeopleSearch.WebApi.Data;
using PeopleSearch.WebApi.Data.Entities;

namespace PeopleSearch.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IDirectoryRepository _directoryRepository;

        public PeopleController(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _directoryRepository.GetAllPeople();
        }

        //[HttpGet("{personId:int}", Name = "GetPersonById")]
        public IActionResult GetPersonById(int personId)
        {
            var course = _directoryRepository.GetPerson(personId);

            if (course == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(course);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
                return new ObjectResult(new { Description = "Course model is invalid" });
            }
            else
            {
                var addedPerson = _directoryRepository.AddPerson(person);

                if (addedPerson != null)
                {
                    var url = Url.RouteUrl("GetPersonById", new { personId = person.Id }, Request.Scheme, Request.Host.ToUriComponent());

                    Context.Response.StatusCode = 201;
                    Context.Response.Headers["Location"] = url;
                    return new ObjectResult(addedPerson);
                }
                else
                {
                    Context.Response.StatusCode = 400;
                    return new ObjectResult(new { Description = "Failed to save person" });
                }
            }
        }

    }
}
