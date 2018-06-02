using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ContactBookApp;
using System.Collections.ObjectModel;
using ContactBookApp.Models;

namespace ContactBookApp
{
	public partial class MainPage : ContentPage
	{
        private ObservableCollection<Models.Contact> _contacts;
        public MainPage()
		{
           
            InitializeComponent();
            _contacts = new ObservableCollection<Contact>
            {
                new Contact{firstName="Anna",lastName="Popova",id=1,phone="+372687865",email="anna44@mail.ru"},
                new Contact{firstName="Peter",lastName="Black",id=1,phone="+372830012",email="straight@qiq.ru"},
                new Contact{firstName="Rassel",lastName="Strong",id=1,phone="+372118494",email="rasselm@gmail.com"}
            };

            listView.ItemsSource = _contacts;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            //через XAML свойство мы узнаём выбраный элемент
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.firstName, "Ok");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }
    }
}
