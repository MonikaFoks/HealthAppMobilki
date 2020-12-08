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
    public class PulseViewHolder : Java.Lang.Object
    {
        public TextView txtBpm { get; set; }
        public TextView txtDate { get; set; }
    }

    public class PulseListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Pulse> lstPulse;

        public PulseListViewAdapter(Activity activity, List<Pulse> lstPulse)
        {
            this.activity = activity;
            this.lstPulse = lstPulse;
        }

        public override int Count
        {
            get
            {
                return lstPulse.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPulse[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listPulseViewData_template, parent, false);
            var txtBpm = view.FindViewById<TextView>(Resource.Id.textPulseView1);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textPulseView2);

            txtBpm.Text = "" + lstPulse[position].Bpm;
            txtDate.Text = "" + lstPulse[position].Date;

            return view;
        }
    }
}