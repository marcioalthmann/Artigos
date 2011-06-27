using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CollatzSilverlight
{
    public partial class MainPage : UserControl
    {
        private Dictionary<int, int> numeros;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Collatz_Click(object sender, RoutedEventArgs e)
        {
            int numero;
            int.TryParse(Numero.Text, out numero);

            if (numero == 0)
                return;

            numeros = new Dictionary<int, int>();
            CollatzConjecture(numero);
        }

        private void CollatzConjecture(int numero)
        {
            var total = 0;
            while (numero > 1)
            {
                total++;
                numeros.Add(total, numero);

                if (numero % 2 == 0)
                    numero = numero / 2;
                else
                    numero = 3 * numero + 1;
            }

            total++;
            numeros.Add(total, numero);

            ((LineSeries)Chart.Series[0]).ItemsSource = numeros;
        }
    }
}
