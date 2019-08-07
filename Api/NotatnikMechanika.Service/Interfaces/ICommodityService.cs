﻿using NotatnikMechanika.Service.Interfaces.Base;
using NotatnikMechanika.Shared.Models.Commodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotatnikMechanika.Service.Interfaces
{
    public interface ICommodityService : IServiceBase<CommodityModel>
    {
        Task<IEnumerable<CommodityForOrderModel>> GetCommoditiesForOrder(string userId, int orderId);
        Task<IEnumerable<CommodityModel>> GetCommoditiesInOrder(string userId, int orderId);
    }
}
