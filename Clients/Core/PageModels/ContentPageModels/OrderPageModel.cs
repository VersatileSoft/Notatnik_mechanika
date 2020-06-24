﻿using MvvmPackage.Core;
using NotatnikMechanika.Core.Models;
using PropertyChanged;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageModel : PageModelBase<OrderExtendedModel>
    {
        //private readonly IHttpRequestService _httpRequestService;
        //private readonly IMvxNavigationService _navigationService;

        //public ICommand GoBackCommand { get; set; }
        //public ICommand AddServiceCommodityCommand { get; set; }

        //public OrderExtendedModel OrderModel { get; set; }
        //public List<CommodityModel> Commodities { get; set; }
        //public List<ServiceModel> Services { get; set; }


        //public OrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService)
        //{
        //    OrderModel = new OrderExtendedModel();
        //    _httpRequestService = httpRequestService;
        //    _navigationService = navigationService;
        //    GoBackCommand = new MvxAsyncCommand(() => navigationService.Navigate<MainPageViewModel>());
        //    AddServiceCommodityCommand = new MvxAsyncCommand<bool>(AddServiceCommodityAction);

        //    navigationService.AfterClose += NavigationService_AfterClose;
        //}

        //private void NavigationService_AfterClose(object sender, MvvmCross.Navigation.EventArguments.IMvxNavigateEventArgs e)
        //{
        //    if (e.ViewModel is AddServiceToOrderViewModel || e.ViewModel is AddCommodityToOrderViewModel)
        //    {
        //        Task.Run(Initialize);
        //    }
        //}

        //private async Task AddServiceCommodityAction(bool isService)
        //{
        //    if (isService)
        //    {
        //        await _navigationService.Navigate<AddServiceToOrderViewModel, int>(OrderModel.Id);
        //    }
        //    else
        //    {
        //        await _navigationService.Navigate<AddCommodityToOrderViewModel, int>(OrderModel.Id);
        //    }
        //}

        //public override void Prepare(OrderExtendedModel model)
        //{
        //    OrderModel = model;
        //}

        //public override async Task Initialize()
        //{
        //    Response<List<ServiceModel>> servicesResponse = await _httpRequestService.SendGet<List<ServiceModel>>(new ServicePaths().GetFullPath(ServicePaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())), true);

        //    if (servicesResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        Services = servicesResponse.Content;
        //    }

        //    Response<List<CommodityModel>> commoditiesResponse = await _httpRequestService.SendGet<List<CommodityModel>>(new CommodityPaths().GetFullPath(CommodityPaths.GetAllInOrderPath.Replace("{orderId}", OrderModel.Id.ToString())), true);

        //    if (commoditiesResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        Commodities = commoditiesResponse.Content;
        //    }
        //}
    }
}