using Microsoft.AspNet.Mvc;
using PeopleSearch.WebApi.Data;

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
        public IActionResult Index()
        {
            return new ObjectResult(_directoryRepository.GetAllPeople());
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var person = _directoryRepository.GetPerson(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(person);
        }

        //[HttpPost]
        //public IActionResult Add([FromBody] Person person)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        Context.Response.StatusCode = 400;
        //        return new ObjectResult(new { Description = "Person model is invalid" });
        //    }

        //    var addedPerson = _directoryRepository.AddPerson(person);

        //    if (addedPerson == null)
        //    {
        //        Context.Response.StatusCode = 400;
        //        return new ObjectResult(new { Description = "Failed to save person" });
        //    }

        //    var url = Url.RouteUrl("GetById", new { id = person.Id }, Request.Scheme, Request.Host.ToUriComponent());

        //    Context.Response.StatusCode = 201;
        //    Context.Response.Headers["Location"] = url;

        //    return new ObjectResult(addedPerson);
        //}
    }
}
