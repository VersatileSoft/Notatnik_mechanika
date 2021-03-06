﻿using MvvmPackage.Core;
using MvvmPackage.Core.Commands;
using NotatnikMechanika.Core.Interfaces;
using PropertyChanged;
using System.Windows.Input;

namespace NotatnikMechanika.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class MyAccountPageModel : PageModelBase
    {
        private readonly IAuthService _authService;

        public ICommand LogoutCommand { get; set; }

        public MyAccountPageModel(IAuthService authService)
        {
            _authService = authService;
            LogoutCommand = new AsyncCommand(_authService.LogoutAsync);
        }
    }
}
