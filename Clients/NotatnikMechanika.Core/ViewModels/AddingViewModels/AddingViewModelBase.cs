﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Core.Services;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotatnikMechanika.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingViewModelBase<TModel> : MvxViewModel where TModel : new()
    {
        public TModel Model { get; set; }
        public ICommand AddCommand { get; set; }
        public bool IsWaiting { get; set; }

        protected readonly IHttpRequestService _httpRequestService;
        protected readonly IMvxNavigationService _navigationService;
        protected readonly IMessageDialogService _messageDialogService;

        protected abstract string errorMessage { get; set; }
        protected abstract string succesMessage { get; set; }

        public AddingViewModelBase(IHttpRequestService httpRequestService, IMvxNavigationService navigationService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            Model = new TModel();
            AddCommand = new MvxAsyncCommand(AddAction);
        }

        private async Task AddAction()
        {
            IsWaiting = true;
            string a = PathsHelper.GetPathsByModel<TModel>().GetFullPath(CRUDPaths.CreatePath);
            Response respone = await _httpRequestService.SendPost(Model, a, true);
            IsWaiting = false;
            if (respone.StatusCode == HttpStatusCode.OK)
            {
                await _messageDialogService.ShowMessageDialog(succesMessage);
                await _navigationService.Navigate<MainPageViewModel>();
            }
            else
            {
                await _messageDialogService.ShowMessageDialog(errorMessage + " " + respone.ErrorMessage);
            }
        }
    }
}