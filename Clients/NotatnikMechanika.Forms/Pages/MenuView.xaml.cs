﻿using NotatnikMechanika.Core.PageModels;
using Xamarin.MVVMPackage.Pages;

namespace NotatnikMechanika.Forms.Views
{
    public partial class MenuView : MvContentPage<MenuViewModel>
    {
        public MenuView()
        {
            InitializeComponent();
        }

        //protected override void OnViewModelSet()
        //{
        //    ViewModel.NavigateCommand = new MvxAsyncCommand<string>(NavigateTo);
        //}

        //private async Task NavigateTo(string param)
        //{
        //    //Nothing bad in this code, the fastest way ;P

        //    if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
        //    {
        //        masterDetailPage.IsPresented = false;
        //    }
        //    else if (Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
        //    {
        //        nestedMasterDetail.IsPresented = false;
        //    }

        //    await ViewModel.NavigateTo(param);
        //}
    }
}