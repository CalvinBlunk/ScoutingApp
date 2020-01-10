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

namespace ScoutingApp1
{
    class ScoresTable
    {
        [PrimaryKey, AutoIncrement, Column("Id")]

        public int id { get; set; }
        public int Team { get; set; }
        public int PitScore { get; set; }
        public int FieldScore { get; set; }
        public int TotalScore { get; set; }
    }
}