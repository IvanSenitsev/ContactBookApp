using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBookApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
	{
        private Contact contact;
        private MainPage mainPage;
		public ContactDetailPage (Contact _contact ,MainPage _mainPage)
		{
			InitializeComponent ();
            contact = _contact;
            mainPage = _mainPage;
            entFirstName.Text = contact.firstName;
            entLastName.Text = contact.lastName;
            entPhone.Text = contact.phone;
            entEmail.Text = contact.email;
            
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {
            if (entFirstName.Text == "")
            {
              await  DisplayAlert("Attention", "Please enter the name.","OK");
            }
            else if (entLastName.Text == "")
            {
                await DisplayAlert("Attention", "Please enter the last name.", "OK");
            }
            else if (entPhone.Text == "")
            {
                await DisplayAlert("Attention", "Please enter phone number.", "OK");
            }
            else if (entEmail.Text == "")
            {
                await DisplayAlert("Attention", "Please enter email.", "OK");
            }
            else if(contact.newContact==true)
            {
                //добовляем новый контакт
                contact.newContact=false;
                contact.firstName = entFirstName.Text;
                contact.lastName = entLastName.Text;
                contact.phone = entPhone.Text;
                contact.email = entEmail.Text;

                mainPage.AddNewContact(contact);
               await DisplayAlert("Attention", "New Contact Added", "OK");
               await Navigation.PopAsync();

            }
            else if (contact.newContact == false)
            {
               
                //изменяем старый контакт
                contact.id = mainPage._contacts.Count;
                contact.firstName = entFirstName.Text;
                contact.lastName = entLastName.Text;
                contact.phone = entPhone.Text;
                contact.email = entEmail.Text;

                mainPage.ChangeContact(contact);
               await DisplayAlert("Attention", "Contact Changet", "OK");
               await Navigation.PopAsync();
            }
        }

        
    }
}