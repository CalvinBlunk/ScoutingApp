using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScoutingApp1
{
    class ImageViewAdapter : BaseAdapter<ISTable>
    {
        public List<ISTable> iitems;
        public Activity icontext;



        public ImageViewAdapter(Activity context, List<ISTable> items)
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

        public override ISTable this[int position]
        {
            get { return iitems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;

            if (row == null)
            {

                row = LayoutInflater.From(icontext).Inflate(Resource.Layout.scores_display, null);
            }
            try
            {

                var mpics = row.FindViewById<ImageView>(Resource.Id.ImageViewR);
                Bitmap bmp = BitmapFactory.DecodeByteArray(iitems[position].Image, 0, iitems[position].Image.Length);
                mpics.SetImageBitmap(bmp);



                var mnumber = row.FindViewById<TextView>(Resource.Id.teamnumber);
                string number = iitems[position].Team.ToString();
                mnumber.Text = number;


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
          
            return row;


        }
    }
}
