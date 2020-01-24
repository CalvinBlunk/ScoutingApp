using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Draft3
{
    class ImageAdapter : BaseAdapter<ImageTable>
    {
        public List<ImageTable> iitems;
        public Activity icontext;



        public ImageAdapter(Activity context, List<ImageTable> items)
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

        public override ImageTable this[int position]
        {
            get { return iitems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;

            if (row == null)
            {

                row = LayoutInflater.From(icontext).Inflate(Resource.Layout.image_display, null);
            }
            try
            {

                var mpics = row.FindViewById<ImageView>(Resource.Id.ImageViewR);
                Android.Graphics.Bitmap bmp = BitmapFactory.DecodeByteArray(iitems[position].Image, 0, iitems[position].Image.Length);
                mpics.SetImageBitmap(bmp);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return row;
        }
    }
}