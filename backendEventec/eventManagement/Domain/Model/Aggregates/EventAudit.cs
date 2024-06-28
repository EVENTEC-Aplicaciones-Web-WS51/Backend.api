using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace BDEventecFinal.eventManagement.Domain.Model.Aggregates;

public partial class EventAudit: IEntityWithCreatedUpdatedDate
{
    [Key]
    public int Id { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}