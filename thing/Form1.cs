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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace thing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cti = new StreamReader("Sport.txt");

            FileStream data = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter zapis = new BinaryWriter(data, Encoding.GetEncoding("UTF-8"));

            int osc = 0;
            String jmeno = "";
            string prijmeni = "";
            char pohlavi;
            int vyska = 0;
            int hmotnost = 0;

            while (!cti.EndOfStream)
            {
                string[] pole = (cti.ReadLine()).Split(';');
                osc = int.Parse(pole[0]);
                jmeno = pole[1];
                prijmeni = pole[2];
                pohlavi = Convert.ToChar(pole[3]);
                vyska = int.Parse(pole[4]);
                hmotnost = int.Parse(pole[5]);

                zapis.Write(osc);
                zapis.Write(jmeno);
                zapis.Write(prijmeni);
                zapis.Write(pohlavi);
                zapis.Write(vyska);
                zapis.Write(hmotnost);
            }
            zapis.Close();
            cti.Close();

            FileStream data2 = new FileStream("sport.dat", FileMode.Open, FileAccess.Read);
            BinaryReader cteni = new BinaryReader(data2);
            cteni.BaseStream.Position = 0;
            while (cteni.BaseStream.Position < cteni.BaseStream.Length)
            {
                listBox1.Items.Add(cteni.ReadInt32().ToString() + " " + cteni.ReadString() + " " + cteni.ReadString() + " " + cteni.ReadChar().ToString() + " " + cteni.ReadInt32().ToString() + " " + cteni.ReadInt32().ToString());
            }
            data.Close();
        }
    }
}
