using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liberty_Travel_And_Tours
{
    public partial class Form6 : Form
    {
        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "df2ecc9bdfa921ff9e7e65dff95829fa1d2b721a",
            BasePath = "https://traveltourism-e35ef-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient Client;
        public Form6()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private  void Form6_Load(object sender, EventArgs e)
        {
           
            Client = new FirebaseClient(config);
        }
        void PopulateDataGrid(Dictionary<string, touristVisaDatabase> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
           
            dataGridView1.Columns.Add("Firstname", "First Name");
            dataGridView1.Columns.Add("Lastname", "Last Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Cnic", "Cnic");
            dataGridView1.Columns.Add("Passportno", "Passport No");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("Martialst", "Martialst");
            dataGridView1.Columns.Add("Visatype", "Visatype");
            dataGridView1.Columns.Add("Dob", "Dob");
            dataGridView1.Columns.Add("Photo", "Photo");
            dataGridView1.Columns.Add("Idcopy", "Idcopy");
            dataGridView1.Columns.Add("Passcopy", "Passport");
            dataGridView1.Columns.Add("Passportissue", "Passport Issue Date");
            dataGridView1.Columns.Add("Passportexpiry", "Passport Expiry");
            dataGridView1.Columns.Add("Gender", "Gender");
            dataGridView1.Columns.Add("Phoneno", "Phone No");
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("status", "Status");
            foreach (var item in record)
            {
                dataGridView1.Rows.Add(item.Value.Firstname, item.Value.Lastname, item.Value.Email,
                    item.Value.Cnic,item.Value.Passportno,item.Value.Age,item.Value.Martialst,item.Value.Visatype,item.Value.Dob,item.Value.Photo,
                    item.Value.Idcopy,item.Value.Passcopy,
                    item.Value.Passportissue,item.Value.Passportexpiry,item.Value.Gender,item.Value.Phoneno,item.Value.Country,item.Value.status);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = Client.Get(@"EmployementVisa");

            if (!string.IsNullOrEmpty(response.Body))
            {
                // Deserialize into List<touristVisaDatabase>
                List<EmployementVisa> data = JsonConvert.DeserializeObject<List<EmployementVisa>>(response.Body);

                // Pass the list to the method for populating the DataGridView
                PopulateDataGrid(data);
            }
            else
            {
                MessageBox.Show("No data found in the database.");
            }
        }
        void PopulateDataGrid(List<EmployementVisa> record)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Firstname", "First Name");
            dataGridView2.Columns.Add("Lastname", "Last Name");
            dataGridView2.Columns.Add("Email", "Email");
            dataGridView2.Columns.Add("Cnic", "Cnic");
            dataGridView2.Columns.Add("Passportno", "Passport No");
            dataGridView2.Columns.Add("Age", "Age");
            dataGridView2.Columns.Add("Martialst", "Martialst");
            dataGridView2.Columns.Add("Visatype", "Visatype");
            dataGridView2.Columns.Add("Dob", "Dob");
            dataGridView2.Columns.Add("Photo", "Photo");
            dataGridView2.Columns.Add("Idcopy", "Idcopy");
            dataGridView2.Columns.Add("Passcopy", "Passport");
            dataGridView2.Columns.Add("Passportissue", "Passport Issue Date");
            dataGridView2.Columns.Add("Passportexpiry", "Passport Expiry");
            dataGridView2.Columns.Add("Gender", "Gender");
            dataGridView2.Columns.Add("Phoneno", "Phone No");
            dataGridView2.Columns.Add("Country", "Country");
            
            foreach (var item in record)
            {

                if (item.status == "Pending")
                {
                    dataGridView2.Rows.Add(item.Firstname, item.Lastname, item.Email,
                    item.Cnic, item.Passportno, item.Age, item.Martialst, item.Visatype, item.Dob, item.Photo,
                    item.Idcopy, item.Passcopy,
                    item.Passportissue, item.Passportexpiry, item.Gender, item.Phoneno, item.Country, item.status == "Activate");
                    //break;

                }
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            round3.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            round13.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            round1.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
            round2.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
            round4.Text = dataGridView2.Rows[index].Cells[4].Value.ToString();
            round5.Text = dataGridView2.Rows[index].Cells[5].Value.ToString();
            round6.Text = dataGridView2.Rows[index].Cells[6].Value.ToString();
            round7.Text = dataGridView2.Rows[index].Cells[7].Value.ToString();
            round9.Text = dataGridView2.Rows[index].Cells[8].Value.ToString();
            pictureBox6.Text = dataGridView2.Rows[index].Cells[9].Value.ToString();
            round10.Text = dataGridView2.Rows[index].Cells[10].Value.ToString();
            round11.Text = dataGridView2.Rows[index].Cells[11].Value.ToString();
            pictureBox4.Text = dataGridView2.Rows[index].Cells[12].Value.ToString();
            round12.Text = dataGridView2.Rows[index].Cells[13].Value.ToString();
            round8.Text = dataGridView2.Rows[index].Cells[14].Value.ToString();
            round14.Text = dataGridView2.Rows[index].Cells[15].Value.ToString();
            pictureBox5.Text = dataGridView2.Rows[index].Cells[16].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            round3.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            round13.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            round1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            round2.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            round4.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            round5.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            round6.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            round7.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            round9.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
            pictureBox6.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();
            round10.Text = dataGridView1.Rows[index].Cells[10].Value.ToString();
            round11.Text = dataGridView1.Rows[index].Cells[11].Value.ToString();
            pictureBox4.Text = dataGridView1.Rows[index].Cells[12].Value.ToString();
            round12.Text = dataGridView1.Rows[index].Cells[13].Value.ToString();
            round8.Text = dataGridView1.Rows[index].Cells[14].Value.ToString();
            round14.Text = dataGridView1.Rows[index].Cells[15].Value.ToString();
            pictureBox5.Text = dataGridView1.Rows[index].Cells[16].Value.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = Client.Get(@"touristVisaDatabase");

            if (!string.IsNullOrEmpty(response.Body))
            {
                // Deserialize into List<touristVisaDatabase>
                List<touristVisaDatabase> data = JsonConvert.DeserializeObject<List<touristVisaDatabase>>(response.Body);

                // Pass the list to the method for populating the DataGridView
                PopulateDataGrid1(data);
            }
            else
            {
                MessageBox.Show("No data found in the database.");
            }
        }
        void PopulateDataGrid1(List<touristVisaDatabase> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Firstname", "First Name");
            dataGridView1.Columns.Add("Lastname", "Last Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Cnic", "Cnic");
            dataGridView1.Columns.Add("Passportno", "Passport No");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("Martialst", "Martialst");
            dataGridView1.Columns.Add("Visatype", "Visatype");
            dataGridView1.Columns.Add("Dob", "Dob");
            dataGridView1.Columns.Add("Photo", "Photo");
            dataGridView1.Columns.Add("Idcopy", "Idcopy");
            dataGridView1.Columns.Add("Passcopy", "Passport");
            dataGridView1.Columns.Add("Passportissue", "Passport Issue Date");
            dataGridView1.Columns.Add("Passportexpiry", "Passport Expiry");
            dataGridView1.Columns.Add("Gender", "Gender");
            dataGridView1.Columns.Add("Phoneno", "Phone No");
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("status", "Status");
            foreach (var item in record)
            {

                if (item.status == "Pending")
                {
                    dataGridView1.Rows.Add(item.Firstname, item.Lastname, item.Email,
                    item.Cnic, item.Passportno, item.Age, item.Martialst, item.Visatype, item.Dob, item.Photo,
                    item.Idcopy, item.Passcopy,
                    item.Passportissue, item.Passportexpiry, item.Gender, item.Phoneno, item.Country, item.status == "Activate");
                    //break;
                     
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_4(object sender, EventArgs e)
        {
            FirebaseResponse response = Client.Get(@"touristVisaDatabase");

            if (!string.IsNullOrEmpty(response.Body))
            {
                // Deserialize into List<touristVisaDatabase>
                List<touristVisaDatabase> data = JsonConvert.DeserializeObject<List<touristVisaDatabase>>(response.Body);

                // Pass the list to the method for populating the DataGridView
                PopulateDataGrid2(data);
            }
            else
            {
                MessageBox.Show("No data found in the database.");
            }
        }
        void PopulateDataGrid2(List<touristVisaDatabase> record)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Firstname", "First Name");
            dataGridView1.Columns.Add("Lastname", "Last Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Cnic", "Cnic");
            dataGridView1.Columns.Add("Passportno", "Passport No");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("Martialst", "Martialst");
            dataGridView1.Columns.Add("Visatype", "Visatype");
            dataGridView1.Columns.Add("Dob", "Dob");
            dataGridView1.Columns.Add("Photo", "Photo");
            dataGridView1.Columns.Add("Idcopy", "Idcopy");
            dataGridView1.Columns.Add("Passcopy", "Passport");
            dataGridView1.Columns.Add("Passportissue", "Passport Issue Date");
            dataGridView1.Columns.Add("Passportexpiry", "Passport Expiry");
            dataGridView1.Columns.Add("Gender", "Gender");
            dataGridView1.Columns.Add("Phoneno", "Phone No");
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("status", "Status");
            foreach (var item in record)
            {
                    dataGridView1.Rows.Add(item.Firstname, item.Lastname, item.Email,
                    item.Cnic, item.Passportno, item.Age, item.Martialst, item.Visatype, item.Dob, item.Photo,
                    item.Idcopy, item.Passcopy,
                    item.Passportissue, item.Passportexpiry, item.Gender, item.Phoneno, item.Country,item.status);
            }
            // Enable DataGridView cell click event to allow selecting a row
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Example: Display a message box with the selected record's First Name
                string selectedFirstName = selectedRow.Cells["Firstname"].Value.ToString();
                MessageBox.Show($"Selected Record: {selectedFirstName}");

                // Now, you can implement a form or dialog to allow the user to input updated data
                // and then use that data to update the corresponding record in the database.
                // You can use the selectedFirstName (or other unique identifier) to find the record in the 'record' list.
                // After the user updates the data, you can update the 'record' list and update the DataGridView.
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }
    }
}
