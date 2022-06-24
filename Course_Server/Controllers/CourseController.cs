using Microsoft.AspNetCore.Mvc;
using Course.Shared;
using Course_Server.Repository;

namespace Course_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesRepository repo;
        public CourseController(ICoursesRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProgrammingCourse>))]
        public async Task<IEnumerable<ProgrammingCourse>> GetCourse(int id)
        {
            if (id == 0)
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync())
                  .Where(customer => customer.CourseId == id);
            }

        }
        [HttpGet("{id}", Name = nameof(GetCourseById))] // named route
        [ProducesResponseType(200, Type = typeof(ProgrammingCourse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            ProgrammingCourse? c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }
            return Ok(c); // 200 OK with customer in body
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProgrammingCourse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ProgrammingCourse c)
        {
            if (c == null)
            {
                return BadRequest(); // 400 Bad request
            }

            ProgrammingCourse? addedCustomer = await repo.CreateAsync(c);

            if (addedCustomer == null)
            {
                return BadRequest("Repository failed to create customer.");
            }
            else
            {
                return CreatedAtRoute( // 201 Created
                  routeName: nameof(GetCourseById),
                  routeValues: new { id = addedCustomer.CourseId },
                  value: addedCustomer);
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(
          int id, [FromBody] ProgrammingCourse c)
        {

            c.CourseId = id;

            if (c == null || c.CourseId != id)
            {
                return BadRequest(); // 400 Bad request
            }

            ProgrammingCourse? existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }

            await repo.UpdateAsync(id, c);

            return new NoContentResult(); // 204 No content
        }

        // DELETE: api/customers/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            // take control of problem details
            if (id == -1)
            {
                ProblemDetails problemDetails = new()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://localhost:7281/customers/failed-to-delete",
                    Title = $"Customer ID {id} found but failed to delete.",
                    Detail = "More details like Company Name, Country and so on.",
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails); // 400 Bad Request
            }

            ProgrammingCourse? existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }

            bool? deleted = await repo.DeleteAsync(id);

            if (deleted.HasValue && deleted.Value) // short circuit AND
            {
                return new NoContentResult(); // 204 No content
            }
            else
            {
                return BadRequest( // 400 Bad request
                  $"Customer {id} was found but failed to delete.");
            }
        }
    }
}
