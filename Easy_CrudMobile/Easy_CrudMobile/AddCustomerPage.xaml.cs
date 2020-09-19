
using Easy_CrudMobile.Logic;
using Easy_CrudMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Easy_CrudMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomerPage : ContentPage
    {
        public AddCustomerPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            var customer = new Customer
            {
                FirstName = firstNameEntry.Text,
                Surname = surnameEntry.Text,
                Hire_Date = hire_datePicker.Date,
                Age = int.Parse(ageEntry.Text)
            };

            await CustomerLogic.AddCustomer(customer);

            await Navigation.PopAsync();
        }
    }
}