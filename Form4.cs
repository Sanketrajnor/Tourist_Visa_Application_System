﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Liberty_Travel_And_Tours
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        IFirebaseClient Client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "df2ecc9bdfa921ff9e7e65dff95829fa1d2b721a",
            BasePath = "https://traveltourism-e35ef-default-rtdb.firebaseio.com/"
        };
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                Client = new FireSharp.FirebaseClient(config);
            }
            catch

            {
                MessageBox.Show("connects error");
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox2.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());
            }
        }

        private async void bround1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(round3.Text) ||
                string.IsNullOrWhiteSpace(round13.Text) ||
                string.IsNullOrWhiteSpace(round1.Text) ||
                string.IsNullOrWhiteSpace(round2.Text) ||
                string.IsNullOrWhiteSpace(round4.Text) ||
                string.IsNullOrWhiteSpace(round5.Text) ||
                string.IsNullOrWhiteSpace(round6.Text) ||
                string.IsNullOrWhiteSpace(round7.Text) ||
                string.IsNullOrWhiteSpace(round9.Text) ||
                string.IsNullOrWhiteSpace(round10.Text) ||
                string.IsNullOrWhiteSpace(round11.Text) ||
                string.IsNullOrWhiteSpace(round12.Text) ||
                string.IsNullOrWhiteSpace(round8.Text) ||
                string.IsNullOrWhiteSpace(round14.Text) ||
                string.IsNullOrWhiteSpace(round15.Text))
            {
                // Throw an exception if any of the required fields are empty
                MessageBox.Show("Please enter all fields.");
            }

            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();
            string output=Convert.ToBase64String(a);


            MemoryStream ms2 = new MemoryStream();
            pictureBox4.Image.Save(ms2, ImageFormat.Jpeg);
            byte[] a2 = ms2.GetBuffer();
            string output2 = Convert.ToBase64String(a2);

            MemoryStream ms3 = new MemoryStream();
            pictureBox5.Image.Save(ms3, ImageFormat.Jpeg);
            byte[] a3 = ms3.GetBuffer();
            string output3 = Convert.ToBase64String(a3);
          


            touristVisaDatabase tt = new touristVisaDatabase();

                tt.Firstname = round3.Text;
                tt.Lastname = round13.Text;
                tt.Email = round1.Text;
                tt.Cnic = int.Parse(round2.Text);
                tt.Passportno = int.Parse(round4.Text);
                tt.Age = int.Parse(round5.Text);
                tt.Martialst = round6.Text;
                tt.Visatype = round7.Text;
                tt.Dob = round9.Text;
                tt.Photo = output;
                tt.Idcopy = output2;
                tt.Passcopy = output3;
                tt.Passportissue = round10.Text;
                tt.Passportexpiry = round11.Text;
                tt.Gender = round12.Text;
                tt.Phoneno = round8.Text;
                tt.Country = round14.Text;
                tt.status = round15.Text;
            
            FirebaseResponse pushResponse= await Client.PushAsync("touristVisaDatabase/"+ tt.sno, tt);
            tt.sno++;
            int newKey = pushResponse.ResultAs<touristVisaDatabase>().sno;
            pictureBox2.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;

            MessageBox.Show("Your Record Saved Successfully... HAPPY JOURNEY!!!");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox4.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                pictureBox5.Image = image.GetThumbnailImage(250, 200, null, new IntPtr());

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private void bround2_Click(object sender, EventArgs e)
        {
            
        }

        private void bround2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }
    }
}
