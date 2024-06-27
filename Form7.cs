using FireSharp.Config;
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
    public partial class Form7 : Form
    {
        public Form7()
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
        private void Form7_Load(object sender, EventArgs e)
        {
            touristVisaDatabase tt = new touristVisaDatabase();
            label4.Text = $"Hello {tt.Firstname} {tt.Lastname}, enter your details:";
            try
            {
                Client = new FireSharp.FirebaseClient(config);
            }
            catch

            {
                MessageBox.Show("connects error");
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "select image";
            ofd.Filter = "Image Files(*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
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
                string.IsNullOrWhiteSpace(round10.Text) ||
                string.IsNullOrWhiteSpace(round11.Text) ||
                string.IsNullOrWhiteSpace(round10.Text))
            {
                // Throw an exception if any of the required fields are empty
                MessageBox.Show("Please enter all fields.");
            }

            //MemoryStream ms2 = new MemoryStream();
            //pictureBox4.Image.Save(ms2, ImageFormat.Jpeg);
            //byte[] a2 = ms2.GetBuffer();
            //string output2 = Convert.ToBase64String(a2);

            bookingSeats tt = new bookingSeats();

            //tt.Return = round3.Text;
            tt.NearestAirport = round13.Text;
            tt.Returnsame = round3.Text;
            tt.Passportno = int.Parse(round1.Text);
            tt.ReturnDate = round2.Text;
            tt.Emailbook = round4.Text;
            tt.Destination = round10.Text;
            tt.DateForTakeOf = round11.Text;
            FirebaseResponse pushResponse = await Client.PushAsync("bookingSeats/" + tt.sno, tt);
                tt.sno++;
                int newKey = pushResponse.ResultAs<bookingSeats>().sno;
                pictureBox4.Image = null;

                MessageBox.Show("Your Flight is Booked Now. You will receive your ticket via email soon. Have a HAPPY JOURNEY!");
            
            
            //pictureBox4.Image = null;


            //MessageBox.Show("Your Filght is Book Now " +
              //  "You Get Your Tciket on Mail Soon.." +
                //"... HAPPY JOURNEY!!!");
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f = new Form4();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }
    }
}
