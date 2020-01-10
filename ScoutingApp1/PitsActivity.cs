using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace ScoutingApp1
{
    [Activity(Label = "PitsActivity")]
    public class PitsActivity : Activity
    {
        Button fromPitHome;
        Button pitSave;
        EditText teamNumber;
        EditText weight;
        RadioGroup dt;
        EditText notes;
        RadioButton mech;
        RadioButton tank;
        RadioButton holo;
        RadioButton swerve;
        RadioButton slide;
        ListView listviewP;


        public List<PitsTable> items = new List<PitsTable>();



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.pits_layout);

            

            fromPitHome = FindViewById<Button>(Resource.Id.buttonPS2);
            dt = FindViewById<RadioGroup>(Resource.Id.radioGroupPS1);
            teamNumber = FindViewById<EditText>(Resource.Id.editTextPS1);
            weight = FindViewById<EditText>(Resource.Id.editTextPS35);
            notes = FindViewById<EditText>(Resource.Id.editTextPS2);
            pitSave = FindViewById<Button>(Resource.Id.buttonPS1);
            mech = FindViewById<RadioButton>(Resource.Id.radioPS1);
            tank = FindViewById<RadioButton>(Resource.Id.radioPS2);
            holo = FindViewById<RadioButton>(Resource.Id.radioPS3);
            swerve = FindViewById<RadioButton>(Resource.Id.radioPS4);
            slide = FindViewById<RadioButton>(Resource.Id.radioPS5);
            listviewP = FindViewById<ListView>(Resource.Id.listViewP);
            

            fromPitHome.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            pitSave.Click += Create_Click;
     

                ClearP();

          
        }
        private void Create_Click(object sender, EventArgs e)
        {
            try
            {

                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<PitsTable>();
                PitsTable tbl = new PitsTable();
                db.CreateTable<ISTable>();
                ISTable ist = new ISTable();
                ScoresTable st = new ScoresTable();
                int finalScore;
                int firstScore;
                int secondScore;
                secondScore = 0;
                finalScore = 0;
                firstScore = 0;
    
                int number = Int32.Parse(teamNumber.Text);
                tbl.Team = number;
                st.Team = number;
                ist.Team = number;

                //interesting issue-- it's not storing anything for the ints

                tbl.RobotWeight = weight.Text;
                if (mech.Checked)
                {
                    tbl.Drivetrain = "Mechanum";
                    firstScore = 1;

                }
                if (holo.Checked)
                {
                    tbl.Drivetrain = "Holonomic";
                    firstScore = 2;

                }
                if (tank.Checked)
                {
                    tbl.Drivetrain = "Tank";
                    firstScore = 3;

                }
                if (swerve.Checked)
                {
                    tbl.Drivetrain = "Swerve";
                    firstScore = 4;
  
                }
                if (slide.Checked)
                {
                    tbl.Drivetrain = "Slide";
                    firstScore = 0;

                }

                tbl.Notes = notes.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully", ToastLength.Short).Show();
               
                items = db.Table<PitsTable>().OrderBy(item => item.Team).ToList();


                PitsViewAdapter adapterP = new PitsViewAdapter(this, items);

                    listviewP.Adapter = adapterP;
                
                int numberW = Int32.Parse(weight.Text);

                if (numberW < 50)
                {
                    secondScore = 1;

                }
                if (numberW >= 50)
                {
                    secondScore = 3;

                }

                finalScore = firstScore + secondScore;
                ist.Score = finalScore;
                st.TotalScore = finalScore;
                System.Diagnostics.Debug.WriteLine(finalScore);

  
                db.Insert(tbl);
                db.Insert(ist);
                db.Insert(st);


            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }

        }

      
        void ClearP()
        {
            mech.Checked = false;
            tank.Checked = false;
            holo.Checked = false;
            swerve.Checked = false;
            slide.Checked = false;
            weight.Text = "";
            teamNumber.Text = "";
            notes.Text = "";

        }
    }
}
