﻿using System;
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
		public ContactDetailPage (Contact contact)
		{
			InitializeComponent ();
            lblInfo.Text = contact.firstName;
            
		}
	}
}