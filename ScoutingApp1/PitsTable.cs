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
   public class PitsTable
    {
        [PrimaryKey, AutoIncrement, Column("Id")]

        public int id { get; set; }
        public string User { get; set; }
        public int Team { get; set; }
        [MaxLength(4)]
        public string RobotWeight { get; set; }
        public string Drivetrain { get; set; }
        public string Notes { get; set; }

        public override string ToString() { return $"[PitsTable: id={id}, Team={Team}, Weight={RobotWeight}, Drive={Drivetrain}, Notes={Notes}]"; }
    }
}