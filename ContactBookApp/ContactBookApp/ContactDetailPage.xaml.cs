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
		public ContactDetailPage (Contact _contact)
		{
			InitializeComponent ();
            contact = _contact;
            entFirstName.Text = contact.firstName;
            entLastName.Text = contact.lastName;
            entPhone.Text = contact.phone;
            entEmail.Text = contact.email;
            
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (entFirstName.Text == "")
            {
                DisplayAlert("Attention", "Please enter the name.","OK");
            }
            else if (entLastName.Text == "")
            {
                DisplayAlert("Attention", "Please enter the last name.", "OK");
            }
            else if (entPhone.Text == "")
            {
                DisplayAlert("Attention", "Please enter phone number.", "OK");
            }
            else if (entEmail.Text == "")
            {
                DisplayAlert("Attention", "Please enter email.", "OK");
            }
            else if(contact.id==0)
            {
                DisplayAlert("Attention", "New Contact Added", "OK");
                //добовляем новый контакт
            }
            else if (contact.id == 1)
            {
                DisplayAlert("Attention", "Contact Changet", "OK");
                //добовляем новый контакт
            }
        }
    }
}