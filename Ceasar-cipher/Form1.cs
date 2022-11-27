using System.IO;

namespace Ceasar_cipher
{
    public partial class Form1 : Form
    {
        Ceasar c;
        public Form1()
        {
            InitializeComponent();
            c = new Ceasar();
        }
        OpenFileDialog openFile;
        SaveFileDialog saveFile;
        public int i = 0;
        private void openButton_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                inputTextBox.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            saveFile.Filter = "|*.txt";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.Write(outputTextBox.Text);
                sw.Close();
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (keyTextBox.Text == "") return;
            if (c.isNumber(keyTextBox.Text) == true)
            {
                c.SetKey(keyTextBox.Text);
                outputTextBox.Text = c.Encrypt(inputTextBox.Text);
            }
            else
            {
                outputTextBox.Text = "Key phải là số nguyên dương, pls !";
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (keyTextBox.Text == "") return;
            if (c.isNumber(keyTextBox.Text))
            {
                c.SetKey(keyTextBox.Text);
                outputTextBox.Text = c.Decrypt(inputTextBox.Text);
            }
            else
            {
                outputTextBox.Text = "Key phải là số nguyên dương, pls !";
            }
        }

        private void detectButton_Click(object sender, EventArgs e)
        {
            i++;
            if(i == 27)
            {
                i = 1;
            }
            c.SetKey(Convert.ToString(i));
            keyTextBox.Text = Convert.ToString(i);
            outputTextBox.Text = c.Decrypt(inputTextBox.Text);
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            keyTextBox.Text = "";
            i = 0;
            inputTextBox.Focus();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inputTextBox.Text == "")
            {
                outputTextBox.Text = "";
            }
        }
    }
}