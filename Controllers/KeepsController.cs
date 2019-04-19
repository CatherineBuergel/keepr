using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    //make repository
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }
    //get all public keeps for home page
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //get all private keeps for private view
    [Authorize]
    [HttpGet("user/personal")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByUser()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetAllByUser(userId);
      if (results == null)
      {
        return BadRequest("what's going on");
      }
      return Ok(results);

    }

    //Get one keep by ID
    [HttpGet("keep/{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep found = _kr.GetById(id);
      if (found == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(found);
    }

    //Create a keep
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep rawKeep)
    {
      rawKeep.UserId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.CreateKeep(rawKeep);
      if (newKeep == null) { return BadRequest("Something had gone horribly wrong"); }
      return Ok(newKeep);
    }

    //delete a keep
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      bool successful = _kr.DeleteKeep(id, userId);
      if (!successful) { return BadRequest("Something had gone horribly wrong"); }
      return Ok("Successfully Deleted");
    }

    [HttpPut("public/edit/{id}")]
    public ActionResult<Keep> increaseViewCount(int id)
    {
      Keep updatedKeep = _kr.increaseViewCount(id);
      if (updatedKeep == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(updatedKeep);
    }

    [HttpPut("vaultkeeps/add/{id}")]
    public ActionResult<Keep> increaseShareCount(int id)
    {
      Keep updatedKeep = _kr.increaseShareCount(id);
      if (updatedKeep == null) { return BadRequest("Something went wrong come fix it"); }
      return Ok(updatedKeep);
    }
  }
}