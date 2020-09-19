using Easy_CrudMobile.Logic;
using Easy_CrudMobile.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Easy_CrudMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var customers = await CustomerLogic.GetCustomers();
            List<Customer> modelList = new List<Customer>();

            foreach (var customer in customers)
            {
                var model = new Customer
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    Surname = customer.Surname,
                    Age = customer.Age,
                    Hire_Date = customer.Hire_Date
                };

                modelList.Add(model);
            }

            customerListView.ItemsSource = modelList;
            customerListView.Refreshing += CustomerListView_Refreshing;
        }
        private void CustomerListView_Refreshing(object sender, System.EventArgs e)
        {
            OnAppearing();
            customerListView.IsRefreshing = false;
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            var item = customerListView.SelectedItem as Customer;
            Navigation.PushAsync(new AddCustomerPage());
        }

        private async void MenuItem_Clicked_Edit(object sender, System.EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var customer = mi.CommandParameter as Customer;

            await Navigation.PushAsync(new EditPage
            {
                BindingContext = customer
            });

        }

        private async void MenuItem_Clicked_Delete(object sender, System.EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var customer = mi.CommandParameter as Customer;

            await CustomerLogic.DeleteCustomer(customer.Id);

            OnAppearing();
        }
    }
}
