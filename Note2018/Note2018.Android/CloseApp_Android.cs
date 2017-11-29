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
using Xamarin.Forms;
using Note2018.Droid;

[assembly:Dependency(typeof(CloseApp_Android))]
namespace Note2018.Droid
{
    public class CloseApp_Android:ICloseApp
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}