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
    class ImageTable
    {
        public int Id { get; set; }
        public int Team { get; set; }
        public byte[] Image { get; set; }
        public string User { get; set; }
    }
}