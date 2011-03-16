using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace EasingAnimations
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
		    Loaded += (obj, args) =>
		                  {
		                      ModoDaAnimacao.ItemsSource = new ModoDeAnimacao().ObterModosDeAnimacao();
		                      ModoDaAnimacao.SelectedIndex = 0;
		                      FuncaoDaAnimacao.ItemsSource = new FuncaoDeAnimacao().ObterFuncoesDeAnimacao();
		                      FuncaoDaAnimacao.SelectedIndex = 0;
		                  };
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
		    var funcaoDaAnimacao = ObterFuncaoDaAnimacao();
		    Funcao.EasingFunction = funcaoDaAnimacao;
			Animacao.Begin();
		}

	    private EasingMode ObterModoDaAnimacao()
	    {
	        var modoDaAnimacao = new EasingMode();
	        switch (ModoDaAnimacao.SelectedValue.ToString())
	        {
	            case "EaseIn":
	                modoDaAnimacao = EasingMode.EaseIn;
	                break;
                case "EaseOut":
	                modoDaAnimacao = EasingMode.EaseOut;
	                break;
                case "EaseInOut":
	                modoDaAnimacao = EasingMode.EaseInOut;
	                break;
	        }

	        return modoDaAnimacao;
	    }

        private IEasingFunction ObterFuncaoDaAnimacao()
        {
            EasingFunctionBase funcaoDaAnimacao = null;
            
            switch (FuncaoDaAnimacao.SelectedValue.ToString())
            {
                case "BackEase":
                    funcaoDaAnimacao =  new BackEase();
                    break;
                case "BounceEase":
                    funcaoDaAnimacao = new BounceEase();
                    break;
                case "CircleEase":
                    funcaoDaAnimacao = new CircleEase();
                    break;
                case "CubicEase":
                    funcaoDaAnimacao = new CubicEase();
                    break;
                case "ElasticEase":
                    funcaoDaAnimacao = new ElasticEase();
                    break;
                case "ExponentialEase":
                    funcaoDaAnimacao = new ExponentialEase();
                    break;
                case "PowerEase":
                    funcaoDaAnimacao = new PowerEase();
                    break;
                case "QuadraticEase":
                    funcaoDaAnimacao = new QuadraticEase();
                    break;
                case "QuarticEase":
                    funcaoDaAnimacao = new QuarticEase();
                    break;
                case "QuinticEase":
                    funcaoDaAnimacao = new QuinticEase();
                    break;
                case "SineEase":
                    funcaoDaAnimacao = new SineEase();
                    break;
            }

            funcaoDaAnimacao.EasingMode = ObterModoDaAnimacao();
            return funcaoDaAnimacao;
        }
	}

    public class ModoDeAnimacao
    {
        public string Nome { get; set; }

        public IList<ModoDeAnimacao> ObterModosDeAnimacao()
        {
            return new List<ModoDeAnimacao>
                       {
                           new ModoDeAnimacao {Nome = "EaseIn"},
                           new ModoDeAnimacao {Nome = "EaseOut"},
                           new ModoDeAnimacao {Nome = "EaseInOut"},
                       };
        }
    }

    public class FuncaoDeAnimacao
    {
        public string Nome { get; set; }

        public IList<FuncaoDeAnimacao> ObterFuncoesDeAnimacao()
        {
            return new List<FuncaoDeAnimacao>
                       {
                           new FuncaoDeAnimacao{Nome = "BackEase"},
                           new FuncaoDeAnimacao{Nome = "BounceEase"},
                           new FuncaoDeAnimacao{Nome = "CircleEase"},
                           new FuncaoDeAnimacao{Nome = "CubicEase"},
                           new FuncaoDeAnimacao{Nome = "ElasticEase"},
                           new FuncaoDeAnimacao{Nome = "ExponentialEase"},
                           new FuncaoDeAnimacao{Nome = "PowerEase"},
                           new FuncaoDeAnimacao{Nome = "QuadraticEase"},
                           new FuncaoDeAnimacao{Nome = "QuinticEase"},
                           new FuncaoDeAnimacao{Nome = "SineEase"}
                       };
        }
    }
}