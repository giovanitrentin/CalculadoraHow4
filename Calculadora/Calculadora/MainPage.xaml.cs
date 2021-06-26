using Jace;
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        //Usando Observable para que se alterado aqui, atualiza lá na front.
        public ObservableCollection<Texto> Items { get; set; }
        public string atual { get; set; }
        public int numero { get; set; }

        CalculationEngine engine = new CalculationEngine();

        public MainPage()
        {
            InitializeComponent();
            //Inicia a lista dos itens da calculadora.
            if (Items == null)
            {
                Items = new ObservableCollection<Texto>();
                Items.Add(new Texto{ Numero = 1, Palavra = "777" } );
            }

            atual = "";
            numero = 1;

            BindingContext = this;
        }

        public void Inteligencia(string valor)
        {
            //Usado para realizar o calculo
            //https://github.com/pieterderycke/Jace
            Texto remover = null;
            Texto add = null;

            //For para saber a ação a tomar.
            foreach (Texto item in Items)
            {
                if (item.Numero == numero)
                {
                    if (valor.Equals("z"))
                    {
                        if (atual.Length >= 1)
                        {
                            atual = atual.Trim().Substring(0, atual.Length - 1);
                        }
                    }
                    else
                    {
                        atual = atual.Trim() + valor;
                    }
                    remover = item;
                    add = new Texto { Numero = numero, Palavra = atual + "    "};
                }
            }
            Items.Remove(remover);
            Items.Add(add);
        }

        private void OnButtonClickedAbre(object sender, EventArgs e)
        {
            Inteligencia("(");
        }

        private void OnButtonClickedFecha(object sender, EventArgs e)
        {
            Inteligencia(")");
        }

        private void OnButtonClickedMais(object sender, EventArgs e)
        {
            Inteligencia("+");
        }

        private void OnButtonClickedSete(object sender, EventArgs e)
        {
            Inteligencia("7");
        }

        private void OnButtonClickedOito(object sender, EventArgs e)
        {
            Inteligencia("8");
        }

        private void OnButtonClickedNove(object sender, EventArgs e)
        {
            Inteligencia("9");
        }

        private void OnButtonClickedVezes(object sender, EventArgs e)
        {
            Inteligencia("*");
        }

        private void OnButtonClickedQuatro(object sender, EventArgs e)
        {
            Inteligencia("4");
        }

        private void OnButtonClickedCinco(object sender, EventArgs e)
        {
            Inteligencia("5");
        }

        private void OnButtonClickedSeis(object sender, EventArgs e)
        {
            Inteligencia("6");
        }

        private void OnButtonClickedMenos(object sender, EventArgs e)
        {
            Inteligencia("-");
        }

        private void OnButtonClickedUm(object sender, EventArgs e)
        {
            Inteligencia("1");
        }

        private void OnButtonClickedDois(object sender, EventArgs e)
        {
            Inteligencia("2");
        }

        private void OnButtonClickedTres(object sender, EventArgs e)
        {
            Inteligencia("3");
        }

        private void OnButtonClickedZerp(object sender, EventArgs e)
        {
            Inteligencia("0");
        }
   
        private void OnButtonClickedIgual(object sender, EventArgs e)
        {
            try
            {
                //Quando =, soma os valoes e incrementa a linha
                double result = engine.Calculate(atual);
                numero++;
                atual = result.ToString();
                Items.Add(new Texto { Numero = numero, Palavra = atual + "    " });
            }
            catch 
            {
                DisplayAlert("Atenção!", "Sua expressão está errada!", "Sim, vou corrigir...");
            }
        }

        private void OnButtonClickedLimpa(object sender, EventArgs e)
        {
            Inteligencia("z");
        }

        private void OnButtonClickedPerc(object sender, EventArgs e)
        {
            //Função para limpar a tela.
            Items.Clear();
            Items.Add(new Texto { Numero = 1, Palavra = "" });
            atual = "";
            numero = 1;
        }

        private void OnButtonClickedDiv(object sender, EventArgs e)
        {
            Inteligencia("/");
        }

        private void OnButtonClickedVirgula(object sender, EventArgs e)
        {
            Inteligencia(",");
        }

    }

    public class Texto
    {
        public int Numero { get; set; }
        public string Palavra { get; set; }
    }
}
