﻿using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Shared.Models.Commodity;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddCommodityPageModel : AddingPageModelBase<CommodityModel>
    {
        public AddCommodityPageModel(IMvNavigationService navigationService) : base(navigationService)
        {
        }
        //public override string ErrorMessage { get; set; } = "Błąd podczas dodawania towaru.";
        //public override string SuccesMessage { get; set; } = "Towar został dodany pomyślnie.";

        //public AddCommodityViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //}
    }
}