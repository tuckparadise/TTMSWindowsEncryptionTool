using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TTMSWindowsEncryptionTool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string error = "";
            if (txtPlainText.Text.Trim() =="")
            {
                error = "Plain Text Field cannot be blank";                
            }

            if (error != "")
            {
                MessageBox.Show(error);                
            }
            else
            {
                Process compiler = new Process();
                compiler.StartInfo.FileName = "TTMSEncryptText.exe";
                compiler.StartInfo.Arguments = "encrypt " + txtPlainText.Text.Trim();
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardError = true;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.Start();

                string result = compiler.StandardOutput.ReadToEnd();

                compiler.WaitForExit();

                if (compiler.ExitCode == 0)
                {
                    txtEncryptedText.Text = result.Trim();
                }
                else
                {
                    MessageBox.Show("Unable to get the result");
                }

                /*
                Process p = Process.Start("TTMSEncryptText.exe " + txtPlainText.Text.Trim());
                p.BeginOutputReadLine();
                p.WaitForExit();
                Console.WriteLine("myapp.exe returned {0}", p.ExitCode);
                if (p.ExitCode == 0)
                {

                }
                */
            }
        }
    }
}
