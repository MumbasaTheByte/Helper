﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Helper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuFlyoutPage : FlyoutPage
    {
        private int activeId = 0;
        public SideMenuFlyoutPage()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as SideMenuFlyoutPageFlyoutMenuItem;
            if (item == null || item.Id == activeId)
            {
                FlyoutPage.ListView.SelectedItem = null;
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            activeId = item.Id;

            Detail = new NavigationPage(page);
            IsPresented = false;
            
            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}