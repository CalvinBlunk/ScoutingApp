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
    class ISTable
    {
        [PrimaryKey, AutoIncrement, Column("Id")]

        public int id { get; set; }
        public int Score { get; set; }
        public int Team { get; set; }
        public byte[] Image { get; set; }
    }
}