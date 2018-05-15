using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace CalculadoraArray
{ 
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private double ProcessarCommando(string command)
        {
            //Cria um provedor de Código C#
            CSharpCodeProvider mCodeProvider = new CSharpCodeProvider();
            // Cria os parâmetros para a compilação origem
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;      //Não precisa criar um arquivo EXE
            cp.GenerateInMemory = true;         //Cria um na memória
            cp.OutputAssembly = "TempModule";   // Isso não é necessário, no entanto, se usado ​​repetidamente, faz com que o CLR não precisa 
                                                //carregar uma novo assembly cada vez que a função é executada.
            // A string abaixo é basicamente a casca do programa C #, que não faz nada, mas contém um método Avaliar() para nossos propósitos. 

            string TempModuleSource = "namespace ns{" +
                                      "using System;" +
                                      "class class1{" +
                                      "public static double Evaluate(){return " + command + ";}}} ";  //Calcula a expressão

            CompilerResults cr = mCodeProvider.CompileAssemblyFromSource(cp, TempModuleSource);
            if (cr.Errors.Count > 0)
            {
                //Se um erro de compilação é gerado, iremos lançar uma exceção
                //A sintaxe estava errado - novamente, isso é deixado ao implementador para verificar sintaxe antes
                //Chamando a função. O código de chamada pode prender isso em um laço try, e notificar o usuário
                //O comando não foi compreendido, por exemplo.
                throw new ArgumentException("A expressão não pode ser avaliada, utiliza uma expressão C# válida...");
            }
            else
            {
                MethodInfo Methinfo = cr.CompiledAssembly.GetType("ns.class1").GetMethod("Evaluate");
                return (double)Methinfo.Invoke(null, null);
            }
        }

        private void txtBoxVisor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "9";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "8";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "7";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "6";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "5";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "4";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "3";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "2";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "1";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "0";
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + " + ";
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + " - ";
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + " * ";
        }

        private void btnDivi_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + " / ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = "";
            txtBoxVisor.Text = "";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                txtBoxVisor.Text = ProcessarCommando(txtlblResultado.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a avaliar a expressão..." + ex.Message.ToString() + " Obrigado...");
            }
        }

        private void View_Load(object sender, EventArgs e)
        {

        }
    }
}
