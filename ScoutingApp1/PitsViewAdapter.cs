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
    class PitsViewAdapter : BaseAdapter<PitsTable>
    {
        public List<PitsTable> mitems;
        public Activity mcontext;



        public PitsViewAdapter(Activity context, List<PitsTable> items)
        {
            mitems = items;
            mcontext = context;

        }
        public override int Count
        {
            
            get {return mitems.Count; }
        } 

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PitsTable this[int position]
        {
            get { return mitems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            try
            {
                if (row == null)
                {

                    row = LayoutInflater.From(mcontext).Inflate(Resource.Layout.list_pits, null);
                }
                var txtTeam = row.FindViewById<TextView>(Resource.Id.txtView_Team);
                string numberSource;
                numberSource = mitems[position].Team.ToString();
                txtTeam.Text = numberSource;
                var txtWeight = row.FindViewById<TextView>(Resource.Id.txtView_Weight);
                txtWeight.Text = mitems[position].RobotWeight;
                var txtDrive = row.FindViewById<TextView>(Resource.Id.txtView_Drive);
                txtDrive.Text = mitems[position].Drivetrain;

            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return row;
            
        }
    }
}