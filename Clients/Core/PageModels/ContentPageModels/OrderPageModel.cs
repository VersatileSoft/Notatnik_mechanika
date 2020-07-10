﻿using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models.Commodity;
using NotatnikMechanika.Shared.Models.Order;
using NotatnikMechanika.Shared.Models.Service;
using PropertyChanged;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IMvNavigationService _navigationService;

        public ICommand GoBackCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand AddCommodityCommand { get; set; }

        public OrderExtendedModel OrderModel { get; set; }
        public List<CommodityModel> Commodities { get; set; }
        public List<ServiceModel> Services { get; set; }




        public OrderPageModel(IHttpRequestService httpRequestService, IMvNavigationService navigationService)
        {
            OrderModel = new OrderExtendedModel();
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            GoBackCommand = new AsyncCommand(() => navigationService.NavigateToAsync<MainPageModel>());
            AddServiceCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddServiceToOrderPageModel>(OrderModel.Id));
            AddCommodityCommand = new AsyncCommand(() => _navigationService.NavigateToAsync<AddCommodityToOrderPageModel>(OrderModel.Id));

            // navigationService.AfterClose += NavigationService_AfterClose;
        }

        //private void NavigationService_AfterClose(object sender, MvvmCross.Navigation.EventArguments.IMvxNavigateEventArgs e)
        //{
        //    if (e.ViewModel is AddServiceToOrderViewModel || e.ViewModel is AddCommodityToOrderViewModel)
        //    {
        //        Task.Run(Initialize);
        //    }
        //}

        public override async Task Initialize()
        {
            IsLoading = true;
            Response<OrderExtendedModel> orderResponse =
                await _httpRequestService.SendGet<OrderExtendedModel>(
                    new OrderPaths().GetFullPath(
                        OrderPaths.GetExtendedOrder.Replace("{orderId}", Parameter.ToString())));

            if (orderResponse.Successful)
            {
                OrderModel = orderResponse.Content;
            }
            else
            {
                return;
            }

            Response<List<ServiceModel>> servicesResponse = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(ServicePaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())));

            if (servicesResponse.Successful)
            {
                Services = servicesResponse.Content;
            }

            Response<List<CommodityModel>> commoditiesResponse = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CommodityPaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())));

            if (commoditiesResponse.Successful)
            {
                Commodities = commoditiesResponse.Content;
            }
            IsLoading = false;
        }
    }
}