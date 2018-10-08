using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS2018WFA
{
    public partial class Form1 : Form
    {
        Controller C = new Controller();
        public Form1()
        {
            InitializeComponent();
            C.FlushText += viewEventHandler; // associo il codice all'handler nella applogic
        }
        private void viewEventHandler(object sender, string textToWrite)
        { txtConsole.AppendText(textToWrite + Environment.NewLine); }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            C.doSomething(); // logica applicative }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string dbConn = db_path.Text;
            C.searchClients(dbConn);
        }

        private void btn_id_param_Click(object sender, EventArgs e)
        {
            string dbConn = db_path.Text;
            C.searchClientsByID(Convert.ToInt32(box_id.Text));
        }
    }
}
