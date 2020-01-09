using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Media;
using SQLite;

namespace Draft3
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        Button toData;
        Button takePhotos;
        Button viewData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home_display);

            toData = FindViewById<Button>(Resource.Id.buttonHome1);
            takePhotos = FindViewById<Button>(Resource.Id.buttonHome2);
            viewData = FindViewById<Button>(Resource.Id.buttonHome3);

            CreateDB();

            takePhotos.Click += TakePhoto;
            viewData.Click += delegate
            {
                StartActivity(typeof(GridViewActivity));
            };
            toData.Click += delegate
            {
                StartActivity(typeof(PitsActivity));
            };
        }
        public string CreateDB()
       {
            var output = "";
            output += "Creating Database if it doesn't exist";
            string dpPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Draft3Data.db3");
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created";
            return output;
        }
        async void TakePhoto(object sender, System.EventArgs e)
        {
            string dpPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<ImageTable>();
            ImageTable tbl = new ImageTable();
            var userdata = FindViewById<EditText>(Resource.Id.edittextT);

            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                CompressionQuality = 40,
                Name = "highlanders.jpg",
                Directory = "sample"
            });

            if(file == null)
            {
                return;
            }

            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            tbl.Image = imageArray;
            db.Insert(tbl);

            LayoutInflater layoutInflater = LayoutInflater.From(this);
            View view = layoutInflater.Inflate(Resource.Layout.photo_alert, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
            alertbuilder.SetView(view);

            alertbuilder.SetCancelable(false).SetPositiveButton("Submit", delegate
            {
                int numberT;
                Int32.TryParse(userdata.Text, out numberT);
                tbl.Team = numberT;
                db.Insert(tbl);
            });

            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();
        }
    }
}