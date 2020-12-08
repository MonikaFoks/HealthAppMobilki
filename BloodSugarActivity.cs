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
    [Activity(Label = "BloodSugarActivity")]
    public class BloodSugarActivity : Activity
    {
        ListView lstData;
        List<BloodSugar> lstSource = new List<BloodSugar>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            IHealthAPI healthAPI;

            int itemId = 0;
            DateTime itemDate = DateTime.Now;

            SetContentView(Resource.Layout.bloodsugar_layout);

            healthAPI = RestService.For<IHealthAPI>(sessionUser.uriSession);
            lstData = FindViewById<ListView>(Resource.Id.bloodSugarList);

            LoadData();


            var btn_addBS = FindViewById<Button>(Resource.Id.btn_addBloodSugar);
            var btn_deleteBS = FindViewById<Button>(Resource.Id.btn_deleteBloodSugar);
            var btn_loadBS = FindViewById<Button>(Resource.Id.btn_loadBloodSugars);

            btn_loadBS.Click += async (s, e) =>
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

                    List<BloodSugar> bs = await healthAPI.GetBloodSugars();
                    lstSource = bs.FindAll(x => x.userId == sessionUser.Id);

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

                btn_deleteBS.Enabled = true;
            };

            btn_addBS.Click += (s, e) =>
            {
                Intent nextActivity = new Intent(this, typeof(AddBSActivity));
                Finish();
                StartActivity(nextActivity);
            };

            btn_deleteBS.Click += async (s, e) =>
            {
                await healthAPI.DeleteBloodSugar(itemId);

                LoadData();

            };


        }
        private void LoadData()
        {
            var adapter = new BloodSugarListViewAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}