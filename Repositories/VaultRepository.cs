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

    internal bool DeleteKeep(int id, string userId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id AND userId = @userId", new { id, userId });
      return success > 0;
    }
  }
}