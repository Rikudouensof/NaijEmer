using NaijEmer.Lists;
using NaijEmer.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Messaging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NaijEmer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();


           
            GetConvidData();
            GetWadisk();
        }

        private void GetWadisk()
        {
            List<EmergencyContactCLass> cLasses = List_of_States.contacts();
            Waldisk.ItemsSource = cLasses;
        }

        private async void GetConvidData()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("error", "You are not connected", "Reconnect");
                HeaderTitleLabel.Text = "You are not connected";

            }
            
           var client = new RestClient("https://api.covid19api.com/total/country/Nigeria");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            // HttpClient weclient = new HttpClient();

            var pendingProducts = JsonConvert.DeserializeObject<List<Class3>>(response.Content);

            List<Class3> class3s = new List<Class3>();

            class3s.Add(new Class3 { Date = DateTime.Now, Deaths = 334, Active = 233, Recovered = 332, Confirmed = 554 });

            ConvidDetailsListview.ItemsSource = pendingProducts.OrderByDescending(m => m.Date);

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var contactdetail = (EmergencyContactCLass)((ImageButton)sender).BindingContext;
            if (contactdetail.Phone.Equals(null))
            {
                await DisplayAlert("Opps!", "Phone Number not available", "Ok");
                return;
            }
            else
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall(contactdetail.Phone);
            }
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            var contactDetail = (EmergencyContactCLass)((ImageButton)sender).BindingContext;
            if (contactDetail.Email.Equals(null) || string.IsNullOrEmpty(contactDetail.Email))
            {
                await DisplayAlert("Opps!", "Email Number not available", "Ok");

            }
            else
            {
                string Email = contactDetail.Email;
                var EmailTask = CrossMessaging.Current.EmailMessenger;
                string MailTitle = DateTime.Now.ToString("dddd dd/MM/yyyy");


                if (EmailTask.CanSendEmail)
                {
                    EmailTask.SendEmail(Email, MailTitle, "");
                }
                else if (!EmailTask.CanSendEmail)
                {
                    await DisplayAlert("The Email is", Email, "Ok");
                    return;
                }
            }
       
    
        }

        private void WaldiskSearchber_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<EmergencyContactCLass> cLasses = List_of_States.contacts();
            Waldisk.ItemsSource = cLasses.Where(m => m.Title.Contains(WaldiskSearchber.Text) || m.Area.Contains(WaldiskSearchber.Text) || m.Phone.Contains(WaldiskSearchber.Text));
        }
    }
}
