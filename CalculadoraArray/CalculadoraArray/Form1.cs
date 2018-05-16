using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler; //fornece classes para representar a estrutura lógica do código-fonte (possibilita anexar outras linguagem).
using System.Reflection;

namespace CalculadoraArray
{ 
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private double Calculador(string expressao)
        {
            //fornece acesso a instâncias do gerador de código C# e do compilador de código.
            CSharpCodeProvider moduloProvedor = new CSharpCodeProvider();

            // Cria os parmaetros para a compilação origem
            CompilerParameters moduloCompilador = new CompilerParameters();
                                                                                   //********************Calcula a expressão***********************
            string Resolver = "namespace ns{" + "using System;" + "class class1{" + "public static double Evaluate(){return " + expressao + ";}}} ";  
            

            //representa o resultado da compilação que é retornado a partir do compilador.
            CompilerResults cr = moduloProvedor.CompileAssemblyFromSource(moduloCompilador, Resolver);

            //retorna mensagem de erro caso a expressão seja invalida.
            if (cr.Errors.Count > 0)
            {
                throw new ArgumentException("Inválida");
            }
            else
            {
                MethodInfo Methinfo = cr.CompiledAssembly.GetType("ns.class1").GetMethod("Evaluate");
                return (double)Methinfo.Invoke(null, null);
            }
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
            txtlblResultado.Text = txtlblResultado.Text + "+";
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "-";
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "*";
        }

        private void btnDivi_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "/";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                txtBoxVisor.Text = txtlblResultado.Text + " = " + Calculador(txtlblResultado.Text).ToString();
                txtlblResultado.Text = "Resultado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Expressão " + ex.Message.ToString());
            }
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = "";
            txtBoxVisor.Text = "Resultado";
        }

        private void btnPfim_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + ")";
        }

        private void btnPInit_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + "(";
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            txtlblResultado.Text = txtlblResultado.Text + ".";
        }
    }
}
