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
    [Activity(Label = "ScoresActivity")]
    public class ScoresActivity : Activity
    {
        List<ISTable> listis = new List<ISTable>();
        List<PitsTable> listp = new List<PitsTable>();
        ListView listviewI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<ISTable>();
            ISTable tbl = new ISTable();
            db.CreateTable<PitsTable>();
            PitsTable pits = new PitsTable();
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.scores_layout);
            listviewI = FindViewById<ListView>(Resource.Id.listViewIS);
            listis = db.Table<ISTable>().OrderBy(item => item.Team).ToList();
            ImageViewAdapter adapterI = new ImageViewAdapter(this, listis);
     
            listviewI.Adapter = adapterI;

        }
    }
}
    