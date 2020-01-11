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
    public class GridAdapter : BaseAdapter
    {
        private ArrayAdapter<string> ad;
        private readonly string[] teamNumbers = {
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
        private readonly Context context;

        public GridAdapter(Context c)
        {
            context = c;
        }

        public override int Count
        {
            get { return teamNumbers.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return teamNumbers[position];
        }

        public override long GetItemId(int position)
        {
            return 0;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TextView gridView;

            if (convertView == null)
            {
                gridView = new TextView(context);
            }
            else
            {
                gridView = (TextView)convertView;
            }
            gridView.SetText(Int32.Parse(teamNumbers[position]));
            return gridView;
        }
    }
}
