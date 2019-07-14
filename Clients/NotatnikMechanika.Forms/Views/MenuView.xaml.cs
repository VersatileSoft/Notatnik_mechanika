﻿using MvvmCross.Commands;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Master, NoHistory = true, WrapInNavigationPage = false)]
    public partial class MenuView : MvxContentPage<MenuViewModel>
    {
        public MenuView()
        {
            InitializeComponent();  
        }

        protected override void OnViewModelSet()
        {
            ViewModel.NavigateCommand = new MvxAsyncCommand<string>(NavigateTo);
        }

        private async Task NavigateTo(string param)
        {
            //Nothing bad in this code, the fastes way ;P

            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }

            await ViewModel.NavigateTo(param);
        }
    }
}