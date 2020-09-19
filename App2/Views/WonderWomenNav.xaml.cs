using App2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string nome;
        private string email;
        private string cel;

        public MainPage()
        {
            InitializeComponent();

            WonderWomen.Source = "https://mdh-chat.metasix.solutions/livechat?mode=popout";
            WonderWomen.Navigated += (o, s) =>
            {
                _ = DelayActionAsync(2000);
            };

            var newCadastro = new WonderWoman();

            newCadastro.Nome = "Teste Fiap da Silva";
            newCadastro.Email = "teste.fiap@email.com";
            newCadastro.Cel = "(11)99999-8888";

            App.DbCon.SaveWonderWomanAsync(newCadastro);

            async void Mostrar()
            {
                var s = await App.DbCon.GetWonderWomanAsync();
                foreach (var z in s)
                {
                    nome = z.Nome;
                    email = z.Email;
                    cel = z.Cel;
                }
            }

            Mostrar();

            async Task DelayActionAsync(int delay)
            {
                await Task.Delay(delay);

                await WonderWomen.EvaluateJavaScriptAsync($"document.getElementById('guestName').value = '{nome}'");
                await WonderWomen.EvaluateJavaScriptAsync($"document.getElementById('guestEmail').value = '{email}'");
                await WonderWomen.EvaluateJavaScriptAsync($"document.getElementById('guestPhone').value = '{cel}'");
            }
        }
        void BtnHide_Clicked(object sender, EventArgs e)
        {
            WonderWomen.HeightRequest = 0;
            WonderWomen.WidthRequest = 0;
            btnShow.IsVisible = true;
            btnHide.IsVisible = false;
            fundo.BackgroundColor = Color.Transparent;
        }

        void BtnShow_Clicked(object sender, EventArgs e)
        {
            WonderWomen.HeightRequest = 1000;
            WonderWomen.WidthRequest = 1000;
            btnShow.IsVisible = false;
            btnHide.IsVisible = true;
            fundo.BackgroundColor = Color.White;
        }

        void BtnClose_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
