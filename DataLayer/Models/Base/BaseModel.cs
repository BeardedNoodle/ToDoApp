using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models.Base;

public interface IBaseModel;
public class BaseModel : BaseViewModel
{

    public Guid CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime DeletedDate { get; set; }
}

public class BaseViewModel : IBaseModel
{
    public Guid Id { get; set; }
}

public class BaseCreateModel : IBaseModel
{ }

public class BaseUpdateModel : IBaseModel
{
    public Guid Id { get; set; }
}
