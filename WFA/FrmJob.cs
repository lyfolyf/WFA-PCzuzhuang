using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class FrmJob : Form
    {
        public FrmJob()
        {
            InitializeComponent();


            string[] jobs =  Directory.GetDirectories(Application.StartupPath + "\\HDEV");
            if (jobs.Length > 0)
            {
                for (int i = 0; i < jobs.Length; i++)
                {
                    string[] ss = jobs[i].Split('\\') ;
                    cbJob.Items.Add(ss[ss.Length-1]);
                }
                if (cbJob.Items.Count > 0)
                {
                    cbJob.SelectedIndex = 0;
                }
            }

 
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SysConfig.DefaultJob = cbJob.Text;
            SysConfig.INIConfig.IniWriteValue("System", "DefaultJob", cbJob.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
