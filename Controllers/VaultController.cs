using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultController : ControllerBase
  {
    //make repository
    private readonly VaultRepository _vr;
    public VaultController(VaultRepository vr)
    {
      _vr = vr;
    }
    //get all vaults
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.GetALL(userId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //Get one vault by ID
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault found = _vr.GetById(id);
      if (found == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(found);
    }

    //Create a vault
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault rawVault)
    {
      Vault newVault = _vr.CreateVault(rawVault);
      if (newVault == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(newVault);
    }

    //delete a vault
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.DeleteKeep(id);
      if (!successful) { return BadRequest("Something has gone horribly wrong"); }
      return Ok("Successfully Deleted");
    }
  }
}