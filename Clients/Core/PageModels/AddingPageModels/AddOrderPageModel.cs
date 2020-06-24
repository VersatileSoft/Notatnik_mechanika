﻿using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Shared.Models.Order;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddOrderPageModel : AddingPageModelBase<OrderModel>
    {
        public AddOrderPageModel(IMvNavigationService navigationService) : base(navigationService)
        {
        }
        //public override string SuccesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";

        //public List<CustomerModel> Customers { get; set; }
        //public List<CarModel> Cars { get; set; }

        //private CustomerModel _selectedCustomer;

        //public CustomerModel SelectedCustomer
        //{
        //    get => _selectedCustomer;
        //    set
        //    {
        //        _selectedCustomer = value;
        //        Task.Run(SelectedCustomerChanged);
        //    }
        //}

        //private CarModel _selectedCar;

        //public CarModel SelectedCar
        //{
        //    get => _selectedCar;
        //    set
        //    {
        //        _selectedCar = value;
        //        Model.CarId = _selectedCar.Id;
        //    }
        //}

        //public AddOrderViewModel(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        //    : base(httpRequestService, navigationService, messageDialogService)
        //{
        //    Model.AcceptDate = DateTime.Now;
        //    Model.FinishDate = DateTime.Now;
        //}

        //private async Task SelectedCustomerChanged()
        //{
        //    Response<List<CarModel>> carsResponse = await _httpRequestService.SendGet<List<CarModel>>(new CarPaths().GetFullPath(
        //        CarPaths.GetByCustomerPath.Replace("{customerId}", SelectedCustomer.Id.ToString())), true);

        //    if (carsResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        Cars = carsResponse.Content;
        //    }

        //    if (Cars.Count > 0)
        //    {
        //        SelectedCar = Cars[0];
        //    }
        //}

        //public override async Task Initialize()
        //{
        //    Response<List<CustomerModel>> customersResponse = await _httpRequestService.SendGet<List<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath), true);

        //    if (customersResponse.StatusCode == HttpStatusCode.OK)
        //    {
        //        Customers = customersResponse.Content;
        //    }

        //    if (Customers.Count > 0)
        //    {
        //        SelectedCustomer = Customers[0];
        //    }
        //}
    }
}