﻿using MvvmPackage.Core;
using MvvmPackage.Core.Services.Interfaces;
using MVVMPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using NotatnikMechanika.Shared;
using PropertyChanged;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static NotatnikMechanika.Shared.ResponseBuilder;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AddingPageModelBase<TModel> : PageModelBase where TModel : ValidateModelBase, new()
    {
        public TModel Model { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        protected readonly IHttpRequestService _httpRequestService;
        protected readonly IMvNavigationService _navigationService;
        protected readonly IMessageDialogService _messageDialogService;

        public virtual string ErrorMessage { get; set; }
        public virtual string SuccesMessage { get; set; }

        protected AddingPageModelBase(IMvNavigationService navigationService, IHttpRequestService httpRequestService, IMessageDialogService messageDialogService)
        {
            _httpRequestService = httpRequestService;
            _navigationService = navigationService;
            _messageDialogService = messageDialogService;
            Model = new TModel();
            AddCommand = new AsyncCommand(AddAction);
            GoBackCommand = new AsyncCommand(() => _navigationService.PopAsync());
        }

        private async Task AddAction()
        {
            IsLoading = true;
            string path = PathsHelper.GetPathsByModel<TModel>().GetFullPath(CRUDPaths.CreatePath);
            Response response = await _httpRequestService.SendPost(Model, path);

            switch (response.ResponseType)
            {
                case ResponseType.Successful:
                    await _messageDialogService.ShowMessageDialog(SuccesMessage, MessageDialogType.Success, "Operacja powiodła się");
                    await _navigationService.NavigateToAsync<MainPageModel>();
                    break;

                case ResponseType.Failure:
                    ErrorMessage = response.ErrorMessages?.FirstOrDefault();
                    await _messageDialogService.ShowMessageDialog(ErrorMessage, MessageDialogType.Error, "Wystąpił błąd");
                    break;

                case ResponseType.BadModelState:
                    await _messageDialogService.ShowMessageDialog("Wypełnij formularz poprawnie", MessageDialogType.Error);
                    break;
            }
            IsLoading = false;
        }
    }
}