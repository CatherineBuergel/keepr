using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    //Dependency injection with that IDB connection
    private readonly IDbConnection _db;
    //constructor
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Vault> GetALL(string Id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @Id;", new { Id });
    }

    internal Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @id", new { id });
    }

    internal Vault CreateVault(Vault rawVault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, userId)
        VALUES (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();
        ", rawVault);
        rawVault.Id = id;
        return rawVault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    internal bool DeleteVault(int id, string userId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id AND userId = @userId", new { id, userId });
      return success > 0;
    }

    public VaultKeep addToVault(VaultKeep newVaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (vaultId, keepId, userId)
        VALUES (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();
        ", newVaultKeep);
        newVaultKeep.Id = id;
        return newVaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public IEnumerable<Keep> GetVaultKeeps(int id, string userId)
    {
      return _db.Query<Keep>(@"
     SELECT * FROM vaultkeeps vk
     INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @id AND vk.userId = @userId)", new { id, userId });
    }

    public bool DeleteFromVaultKeep(int vaultId, int keepId, string userId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @vaultId AND keepId = @keepId AND userId = @userId", new { vaultId, keepId, userId });
      return success > 0;
    }
  }
}

// SELECT* FROM vaultkeeps vk
// -- -- INNER JOIN keeps k ON k.id = vk.keepId
// -- -- WHERE (vaultId = @vaultId AND vk.userId = @userId) 