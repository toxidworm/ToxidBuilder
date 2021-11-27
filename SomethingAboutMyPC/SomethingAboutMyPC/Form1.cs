using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Windows.Forms;

namespace SomethingAboutMyPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);

        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.White;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checksyntax();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();
            string Output = $"{textBox3.Text}.exe";
            Button ButtonObject = (Button)sender;

            textBox1.Text = "";
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Output;
            if (checkBox1.Checked == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string iconame = dialog.FileName;
                    parameters.CompilerOptions = $"/win32icon:{iconame}";
                }
                parameters.OutputAssembly = Output;
            }
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, richTextBox1.Text);

            if (results.Errors.Count > 0)
            {
                textBox1.ForeColor = Color.Red;
                foreach (CompilerError CompErr in results.Errors)
                {
                    textBox1.Text = textBox1.Text +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber +
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                textBox1.ForeColor = Color.Green;
                textBox1.Text = "Build success!";
                MessageBox.Show("Done!");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/8gWgvprJuF");
        }

        private void abbutt_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.ShowDialog();
        }

        public void checksyntax()
        {
            this.CheckKeyword("void", Color.Blue, 0);
            this.CheckKeyword("string", Color.Cyan, 0);
            this.CheckKeyword("using", Color.Aqua, 0);
            this.CheckKeyword("namespace", Color.Cyan, 0);
            this.CheckKeyword("Console", Color.Blue, 0);
            this.CheckKeyword("Write", Color.Cyan, 0);
            this.CheckKeyword("class", Color.Yellow, 0);
            this.CheckKeyword("Class", Color.Yellow, 0);
            this.CheckKeyword("{", Color.Green, 0);
            this.CheckKeyword("}", Color.Green, 0);
            this.CheckKeyword("1", Color.Purple, 0);
            this.CheckKeyword("2", Color.Purple, 0);
            this.CheckKeyword("3", Color.Purple, 0);
            this.CheckKeyword("4", Color.Purple, 0);
            this.CheckKeyword("5", Color.Purple, 0);
            this.CheckKeyword("6", Color.Purple, 0);
            this.CheckKeyword("7", Color.Purple, 0);
            this.CheckKeyword("8", Color.Purple, 0);
            this.CheckKeyword("9", Color.Purple, 0);
            this.CheckKeyword("0", Color.Purple, 0);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            checksyntax();
        }
    }
}
