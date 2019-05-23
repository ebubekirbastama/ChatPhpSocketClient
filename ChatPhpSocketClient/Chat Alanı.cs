using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ChatPhpSocketClient
{
    public partial class Chat_Alanı : MetroForm
    {
        public Chat_Alanı()
        {
            InitializeComponent();
        }

        private void Chat_Alanı_Load(object sender, EventArgs e)
        {
          
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
               listBox1.Items.Add( new Client("ipadresi", 1234).start(metroTextBox2.Text));
                metroTextBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bekra Hayr Nester Chat");
            }
        }
    }
}
