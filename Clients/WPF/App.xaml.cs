﻿using MvvmPackage.Wpf;
using NotatnikMechanika.Core;

namespace NotatnikMechanika.WPF
{
    public partial class App : MvWpfApplication<MainPageService>
    {
        public App()
        {
            InitializeComponent();
        }
    }
}