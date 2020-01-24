using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Draft3
{
    [Activity(Label = "PitsActivity")]
    public class PitsActivity : Activity
    {
        EditText teamNumber;
        EditText robotWeight;
        RadioButton mech;
        RadioButton tank;
        RadioButton holo;
        RadioButton swerve;
        RadioButton slide;
        EditText dLength;
        EditText dWidth;
        EditText dHeight;
        EditText autoS;
        RadioButton e1;
        RadioButton e2;
        RadioButton e3;
        RadioButton e4;
        RadioButton e5;
        RadioButton d1;
        RadioButton d2;
        RadioButton d3;
        RadioButton d4;
        RadioButton d5;
        RadioButton q1;
        RadioButton q2;
        RadioButton q3;
        RadioButton q4;
        RadioButton q5;
        RadioButton sy;
        RadioButton sn;
        RadioButton cy;
        RadioButton cn;
        RadioButton cLy;
        RadioButton cLn;
        EditText notes;
        Button save;
        Button home;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.pits_display);

            teamNumber = FindViewById<EditText>(Resource.Id.editTextPS1);
            robotWeight = FindViewById<EditText>(Resource.Id.editTextPS35);
            mech = FindViewById<RadioButton>(Resource.Id.radioPS1);
            tank = FindViewById<RadioButton>(Resource.Id.radioPS2);
            holo = FindViewById<RadioButton>(Resource.Id.radioPS3);
            swerve = FindViewById<RadioButton>(Resource.Id.radioPS4);
            slide = FindViewById<RadioButton>(Resource.Id.radioPS5);
            dLength = FindViewById<EditText>(Resource.Id.editTextPS4);
            dWidth = FindViewById<EditText>(Resource.Id.editTextPS5);
            dHeight = FindViewById<EditText>(Resource.Id.editTextPS6);
            autoS = FindViewById<EditText>(Resource.Id.editTextPS7);
            e1 = FindViewById<RadioButton>(Resource.Id.radioPS11);
            e2 = FindViewById<RadioButton>(Resource.Id.radioPS12);
            e3 = FindViewById<RadioButton>(Resource.Id.radioPS13);
            e4 = FindViewById<RadioButton>(Resource.Id.radioPS14);
            e5 = FindViewById<RadioButton>(Resource.Id.radioPS15);
            d1 = FindViewById<RadioButton>(Resource.Id.radioPS16);
            d2 = FindViewById<RadioButton>(Resource.Id.radioPS17);
            d3 = FindViewById<RadioButton>(Resource.Id.radioPS18);
            d4 = FindViewById<RadioButton>(Resource.Id.radioPS19);
            d5 = FindViewById<RadioButton>(Resource.Id.radioPS20);
            q1 = FindViewById<RadioButton>(Resource.Id.radioPS6);
            q2 = FindViewById<RadioButton>(Resource.Id.radioPS7);
            q3 = FindViewById<RadioButton>(Resource.Id.radioPS8);
            q4 = FindViewById<RadioButton>(Resource.Id.radioPS9);
            q5 = FindViewById<RadioButton>(Resource.Id.radioPS10);
            sy = FindViewById<RadioButton>(Resource.Id.radioPS51);
            sn = FindViewById<RadioButton>(Resource.Id.radioPS52);
            cy = FindViewById<RadioButton>(Resource.Id.radioPS61);
            cn = FindViewById<RadioButton>(Resource.Id.radioPS62);
            cLy = FindViewById<RadioButton>(Resource.Id.radioPS71);
            cLn = FindViewById<RadioButton>(Resource.Id.radioPS72);
            notes = FindViewById<EditText>(Resource.Id.editTextPS2);
            save = FindViewById<Button>(Resource.Id.buttonPS1);
            home = FindViewById<Button>(Resource.Id.buttonPS2);

            home.Click += delegate
            {
                StartActivity(typeof(HomeActivity));
            };

            save.Click += Save;

            Clear();
        }

        public void Save(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<PitsTable>();
                PitsTable pits = new PitsTable();

                int number = Int32.Parse(teamNumber.Text);
                pits.Team = number;

                pits.RobotWeight = robotWeight.Text;

                if (mech.Checked)
                {
                    pits.Drivetrain = "Mechanum";
                }
                else if (holo.Checked)
                {
                    pits.Drivetrain = "Holonomic";
                }
                else if (tank.Checked)
                {
                    pits.Drivetrain = "Tank";
                }
                else if (swerve.Checked)
                {
                    pits.Drivetrain = "Swerve";
                }
                else if (slide.Checked)
                {
                    pits.Drivetrain = "Slide";
                }
                else
                {
                    Toast.MakeText(this,"Please Select a Drivetrain", ToastLength.Long).Show();
                }

                string dimensions = (dLength.Text + "x" + dWidth.Text + "x" + dHeight.Text);
                pits.Dimensions = dimensions;

                pits.Auto = autoS.Text;

                if (e1.Checked)
                {
                    pits.Electronics = "1";
                }
                else if (e2.Checked)
                {
                    pits.Electronics = "2";
                }
                else if (e3.Checked)
                {
                    pits.Electronics = "3";
                }
                else if (e4.Checked)
                {
                    pits.Electronics = "4";
                }
                else if (e5.Checked)
                {
                    pits.Electronics = "5";
                }
                else
                {
                    Toast.MakeText(this, "Please Select an Electronics Grade", ToastLength.Long).Show();
                }

                if (d1.Checked)
                {
                    pits.Chassis = "1";
                }
                else if (d2.Checked)
                {
                    pits.Chassis = "2";
                }
                else if (d3.Checked)
                {
                    pits.Chassis = "3";
                }
                else if (d4.Checked)
                {
                    pits.Chassis = "4";
                }
                else if (d5.Checked)
                {
                    pits.Chassis = "5";
                }
                else
                {
                    Toast.MakeText(this, "Please Select a Chassis Grade", ToastLength.Long).Show();
                }

                if (q1.Checked)
                {
                    pits.Build = "1";
                }
                else if (q2.Checked)
                {
                    pits.Build = "2";
                }
                else if (q3.Checked)
                {
                    pits.Build = "3";
                }
                else if (q4.Checked)
                {
                    pits.Build = "4";
                }
                else if (q5.Checked)
                {
                    pits.Build = "5";
                }
                else
                {
                    Toast.MakeText(this, "Please Select an Overall Build Grade", ToastLength.Long).Show();
                }

                if (sy.Checked)
                {
                    pits.Spinner = "Yes";
                }
                else if (sn.Checked)
                {
                    pits.Spinner = "No";
                }
                else
                {
                    Toast.MakeText(this, "Select if Spinner Can Be Used", ToastLength.Long).Show();
                }

                if (cy.Checked)
                {
                    pits.Cameras = "Yes";
                }
                else if (cn.Checked)
                {
                    pits.Cameras = "No";
                }
                else 
                {
                    Toast.MakeText(this, "Select if Robot has Driver Cameras", ToastLength.Long).Show();
                }

                if (cLy.Checked)
                {
                    pits.Climb = "Yes";
                }
                else if (cLn.Checked)
                {
                    pits.Climb = "No";
                }
                else
                {
                    Toast.MakeText(this, "Select if Robot Can Climb", ToastLength.Long).Show();
                }
                
                pits.Notes = notes.Text;

               db.Insert(pits);
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }

        void Clear()
        {
            teamNumber.Text = "";
            robotWeight.Text = "";
            mech.Checked = false;
            tank.Checked = false;
            holo.Checked = false;
            swerve.Checked = false;
            slide.Checked = false;
            dLength.Text = "";
            dWidth.Text = "";
            dHeight.Text = "";
            autoS.Text = "";
            e1.Checked = false;
            e2.Checked = false;
            e3.Checked = false;
            e4.Checked = false;
            e5.Checked = false;
            d1.Checked = false;
            d2.Checked = false;
            d3.Checked = false;
            d4.Checked = false;
            d5.Checked = false;
            q1.Checked = false;
            q2.Checked = false;
            q3.Checked = false;
            q4.Checked = false;
            q5.Checked = false;
            notes.Text = "";
        }
    }
}