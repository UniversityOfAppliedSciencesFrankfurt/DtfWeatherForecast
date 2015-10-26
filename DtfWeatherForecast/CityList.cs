using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DtfWeatherForecast
{
    public partial class CityList : Form
    {
        public string cityName { get; set; }
        public CityList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// It is a ComboBox for getting Citi Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Bangladesh")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(new object[] {"Aricha","Bhairab","Chittagong","Dhaka","Faridpur","Jamalpur",
                    "Kishoreganj","Khulna","Manikganj","Madaripur","Munshiganj","Mymensingh","Narsingdi",
                    "Rajbari","Rajshahi","Rangpur","Shariatpur","Sherpur","Sylhet","Tangail","Tongi","Gopalganj",

                     });
                comboBox2.SelectedItem = "Dhaka";
            }else if(comboBox1.SelectedItem == "India")
            {
                comboBox2.Items.Clear();
                
                comboBox2.Items.AddRange(new object[] { "Mumbai", "Lucknow", "Kolkata", "Delhi", "Chennai", "Hyderabad", "Kanpur",
                    "Bangalore", "Bhopal", "Visakhapatnam", "Coimbatore", "Jaipur", "Ahmedabad", "Surat", "Pune", "Indore", "Warangal" });
                comboBox2.SelectedItem = "Mumbai";
            }
            else if (comboBox1.SelectedItem == "Germany")
            {
                comboBox2.Items.Clear();
               
                comboBox2.Items.AddRange(new object[] {"Berlin", "Dresden", "Hamburg", "Hanover", "Munich", "Nuremberg", "Cologne", "Duisburg", 
                    "Frankfurt", "Bochum", "Stuttgart", "Wuppertal", "Dusseldorf", "Bonn", "Dortmund", "Bielefeld", "Bremen", "Mannheim", "Leipzig" });
                comboBox2.SelectedItem = "Frankfurt";
            }

        }

        /// <summary>
        /// It is for Ok Button. It sets the value for cityName Property 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != string.Empty)
            {
                cityName = comboBox2.Text;
                this.Hide();
            }
        }
    }
}
