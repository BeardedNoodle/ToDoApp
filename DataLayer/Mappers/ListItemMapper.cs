
using DataLayer.Models;
using DataLayer.Postgre.Entity;

namespace DataLayer.Mappers
{
    public static class ListItemMapper
    {
        public static ListItemModel ToModel(this ListItem entity)
        {
            return new ListItemModel
            {
                Id = entity.Id,
                Body = entity.Body,
                ListId = entity.ListId,
                Status = entity.Status,
            };
        }

        public static List<ListItemModel> ToModelList(this List<ListItem>? entities)
        {
            if (entities == null)
                return new List<ListItemModel>();

            return entities.Select(ToModel).ToList();
        }

        public static ListItem ToEntity(this ListItemCreateModel model)
        {
            return new ListItem
            {
                Body = model.Body,
                ListId = model.ListId,
                Status = model.Status
            };
        }
        public static void ToEntity(this ListItemUpdateModel model, ListItem item)
        {
            item.Body = model.Body;
            item.Status = model.Status;
        }
        public static List<ListItem>? ToEntityList(this List<ListItemCreateModel>? models)
        {
            if (models == null)
                return null;

            return models.Select(ToEntity).ToList();
        }

    }
}