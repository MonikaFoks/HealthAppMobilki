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
    public class BloodSugarViewHolder : Java.Lang.Object
    {
        public TextView txtMgdL { get; set; }
        public TextView txtDate { get; set; }
    }

    public class BloodSugarListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<BloodSugar> lstBloodSugar;

        public BloodSugarListViewAdapter(Activity activity, List<BloodSugar> lstBloodSugar)
        {
            this.activity = activity;
            this.lstBloodSugar = lstBloodSugar;
        }

        public override int Count
        {
            get
            {
                return lstBloodSugar.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstBloodSugar[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listBloodSugarViewData_template, parent, false);
            var txtMgdL = view.FindViewById<TextView>(Resource.Id.textBloodSugarView1);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textBloodSugarView2);

            txtMgdL.Text = "" + lstBloodSugar[position].mgdL;
            txtDate.Text = "" + lstBloodSugar[position].Date;

            return view;
        }
    }
}