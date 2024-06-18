using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace argo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection collection = new Suggestion().getItemList();

                ItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                ItemName.AutoCompleteCustomSource = collection;
            }
            catch (Exception ee)
            {
                Console.WriteLine("MEKA FORM EKEEEEEEE.........");
                Console.WriteLine(ee);
            }
        }
    }
}
