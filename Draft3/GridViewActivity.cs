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
        private Context context;
        GridView grid;
        public GridViewActivity(Context context)
        {
            this.context = context;
        }
        public GridViewActivity()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.grid_layout);
            grid = FindViewById<GridView>(Resource.Id.gridview);
            grid.Adapter = new GridAdapter(this);

            grid.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this, "You Have Clicked an Item", ToastLength.Short).Show();
            };
        }
        public static explicit operator GridViewActivity(View v)
        {
            throw new NotImplementedException();
        }
    }
}