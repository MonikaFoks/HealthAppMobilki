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

namespace HealthAppMobilki
{
    [Activity(Label = "MainPageActivity")]
    public class MainPageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var btn_pressure = FindViewById<Button>(Resource.Id.btn_pressure);
            var btn_pulse = FindViewById<Button>(Resource.Id.btn_pulse);
            var btn_bloodSugar = FindViewById<Button>(Resource.Id.btn_bloodSugar);
            var btn_weight = FindViewById<Button>(Resource.Id.btn_weight);

            btn_pressure.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(PressureActivity));
                StartActivity(nextActivity);
            };

            btn_pulse.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(PulseActivity));
                StartActivity(nextActivity);
            };

            btn_bloodSugar.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(BloodSugarActivity));
                StartActivity(nextActivity);
            };

            btn_weight.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(WeightActivity));
                StartActivity(nextActivity);
            };
        }
    }
}