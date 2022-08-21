using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Media;


// https://stackoverflow.com/questions/16904251/get-default-user-account-profile-picture-on-windows-vista-8
namespace Unimmersive.Shell.Methods
{
    internal class UserTileMethods
    {
        [DllImport("shell32.dll", EntryPoint = "#261",
            CharSet = CharSet.Unicode, PreserveSig = false)]
            public static extern void GetUserTilePath(string username,
            UInt32 whatever, // 0x80000000
            StringBuilder picpath, int maxLength);

        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }

        public static ImageSource getImage(string username)
        {
            return ImageBitmapMethods.ToImageSource((Bitmap)Image.FromFile(GetUserTilePath(username)));
        }
    }
}
