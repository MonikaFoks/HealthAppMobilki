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

namespace HealthAppMobilki.Models
{
    public class BloodSugar
    {
        public int Id { get; set; }
        public int  mgdL { get; set; }
        public DateTime Date { get; set; }
        public int userId { get; set; }
    }
}