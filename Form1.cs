using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace sublimeText_autoPatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFile(object sender, EventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.DefaultExt = "*.exe";
            openFile.ShowDialog();
            if (openFile.CheckFileExists)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(openFile.FileName, FileMode.Open, FileAccess.ReadWrite)))
                {
                    int offset = 5987213; //position you want to start editing
                    byte[] new_data = new byte[] { 0x33, 0xC0, 0xFE, 0xC0, 0xC3, 0x57, 0x55, 0x53, 0xB8, 0x28, 0x21, 0x00, 0x00 }; //new data
                    writer.Seek(offset, SeekOrigin.Begin); //move your cursor to the position
                    //String memoria = writer.Seek(offset, SeekOrigin.Begin).ToString();
                    //MessageBox.Show(memoria);
                    writer.Write(new_data);//write it
                    int offsetDos = 7821178;
                    byte[] new_dataDos = new byte[] { 0x73, 0x75, 0x62, 0x6C, 0x69, 0x6D, 0x65, 0x68, 0x71, 0x2E, 0x6C, 0x6F, 0x63, 0x61, 0x6C, 0x68, 0x6F, 0x73, 0x74, 0x00, 0x00 }; //new data
                    writer.Seek(offsetDos, SeekOrigin.Begin); //move your cursor to the position
                    //String memoria = writer.Seek(offset, SeekOrigin.Begin).ToString();
                    writer.Write(new_dataDos);//write it

                    MessageBox.Show("Step 1 completed, now follow step 2");
                    txtKey.Text = "----- BEGIN LICENSE -----\r\nCyberTitus\r\nUnlimited User License\r\nEA7E-81044230\r\n0C0CD4A8 CAA317D9 CCABD1AC 434C984C\r\n7E4A0B13 77893C3E DD0A5BA1 B2EB721C\r\n4BAAB4C4 9B96437D 14EB743E 7DB55D9C\r\n7CA26EE2 67C3B4EC 29B2C65A 88D90C59\r\nCB6CCBA5 7DE6177B C02C2826 8C9A21B0\r\n6AB1A5B6 20B09EA2 01C979BD 29670B19\r\n92DC6D90 6E365849 4AB84739 5B4C3EA1\r\n048CC1D0 9748ED54 CAC9D585 90CAD815\r\n------ END LICENSE ------";
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
