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
    [Activity(Label = "AddPressureActivity")]
    public class AddPressureActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addPressure_layout);
            IHealthAPI healthAPI;

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);

            var edt_addSyst = FindViewById<EditText>(Resource.Id.txt_addPressure1);
            var edt_addDiast = FindViewById<EditText>(Resource.Id.txt_addPressure2);
            var btn_savePressure = FindViewById<Button>(Resource.Id.btn_savePressure);
            var btn_cancelPressure = FindViewById(Resource.Id.btn_cancelPressure);

            btn_cancelPressure.Click += (s, e) =>
            {
                Finish();
            };

            btn_savePressure.Click += delegate
            {
                Pressure pressure = new Pressure()
                {
                    Systolic = int.Parse(edt_addSyst.Text),
                    Diastolic = int.Parse(edt_addDiast.Text),
                    Date = DateTime.Now,
                    userId = sessionUser.Id

                };

                healthAPI.PostPressure(pressure);
                Finish();
                Intent nextActivity = new Intent(this, typeof(PressureActivity));
                StartActivity(nextActivity);
            };
        }
    }
}