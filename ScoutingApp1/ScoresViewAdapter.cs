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

namespace ScoutingApp1
{
    class ScoresViewAdapter : BaseAdapter<ScoresTable>
    {
        public List<ScoresTable> iitems;
        public Activity icontext;



        public ScoresViewAdapter(Activity context, List<ScoresTable> items)
        {
            iitems = items;
            icontext = context;

        }
        public override int Count
        {

            get { return iitems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ScoresTable this[int position]
        {
            get { return iitems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;

            if (row == null)
            {

                row = LayoutInflater.From(icontext).Inflate(Resource.Layout.truescores_list, null);
            }
            try
            {



                var mnumber = row.FindViewById<TextView>(Resource.Id.txtView_STeam);
                string number = iitems[position].Team.ToString();
                mnumber.Text = number;

                var totalScore = row.FindViewById<TextView>(Resource.Id.txtView_TotalScore);
                string scoreN = iitems[position].TotalScore.ToString();
                totalScore.Text = scoreN;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return row;


        }
    }
}