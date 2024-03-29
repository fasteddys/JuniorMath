﻿using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.DTOs.Items;
using JuniorMath.ApplicationCore.Entities;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorMath.ApplicationCore.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly UserHandler _userHandler;

        public ItemService(IRepository<Item> itemRepository, UserHandler userHandler)
        {
            _itemRepository = itemRepository;
            _userHandler = userHandler;
        }

        public Result SaveItem(ItemModel itemModel)
        {
            var userContext = _userHandler.GetUserContext();
            var result = new Result();

            if (userContext == null)
            {
                result.Message = "Session expired. ";
                return result;
            }

            try
            {
                if (itemModel.ItemId > 0)
                {
                    var item = _itemRepository.GetById(itemModel.ItemId);
                    if (item != null)
                    {
                        item.Cost = itemModel.Cost;
                        item.Name = itemModel.ItemName;
                        item.Description = itemModel.Description;
                        item.ShortCode = itemModel.ShortCode;
                        item.ServiceGroupId = itemModel.ServiceGroupId;
                        item.IndustryCodeId = itemModel.IndustryCodeId;
                        item.Subscription = itemModel.Subscription;

                        _itemRepository.Update(item);
                        result.Message = "Update service success. ";
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = "Update service failed ";
                    }
                }
                else
                {
                    var item = new Item()
                    {
                        Active = true,
                        ClinicId = userContext.ClinicId,
                        Cost = itemModel.Cost,
                        Description = itemModel.Description,
                        Name = itemModel.ItemName,
                        UpdatedBy = userContext.SiteUserId,
                        UpdatedDateUtc = DateTime.UtcNow,
                        ShortCode = itemModel.ShortCode,
                        ServiceGroupId = itemModel.ServiceGroupId,
                        IndustryCodeId = itemModel.IndustryCodeId,
                        Subscription = itemModel.Subscription
                    };

                    _itemRepository.Add(item);
                    result.Message = "Add service success. ";
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Message = "Add service failed: " + ex.Message;
            }

            return result;
        }

        public ItemModel SearchItem(int id)
        {
            var item = _itemRepository.GetById(id);

            if (item != null)
            {
                return new ItemModel { Cost = item.Cost, ItemId = item.Id, ItemName = item.Name, Description = item.Description,
                    IndustryCodeId = item.IndustryCodeId,
                    ServiceGroupId = item.ServiceGroupId,
                    ShortCode = item.ShortCode,
                    Subscription = item.Subscription
                };
            }

            return null;
        }

        public List<ItemModel> SearchItems()
        {
            var data = _itemRepository.ListAll().ToList();
            var result = data.Select(p => new ItemModel
            {
                Cost = p.Cost,
                Description = p.Description,
                ItemId = p.Id,
                ItemName = p.Name,
                IndustryCodeId = p.IndustryCodeId,
                ServiceGroupId = p.ServiceGroupId,
                ShortCode = p.ShortCode,
                Subscription = p.Subscription
                

            }).ToList();

            return result;
        }

        public bool HasSubscriptionItems(List<int> itemIds)
        {
            var items = SearchItems();
            var hasSubscriptionItems = items.Where(p => itemIds.Contains(p.ItemId)).Any(p => p.Subscription);

            return hasSubscriptionItems;
        }
    }
}

