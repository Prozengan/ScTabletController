using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScTabletController
{
    public partial class ScControllerScreen : Form
    {
        BluetoothClientManager bluetoothClient = new BluetoothClientManager("DESKTOP-LDD3AUA");
        public ScControllerScreen()
        {
            InitializeComponent();
        }

        /***************************************************** BOUTONS *****************************************************/

        private void resetInterface_Click(object sender, EventArgs e)
        {
            landingGears.Checked = false;
            doorOpening.Checked = false;
            doorLock.Checked = false;
        }

        private void landingGears_CheckedChanged(object sender, EventArgs e)
        {
            Tools.writeInLogFile("> landingGears_CheckedChanged");
            switchButtonColor(landingGears);
            sendBluetoothMessage("VK_N");
        }

        private void doorOpening_CheckedChanged(object sender, EventArgs e)
        {
            Tools.writeInLogFile("> doorOpening_CheckedChanged");
            switchButtonColor(doorOpening);
            sendBluetoothMessage("VK_O");

        }
        private void doorLock_CheckedChanged(object sender, EventArgs e)
        {
            Tools.writeInLogFile("> doorLock_CheckedChanged");
            switchButtonColor(doorLock);
            sendBluetoothMessage("VK_L");

        }

        private void btConnect_CheckedChanged(object sender, EventArgs e)
        {
            Tools.writeInLogFile("> btConnect_CheckedChanged");
            if (btConnect.Checked)
            {
                btConnect.BackColor = Color.Orange;
                btConnect.Enabled = false;
                bluetoothClient.Start();
                bluetoothClient.IsConnected += BluetoothClient_IsConnected;
            }
        }

        /***************************************************** SCROLLS *****************************************************/
        private void miningPower_Scroll(object sender, EventArgs e)
        {

        }

        /***************************************************** ACTIONS *****************************************************/
        private void switchButtonColor(CheckBox cb)
        {
            if (cb.Checked)
            {
                cb.BackColor = Color.Khaki;
            }
            else
            {
                cb.BackColor = Color.White;
            }
        }

        private void BluetoothClient_IsConnected(object sender, EventArgs e)
        {
            Tools.writeInLogFile("> BluetoothClient_IsConnected");
            btConnect.BackColor = Color.GreenYellow;
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    btConnect.BackColor = Color.GreenYellow;
                }));
            }
        }

        private void sendBluetoothMessage(string message)
        {
            Tools.writeInLogFile("> sendBluetoothMessage");
            // Ajout du nombre de caractères du codeKey
            int messageLength = message.Length;
            message = messageLength.ToString() + '/' + message;
            bluetoothClient.SyncMessage(message);
        }


        /****************************************************** SYSTEM *****************************************************/
        private void ScControlScreen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
