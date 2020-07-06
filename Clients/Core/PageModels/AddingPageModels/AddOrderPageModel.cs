﻿using MvvmPackage.Core.Services.Interfaces;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Model;
using NotatnikMechanika.Shared;
using NotatnikMechanika.Shared.Models;
using NotatnikMechanika.Shared.Models.Car;
using NotatnikMechanika.Shared.Models.Customer;
using NotatnikMechanika.Shared.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NotatnikMechanika.Core.PageModels
{
    public class AddOrderPageModel : AddingPageModelBase<OrderModel>
    {
        public AddOrderPageModel(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService) :
            base(navigationService, httpRequestService, messageDialogService)
        {
            Model.AcceptDate = DateTime.Now;
            Model.FinishDate = DateTime.Now;
        }

        public override string SuccesMessage { get; set; } = "Zlecenie zostało dodane pomyślnie.";

        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }

        private CustomerModel _selectedCustomer;

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                Task.Run(SelectedCustomerChanged);
            }
        }

        private CarModel _selectedCar;

        public CarModel SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                Model.CarId = _selectedCar.Id;
            }
        }

        private async Task SelectedCustomerChanged()
        {
            Response<CarsResult> carsResponse = await _httpRequestService.SendGet<CarsResult>(new CarPaths().GetFullPath(
                CarPaths.GetByCustomerPath.Replace("{customerId}", SelectedCustomer.Id.ToString())));

            if (carsResponse.StatusCode == HttpStatusCode.OK)
            {
                Cars = carsResponse.Content.Cars;
            }

            if (Cars.Any())
            {
                SelectedCar = Cars?.FirstOrDefault();
            }
        }

        public override async Task Initialize()
        {
            Response<GetAllResult<CustomerModel>> customersResponse = await _httpRequestService.SendGet<GetAllResult<CustomerModel>>(new CustomerPaths().GetFullPath(CRUDPaths.GetAllPath));

            if (customersResponse.StatusCode == HttpStatusCode.OK)
            {
                Customers = customersResponse.Content.Models;
            }

            if (Customers.Any())
            {
                SelectedCustomer = Customers?.FirstOrDefault();
            }
        }
    }
}