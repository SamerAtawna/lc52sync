using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LC52Sync
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }
        private string sourceDirName = "c:\\test";
        private string destDirName = @"\\localhost\ttt";


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var ipAddress in listBox1.Items)
            {
                FileSystemAccessRule accRule = new FileSystemAccessRule("samer", FileSystemRights.FullControl, AccessControlType.Allow);

                // use the currently iterated list box item
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                WindowsIdentity idnt = new WindowsIdentity("samer", "123456");


                foreach (string dirPath in Directory.GetDirectories(sourceDirName, "*",
        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(sourceDirName, @"\\" + ipAddress.ToString()));

                    foreach (string newPath in Directory.GetFiles(sourceDirName, "*.*",
                            SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(sourceDirName, @"\\" + ipAddress.ToString()), true);
 


            }


      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
