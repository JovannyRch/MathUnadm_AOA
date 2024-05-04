using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


enum Operacion
{
    Suma,
    Resta,
    Multiplicacion
}

namespace MathUnadm_AOA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private double Resultado;
        private Operacion TipoOperador = Operacion.Suma;

        private int NumeroAciertos = 0;
        private int NumeroErrores = 0;
        private double PorcentajeAciertos = 0;
        private bool FlagCorrect = false;


        public Game()
        {
            InitializeComponent();
            GenerateRandomValues();
            fallos.Text = NumeroErrores.ToString();
            aciertos.Text = NumeroAciertos.ToString();
            porcentaje.Text = PorcentajeAciertos.ToString() + "%";
        }

   

        private void Evaluar()
        {
            if (FlagCorrect) return;
            if (userInput.Text == "") return;
            double entradaUsuario = double.Parse(userInput.Text);


            FlagCorrect = true;
            if (entradaUsuario.ToString("0.00") == Resultado.ToString("0.00"))
            {
                //Show alert
                DisplayAlert("Aviso", "Correcto", "OK");

                NumeroAciertos++;
            }
            else
            {
                DisplayAlert("Aviso", "Incorrecto", "OK");
                NumeroErrores++;
            }

            if(NumeroErrores == 0)
            {
                PorcentajeAciertos = 100;
            }
            else
            {
                int total = NumeroAciertos + NumeroErrores;
                PorcentajeAciertos = (NumeroAciertos * 100) / total;
            }

            porcentaje.Text = PorcentajeAciertos.ToString("0.00") + "%";

            aciertos.Text = NumeroAciertos.ToString();
            fallos.Text = NumeroErrores.ToString();

        }

        private void GenerateRandomValues()
        {
            FlagCorrect = false;
            userInput.Text = "";
            Random random = new Random();

            double val1 = 0.0;
            double val2 = 0.0;
            TipoOperador = (Operacion)random.Next(0, 3);

            switch (TipoOperador)
            {
                case Operacion.Suma:
                    operando.Text = "+"; 
                    val1 = random.Next(1, 50);
                    val2 = random.Next(1, 50);
                    Resultado = val1 + val2;
                    break;
                case Operacion.Resta:
                    operando.Text = "-";
                    val1 = random.Next(1, 50);
                    val2 = random.Next(1, 50);

                    if (val1 < val2)
                    {
                        double temp = val1;
                        val1 = val2;
                        val2 = temp;
                    }

                    Resultado = val1 - val2;
                    break;
                case Operacion.Multiplicacion:
                    operando.Text = "*";
                    val1 = random.Next(1, 10);
                    val2 = random.Next(1, 10);
                    Resultado = val1 * val2;
                    break;
               
            }
            operador1.Text = val1.ToString();
            operador2.Text = val2.ToString();
        }

        private void Exit(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void DispathEvaluar(object sender, EventArgs e)
        {
            Evaluar();
        }

        private void DispathGenerateRandomValues(object sender, EventArgs e)
        {
            if (userInput.Text == "") return;
            GenerateRandomValues();
        }
    }
}