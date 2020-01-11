using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Verification
{
    [Activity(Label = "Recover")]
    public class Recover : Activity
    {
        private EditText recoveryAddress;

        private Button usernameRecovery;
        private Button forgotPassword;
        private Button passwordRecovery;
        private Button recover;
        private Button recoverySwitcher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Register.isEmail)
            {
                SetContentView(Resource.Layout.recovery_email);
            }
            else
            {
                SetContentView(Resource.Layout.recovery_phone);
            }

            recoveryAddress = FindViewById<EditText>(Resource.Id.recoveryAddress);

            usernameRecovery = FindViewById<Button>(Resource.Id.usernameRecovery);
            recover = FindViewById<Button>(Resource.Id.recover);
            recoverySwitcher = FindViewById<Button>(Resource.Id.recoverySwitcher);

            recoverySwitcher.Click += RecoverySwitcher_Click;
            forgotPassword.Click += ForgotPassword_Click;
        }

        private void RecoverySwitcher_Click(object sender, EventArgs e)
        {
            Register.isEmail = !Register.isEmail;
            if (Register.isEmail)
            {
                SetContentView(Resource.Layout.recovery_email);
            }
            else
            {
                SetContentView(Resource.Layout.recovery_phone);
            }
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            if (Register.isEmail)
            {
                if (recoveryAddress.Text != null)
                {
                    Toast.MakeText(this, "This needs to be written further", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Missing email address", ToastLength.Short).Show();
                }
            }
            else
            {
                if (recoveryAddress.Text != null)
                {
                    Toast.MakeText(this, "This needs to be written further", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Missing phone number", ToastLength.Short).Show();
                }
            }
        }

        private void UsernameRecovery_Click(object sender, EventArgs e)
        {
            // Write further
        }
    }
}