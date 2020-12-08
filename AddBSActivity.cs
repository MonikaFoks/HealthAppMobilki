using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HealthAppMobilki.Interface;
using HealthAppMobilki.Models;
using Refit;

namespace HealthAppMobilki
{
    [Activity(Label = "AddBSActivity")]
    public class AddBSActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addBS_layout);
            IHealthAPI healthAPI;

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);

            var edt_addBS = FindViewById<EditText>(Resource.Id.txt_addBS);
            var btn_cancelBS = FindViewById<Button>(Resource.Id.btn_cancelBS);
            var btn_saveBS = FindViewById<Button>(Resource.Id.btn_saveBS);

            btn_cancelBS.Click += (s, e) =>
            {
                Finish();
            };

            btn_saveBS.Click += delegate
            {
                BloodSugar bs = new BloodSugar()
                {
                    mgdL = int.Parse(edt_addBS.Text),
                    Date = DateTime.Now,
                    userId = sessionUser.Id
                };

                healthAPI.PostBloodSugar(bs);

                Finish();
                Intent nextActivity = new Intent(this, typeof(BloodSugarActivity));
                StartActivity(nextActivity);
            };

        }
    }
}