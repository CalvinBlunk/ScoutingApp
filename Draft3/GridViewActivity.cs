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

namespace Draft3
{
    [Activity(Label = "GridView")]
    public class GridViewActivity : Activity
    {
        GridView grid;
        private ArrayAdapter<string> ad;
        private readonly string[] teamNumbers = new string[]{
            "254",
            "1320",
            "235",
            "43",
            "4499",
            "232",
            "312",
            "123",
            "25",
            "3452",
            "1232",
            "1290",
            "2299",
            "867",
            "90",
            "99",
            "723",
            "112"
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.grid_layout);
            grid = FindViewById<GridView>(Resource.Id.gridview);


            ad = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, teamNumbers);
            grid.Adapter = ad;
            grid.ItemClick += ShowClick;
        }
        public void ShowClick(object sender, AdapterView.ItemClickEventArgs e) {
            
            Toast.MakeText(this, "GridView item clicked : " + ad.GetItem(e.Position), ToastLength.Short).Show();
        }
    }
}
