using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public string UserId { get; set; }

    [Required]
    public int VaultId { get; set; }

    [Required]
    public int KeepId { get; set; }
  }
}

// -- CREATE TABLE vaultkeeps(
// --     id int NOT NULL AUTO_INCREMENT,
// --     vaultId int NOT NULL,
// --     keepId int NOT NULL,
// --     userId VARCHAR(255) NOT NULL,