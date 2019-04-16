using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    //Dependency injection with that IDB connection
    private readonly IDbConnection _db;
    //constructor
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    //GetAll request from SQL
    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0;");
    }

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id AND isPrivate = 0", new { id });
    }

    public Keep CreateKeep(Keep rawKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, userId, img, isPrivate)
        VALUES (@Name, @Description, @UserId, @img, @isPrivate);
        SELECT LAST_INSERT_ID();
        ", rawKeep);
        rawKeep.Id = id;
        return rawKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }

    }

    public IEnumerable<Keep> GetAllByUser(string userId)
    {
      try
      {
        return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId;", new { userId });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool DeleteKeep(int id, string userId)
    {

      int success = _db.Execute("DELETE FROM keeps WHERE (id = @id AND userId = @userId)", new { id, userId });
      return success > 0;
    }
  }
}
// AND userId = @userId AND isPrivate = 1