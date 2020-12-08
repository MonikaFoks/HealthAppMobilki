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
    [Activity(Label = "AddWeightActivity")]
    public class AddWeightActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addWeight_layout);
            IHealthAPI healthAPI;

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);

            var edt_addKgs = FindViewById<EditText>(Resource.Id.txt_addWeight);
            var btn_cancelWeight = FindViewById<Button>(Resource.Id.btn_cancelWeight);
            var btn_saveWeight = FindViewById<Button>(Resource.Id.btn_saveWeight);

            btn_cancelWeight.Click += (s, e) =>
            {
                Finish();
            };

            btn_saveWeight.Click += delegate
            {
                Weight weight = new Weight()
                {
                    Kgs = int.Parse(edt_addKgs.Text),
                    Date = DateTime.Now,
                    userId = sessionUser.Id
                };

                healthAPI.PostWeight(weight);

                Finish();
                Intent nextActivity = new Intent(this, typeof(WeightActivity));
                StartActivity(nextActivity);
            };

        }
    }
}