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
        public ObservableCollection<Models.Contact> _contacts;
        private Contact changetContact;
        public MainPage(Contact contact =null)
		{
           
            InitializeComponent();
            _contacts = new ObservableCollection<Contact>();
            _contacts.Add(new Contact {newContact=false, firstName = "Anna", lastName = "Popova", id = _contacts.Count, phone = "+372687865", email = "anna44@mail.ru" });
            _contacts.Add(new Contact {newContact = false, firstName = "Peter", lastName = "Black", id = _contacts.Count, phone = "+372830012", email = "straight@qiq.ru" });
            _contacts.Add(new Contact {newContact = false, firstName = "Rassel", lastName = "Strong", id = _contacts.Count, phone = "+372118494", email = "rasselm@gmail.com"});
            listView.ItemsSource = _contacts;
        }

        //метод для добовления нового контакта
        public void AddNewContact(Contact contact)
        {
            _contacts.Add(contact);
        }
       
        //метод для изменения имеющегося контакта
        public void ChangeContact(Contact contact)
        {
            //удаляем изменяемый контакт
            _contacts.Remove(changetContact);
            contact.id = _contacts.Count;
            _contacts.Add(contact);
        }
        

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //если не поставеть условие!!!! получем бесконечный цыкл
            if (e.SelectedItem == null)
				return;
            var contact = e.SelectedItem as Contact;
            changetContact = contact;

            await Navigation.PushAsync(new ContactDetailPage(contact,this));
            //для того чтобы при возврате на страницу элемент листа небыл выделин
            listView.SelectedItem = null;
        }
        async private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactDetailPage(new Contact {newContact=true }, this));
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
