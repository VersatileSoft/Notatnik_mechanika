﻿using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using NotatnikMechanika.Core.ViewModels;
using NotatnikMechanika.Shared.Models.Customer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotatnikMechanika.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = true)]
    public partial class CustomersView : MvxContentPage<CustomersViewModel>
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((sender as CollectionView).SelectedItem as CustomerModel).Id;

            (ViewModel as CustomersViewModel).CustomerSelectedCommand.Execute(id);
        }
    }
}