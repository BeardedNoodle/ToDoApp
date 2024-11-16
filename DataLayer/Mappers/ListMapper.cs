using DataLayer.Models;
using DataLayer.Postgre.Entity;

namespace DataLayer.Mappers
{
    public static class ListMapper
    {
        public static ListModel ToModel(this List entity)
        {
            return new ListModel
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Status = entity.Status,
                ListItems = entity.ListItems.ToModelList()
            };
        }

        public static List<ListModel> ToModelList(this List<List> entites)
        {
            return entites.Select(ToModel).ToList();
        }
        public static ListSimpleModel ToSimpleModel(this List entity)
        {
            return new ListSimpleModel
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Status = entity.Status
            };
        }

        public static List<ListSimpleModel> ToModelSimpleList(this List<List> entites)
        {
            return entites.Select(ToSimpleModel).ToList();
        }

        public static List ToEntity(this ListCreateModel model)
        {
            return new List
            {
                UserId = model.UserId,
                Title = model.Title,
                Status = model.Status,
            };
        }

        public static void ToEntity(this ListUpdateModel model, List entity)
        {
            entity.Title = model.Title;
            entity.Status = model.Status;
        }
    }
}