using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Mongo.Entity;

namespace DataLayer.Mappers
{
    public static class ListItemMapper
    {
        public static ListItemModel ToModel(this ListItem entity)
        {
            return new ListItemModel
            {
                Id = entity.Id.ToString(),
                Body = entity.Body,
                ListId = entity.ListId,
                Status = entity.Status,
            };
        }

        public static List<ListItemModel> ToModelList(this List<ListItem>? entites)
        {
            if (entites == null)
                return new List<ListItemModel>();

            return entites.Select(ToModel).ToList();
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
        public static List<ListItem>? ToEntityList(this List<ListItemCreateModel>? models)
        {
            if (models == null)
                return null;

            return models.Select(ToEntity).ToList();
        }

        public static void ToUpdateModel(this ListItem item, ListItemUpdateModel model)
        {
            item.Body = model.Body;
            item.Status = model.Status;
        }
    }
}