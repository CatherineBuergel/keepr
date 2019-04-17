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
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.GetALL(userId);
      if (results == null)
      {
        return BadRequest("something has gone horribly wrong");
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
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault rawVault)
    {
      rawVault.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.CreateVault(rawVault);
      if (newVault == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(newVault);
    }

    //delete a vault
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      bool successful = _vr.DeleteVault(id, userId);
      if (!successful) { return BadRequest("Something has gone horribly wrong"); }
      return Ok("Successfully Deleted");
    }
    [Authorize]
    [HttpPost("{id}/vaultKeeps")]
    public ActionResult<VaultKeep> addToVault([FromBody] VaultKeep newVaultKeep)
    {

      newVaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeep addedVaultKeep = _vr.addToVault(newVaultKeep);
      if (newVaultKeep == null) { return BadRequest("Something has gone horribly wrong"); }
      return Ok(addedVaultKeep);

    }

    [Authorize]
    [HttpGet("{id}/vaultKeeps")]
    public ActionResult<IEnumerable<Keep>> GetVaultKeeps(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _vr.GetVaultKeeps(id, userId);
      if (results == null)
      {
        return BadRequest("something has gone horribly wrong");
      }
      return Ok(results);

    }

    [Authorize]
    [HttpDelete("{vaultId}/vaultKeeps/{keepId}")]
    public ActionResult DeleteFromVaultKeep(int vaultId, int keepId)
    {
      string userId = HttpContext.User.Identity.Name;
      bool successful = _vr.DeleteFromVaultKeep(vaultId, keepId, userId);
      if (!successful) { return BadRequest("Something has gone horribly wrong"); }
      return Ok("Successfully Deleted");
    }
  }
}