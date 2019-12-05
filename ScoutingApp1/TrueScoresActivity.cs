using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "TrueScoresActivity")]
    public class TrueScoresActivity : Activity
    {
        List<ScoresTable> listS = new List<ScoresTable>();
        ListView listviewS;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<ScoresTable>();
            ScoresTable st = new ScoresTable();

            SetContentView(Resource.Layout.truescores_layout);

            listviewS = FindViewById<ListView>(Resource.Id.listViewSS);
            listS = db.Table<ScoresTable>().OrderBy(item => item.TotalScore).ToList();
            ScoresViewAdapter adapterS = new ScoresViewAdapter(this, listS);

            listviewS.Adapter = adapterS;


        }
    }
}