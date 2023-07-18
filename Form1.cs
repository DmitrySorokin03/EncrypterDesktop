using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace EncrypterDesktop
{
    public partial class Form1 : Form
    {
        private static readonly string s_secretKeyError = $"Секретный ключ должен содержать от {Program.KeyMinLength} до {Program.KeyMaxLength} символов и не иметь пробелов!";

        public Form1()
        {
            InitializeComponent();
            this.textBox1.MaxLength = Program.KeyMaxLength;
        }

        private void OnEncryptActivate(object sender, EventArgs e)
        {
            this.label2.Text = "";
            if ((!Program.IsSecretKeyValid(this.textBox1.Text)) || (this.textBox1.ForeColor == Color.Silver))
            {
                this.label2.Text = Form1.s_secretKeyError;
                return;
            }

            OpenFileDialog _openFileDialog = new OpenFileDialog();

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string _filePath = _openFileDialog.FileName;

                string _encryptionKey = System.Text.Encoding.ASCII.GetString(Program.ConvertToAES256Key(this.textBox1.Text));

                Program.EncryptAES256(_filePath, _encryptionKey);
            }
        }

        private void OnDecryptActivate(object sender, EventArgs e)
        {
            this.label2.Text = "";
            if ((!Program.IsSecretKeyValid(this.textBox1.Text)) || (this.textBox1.ForeColor == Color.Silver))
            {
                this.label2.Text = Form1.s_secretKeyError;
                return;
            }

            OpenFileDialog _openFileDialog = new OpenFileDialog();

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string _filePath = _openFileDialog.FileName;

                string _encryptionKey = System.Text.Encoding.ASCII.GetString(Program.ConvertToAES256Key(this.textBox1.Text));

                Program.DecryptAES256(_filePath, _encryptionKey);
            }
        }

        private void OnClearSecretKeyEntryField(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.OnMouseLeaveTextboxSecretKey(sender, e);
            this.label2.Text = "";
        }

        private void OnMouseEnterToEncryptButton(object sender, EventArgs e) => this.button1.BackColor = Color.SeaGreen;

        private void OnMouseLeaveToEncryptButton(object sender, EventArgs e) => this.button1.BackColor = Color.MediumSeaGreen;

        private void OnMouseEnterDecryptButton(object sender, EventArgs e) => this.button2.BackColor = Color.LightCoral;

        private void OnMouseLeaveDecryptButton(object sender, EventArgs e) => this.button2.BackColor = Color.RosyBrown;

        private void OnMouseEnterToClearSecretKeyTextbox(object sender, EventArgs e) => this.button3.BackColor = Color.Teal;

        private void OnMouseLeaveToClearSecretKeyTextbox(object sender, EventArgs e) => this.button3.BackColor = Color.DarkCyan;

        private void OnTextboxSecretKeyActivate(object sender, EventArgs e)
        {
            if (this.textBox1.ForeColor == Color.Silver)
            {
                this.textBox1.Clear();
                this.textBox1.ForeColor = Color.Black;
            }
        }

        private void OnMouseLeaveTextboxSecretKey(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBox1.Text))
            {
                this.textBox1.Clear();
                this.textBox1.ForeColor = Color.Silver;
                this.textBox1.Text = "super_secret_key";
            }
        }
    }
}