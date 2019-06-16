using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IsCoolManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : MasterDetailPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
            Detail = new PageHome();
            IsPresented = false;

            BtHome_Clicked(new Object(), new EventArgs());
        }


        private void BtHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageHome());
            IsPresented = false;
        }

        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastrar());
            IsPresented = false;
        }

        private async void BtListar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageListar());
            IsPresented = false;
            
        }

        private void BtCadastrarTarefa_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastrarTarefa());
        }

        private void BtListarTarefas_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageListarTarefa());
        }
      
    }
}