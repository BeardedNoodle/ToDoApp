
using DataLayer.Models.Base;

namespace DataLayer.Postgre.Entity;

public class BasePostGre : IAuditFields
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool isDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime DeletedDate { get; set; }
}

public interface IAuditFields
{
    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public bool isDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime DeletedDate { get; set; }
}