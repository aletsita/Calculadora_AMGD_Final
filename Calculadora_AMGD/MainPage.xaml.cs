using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Calculadora_AMGD
{
    public partial class MainPage : ContentPage
    {
        double numeroActual = 0;
        double PrimerNum = 0;
        string operacionActual;
        bool Operador = false;
        bool resultadoMostrado = false;

        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Limpiar(object sender, EventArgs e)
        {
            numeroActual = 0;
            PrimerNum = 0;
            Resultado.Text = "0";
            operacionActual = null;
            resultadoMostrado = false;
        }

        void Button_Eliminar(object sender, EventArgs e)
        {
            if (Resultado.Text.Length > 1)
            {
                Resultado.Text = Resultado.Text.Substring(0, Resultado.Text.Length - 1);
                numeroActual = double.TryParse(Resultado.Text, out double result) ? result : 0;
            }
            else
            {
                Resultado.Text = "0";
                numeroActual = 0;
            }
        }

        void Button_Numero(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            string numero = boton.Text;

            if (Resultado.Text == "0" || Operador || resultadoMostrado)
            {
                Resultado.Text = numero;
                Operador = false;
                resultadoMostrado = false;
            }
            else
            {
                Resultado.Text += numero;
            }

            double.TryParse(Resultado.Text, out numeroActual);
        }

        void Button_Suma(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                PrimerNum = numeroActual;
                operacionActual = "+";
                Operador = true;
            }
        }

        void Button_Resta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                PrimerNum = numeroActual;
                operacionActual = "-";
                Operador = true;
            }
        }

        void Button_Multiplicacion(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                PrimerNum = numeroActual;
                operacionActual = "*";
                Operador = true;
            }
        }

        void Button_Dividir(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                PrimerNum = numeroActual;
                operacionActual = "/";
                Operador = true;
            }
        }

        void Button_Resultado(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Resultado.Text))
            {
                double SegundoNum = numeroActual;
                double resultado = 0;

                switch (operacionActual)
                {
                    case "+":
                        resultado = PrimerNum + SegundoNum;
                        break;
                    case "-":
                        resultado = PrimerNum - SegundoNum;
                        break;
                    case "*":
                        resultado = PrimerNum * SegundoNum;
                        break;
                    case "/":
                        if (SegundoNum != 0)
                        {
                            resultado = PrimerNum / SegundoNum;
                        }
                        else
                        {
                            Resultado.Text = "ERROR";
                            return;
                        }
                        break;
                }

                Resultado.Text = resultado.ToString();
                resultadoMostrado = true;
            }
        }

        void Button_Decimal(object sender, EventArgs e)
        {
            if (!Resultado.Text.Contains("."))
            {
                Resultado.Text += ".";
            }
        }
    }
}
