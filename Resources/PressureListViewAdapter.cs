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

namespace HealthAppMobilki.Resources
{
    public class PressureViewHolder : Java.Lang.Object
    {
        public TextView txtSyst { get; set; }
        public TextView txtDiast { get; set; }
        public TextView txtDate { get; set; }
    }

    public class PressureListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Pressure> lstPressure;

        public PressureListViewAdapter(Activity activity, List<Pressure> lstPressure)
        {
            this.activity = activity;
            this.lstPressure = lstPressure;
        }

        public override int Count
        {
            get
            {
                return lstPressure.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPressure[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listPressureViewData_template, parent, false);
            var txtSystDiast = view.FindViewById<TextView>(Resource.Id.textPressureView1);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textPressureView2);

            txtSystDiast.Text = "" + lstPressure[position].Systolic + " / " + lstPressure[position].Diastolic;
            txtDate.Text = "" + lstPressure[position].Date;

            return view;
        }
    }
}