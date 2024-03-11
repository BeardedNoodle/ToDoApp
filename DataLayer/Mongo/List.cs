using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mongo;
public class List
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long UserId { get; set; }

    public Status Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<ListItems>? ListItems {get; set;}
}