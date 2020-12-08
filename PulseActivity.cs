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
using EDMTDialog;
using HealthAppMobilki.Interface;
using HealthAppMobilki.Models;
using HealthAppMobilki.Resources;
using Refit;

namespace HealthAppMobilki
{
    [Activity(Label = "pulseActivity")]
    public class PulseActivity : Activity
    {
        ListView lstData;
        List<Pulse> lstSource = new List<Pulse>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            IHealthAPI healthAPI;

            int itemId = 0;
            DateTime itemDate = DateTime.Now;

            SetContentView(Resource.Layout.pulse_layout);

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);
            lstData = FindViewById<ListView>(Resource.Id.pulseList);

            LoadData();


            var btn_addPulse = FindViewById<Button>(Resource.Id.btn_addPulse);
            var btn_deletePulse = FindViewById<Button>(Resource.Id.btn_deletePulse);
            var btn_loadPulses = FindViewById<Button>(Resource.Id.btn_loadPulses);

            btn_loadPulses.Click += async (s, e) =>
            {
                try
                {
                    Android.Support.V7.App.AlertDialog dialog = new EDMTDialogBuilder()
                    .SetContext(this)
                    .SetMessage("Proszę czekać...")
                    .Build();

                    if (!dialog.IsShowing)
                    {
                        dialog.Show();
                    }

                    List<Pulse> pulses = await healthAPI.GetPulses();
                    lstSource = pulses.FindAll(x => x.userId == sessionUser.Id);

                    dialog.Dismiss();
                    LoadData();

                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "" + ex.Message, ToastLength.Long).Show();
                }
            };

            lstData.ItemClick += (s, e) =>
            {
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)
                    {
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkOrange);
                    }
                    else
                    {
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                    }
                }

                itemId = int.Parse(e.Id.ToString());

                btn_deletePulse.Enabled = true;
            };

            btn_addPulse.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(AddPulseActivity));
                Finish();
                StartActivity(nextActivity);
            };

            btn_deletePulse.Click += async (s, e) =>
            {
                await healthAPI.DeletePulse(itemId);

                LoadData();

            };


        }
        private void LoadData()
        {
            var adapter = new PulseListViewAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}