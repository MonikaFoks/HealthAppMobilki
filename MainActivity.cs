using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;
using Android.Text.Format;
using Android.Util;
using Refit;
using HealthAppMobilki.Interface;
using EDMTDialog;
using System.Collections.Generic;
using HealthAppMobilki.Models;
using System.Net.Http;
using System.Net;
using System.Net.Security;

namespace HealthAppMobilki
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            IHealthAPI healthAPI;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login_layout);

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession );

            
            var btn_login = FindViewById<Button>(Resource.Id.btn_login);
            var txt_login = FindViewById<EditText>(Resource.Id.txt_login);
            var txt_password = FindViewById<EditText>(Resource.Id.txt_password);

            


            btn_login.Click += async (s, e) =>
            {
                try
                {
                    Android.Support.V7.App.AlertDialog dialog = new EDMTDialogBuilder()
                    .SetContext(this)
                    .SetMessage("Proszę czekać...")
                    .Build();

                    Android.Support.V7.App.AlertDialog dialogNoUser = new EDMTDialogBuilder()
                    .SetContext(this)
                    .SetMessage("No user")
                    .Build();

                    if (!dialog.IsShowing)
                    {
                        dialog.Show();
                    }

                    List<User> users = await healthAPI.GetUsers();
               
                    User newUser = new User()
                    {
                        Login = txt_login.Text.ToString(),
                        Password = txt_password.Text.ToString()
                    };

                    var userExists = users.Contains((users.Find(x => (x.Login == newUser.Login) && (x.Password == newUser.Password))));
                    var currUser = users.Find(x => (x.Login == newUser.Login) && (x.Password == newUser.Password));

                    if (userExists)
                    {
                        
                        dialog.Hide();

                        sessionUser.Id = currUser.Id;
                        Intent nextActivity = new Intent(this, typeof(MainPageActivity));
                        StartActivity(nextActivity);
                    }

                    else
                    {
                        dialogNoUser.Show();
                    }

                    
                }
                catch(Exception ex)
                {
                    Toast.MakeText(this, "" + ex.Message, ToastLength.Long).Show();
                }

                
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}