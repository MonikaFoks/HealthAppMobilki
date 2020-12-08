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
    public class WeightViewHolder : Java.Lang.Object
    {
        public TextView txtKgs { get; set; }
        public TextView txtDate { get; set; }
    }

    public class WeightListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Weight> lstWeight;

        public WeightListViewAdapter(Activity activity, List<Weight> lstWeight)
        {
            this.activity = activity;
            this.lstWeight = lstWeight;
        }

        public override int Count
        {
            get
            {
                return lstWeight.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstWeight[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listWeightViewData_template, parent, false);
            var txtKgs = view.FindViewById<TextView>(Resource.Id.textWeightView1);
            var txtDate = view.FindViewById<TextView>(Resource.Id.textWeightView2);

            txtKgs.Text = "" + lstWeight[position].Kgs;
            txtDate.Text = "" + lstWeight[position].Date;

            return view;
        }
    }
}