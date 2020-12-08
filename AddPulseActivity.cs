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
using HealthAppMobilki.Models;
using HealthAppMobilki.Resources;

namespace HealthAppMobilki
{
    [Activity(Label = "AddPulseActivity")]
    public class AddPulseActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addPulse_layout);


            var edt_addBpm = FindViewById<EditText>(Resource.Id.txt_addPulse);
            var btn_cancelPulse = FindViewById<Button>(Resource.Id.btn_cancelPulse);
            var btn_savePulse = FindViewById<Button>(Resource.Id.btn_savePulse);

            btn_cancelPulse.Click += (s, e) =>
            {
                Finish();
            };

            btn_savePulse.Click += delegate
            {
                Pulse pulse = new Pulse()
                {
                    Bpm = int.Parse(edt_addBpm.Text),
                    Date = DateTime.Now
                };

                Finish();
                Intent nextActivity = new Intent(this, typeof(PulseActivity));
                StartActivity(nextActivity);
            };




        }
    }
}