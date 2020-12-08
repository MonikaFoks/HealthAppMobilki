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

    [Activity(Label = "PressureActivity")]
    public class PressureActivity : Activity
    {
        ListView lstData;
        List<Pressure> lstSource = new List<Pressure>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            IHealthAPI healthAPI;

            SetContentView(Resource.Layout.pressure_layout);

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);

            int itemId = 0;
            DateTime itemDate = DateTime.Now;

            lstData = FindViewById<ListView>(Resource.Id.pressureList);

            LoadData();

            var btn_addPressure = FindViewById<Button>(Resource.Id.btn_addPressure);
            var btn_loadPressures = FindViewById<Button>(Resource.Id.btn_loadPressures);
            var btn_deletePressure = FindViewById<Button>(Resource.Id.btn_deletePressure);


            btn_loadPressures.Click += async (s, e) =>
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

                    List<Pressure> pressures = await healthAPI.GetPressures();
                    lstSource = pressures.FindAll(x => x.userId == sessionUser.Id);

                    dialog.Dismiss();
                    LoadData();

                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, "" + ex.Message, ToastLength.Long).Show();
                }
            };

            btn_addPressure.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(AddPressureActivity));
                Finish();
                StartActivity(nextActivity);
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

                btn_deletePressure.Enabled = true;
            };

            btn_deletePressure.Click += async (s, e) =>
            {
                await healthAPI.DeletePressure(itemId);

                LoadData();

            };
        }



        private void LoadData()
        {
            var adapter = new PressureListViewAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}