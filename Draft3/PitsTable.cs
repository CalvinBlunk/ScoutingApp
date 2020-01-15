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

namespace Draft3
{
    class PitsTable
    {
        [PrimaryKey, AutoIncrement, Column("Id")]

        public int Id { get; set; }
        public int Team { get; set; }
        [MaxLength(4)]
        public string RobotWeight { get; set; }
        public string Drivetrain { get; set; }
        public string Dimensions { get; set; }
        public string Auto { get; set; }
        public string Build { get; set; }
        public string Electronics { get; set; }
        public string Chassis { get; set; }
        public string Notes { get; set; }
        public string User { get; set; }
        public override string ToString() { return $"[PitsTable: id={Id}, Team={Team}]"; }
    }
}