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
using SQLite;

namespace HealthAppMobilki.Models
{
    public class Pressure
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int userId { get; set; }
        public DateTime Date { get; set; }
    }
}