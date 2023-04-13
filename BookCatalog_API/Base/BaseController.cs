using BookCatalog_API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog_API.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<Key, Entity, Repository> : ControllerBase
    where Entity : class
    where Repository : IRepository<Key, Entity>
{
    private readonly Repository repository;

    public BaseController(Repository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var result = await repository.GetAll();
            return result.Count() is 0
                ? NotFound(new { statusCode = 404, message = "Data Not Found!" })
                : Ok(new { statusCode = 201, message = "Success", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 400, message = $"Something Wrong! : {e.Message}" });
        }

    }
    [HttpGet("{key}")]
    public async Task<ActionResult> GetById(Key key)
    {
        try
        {
            var result = await repository.GetById(key);
            return result is null
                ? NotFound(new { statusCode = 404, message = $"Data With Id {key} Not Found!" })
                : Ok(new { statusCode = 200, message = $"Data Found!", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 400, message = $"Something Wrong! : {e.Message}" });
        }
    }
    [HttpPost]
    public async Task<ActionResult> Insert(Entity entity)
    {
        try
        {
            var result = await repository.Insert(entity);
            return result is 0
                ? Conflict(new { statusCode = 409, message = "Data fail to Insert!" })
                : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });
        }
        catch
        {
            return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
        }
    }
    [HttpPut]
    public async Task<ActionResult> Update(Entity entity)
    {
        try
        {
            var result = await repository.Update(entity);
            return result is 0
                ? NotFound(new { statusCode = 404, message = $"Id not found!" })
                : Ok(new { statusCode = 200, message = "Update Succesfully!" });
        }
        catch
        {
            return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
        }
    }
    [HttpDelete("{key}")]
    public async Task<ActionResult> Delete(Key key)
    {
        try
        {
            var result = await repository.Delete(key);
            return result is 0
                ? NotFound(new { statusCode = 404, message = $"Id {key} Data Not Found" })
                : Ok(new { statusCode = 200, message = "Data Delete Succesfully!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 400, message = $"Something Wrong {e.Message}" });
        }
    }
}
