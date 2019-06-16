using IsCoolManager.Controller;
using IsCoolManager.Model;
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
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
            AtualizaLista();
        }
        

        /*public void InserirItens()
        {
            ModelDisciplinas disciplina = new ModelDisciplinas();

            disciplina.Nome = "Teste Nome";
            disciplina.NotaMeta = 60;

            ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);
            dbDisciplinas.InserirDisciplinas(disciplina);
            DisplayAlert("Resultado da operação: ", dbDisciplinas.StatusMessage, "OK");
        }*/
        

        public void AtualizaLista()
        {

            string nome = "";

            if (txtDisciplina.Text != null)
            {
                nome = txtDisciplina.Text;
            }

            ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);

            if (swAndamentoDisciplina.IsToggled)
            { // disciplinas em andamento
                ListaDisciplinas.ItemsSource = dbDisciplinas.Buscar(nome, true);
                //                ListaDisciplinas.ItemsSource = dbDisciplinas.ListarDisciplinas();

            }
            else
            { // todas as disciplinas
                ListaDisciplinas.ItemsSource = dbDisciplinas.Buscar(nome);
                //                ListaDisciplinas.ItemsSource = dbDisciplinas.ListarDisciplinas();

            }
        }


        private void ListaDisciplinas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelDisciplinas disciplina = (ModelDisciplinas)ListaDisciplinas.SelectedItem;

            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar(disciplina));
        }

        private void SwAndamentoDisciplina_Toggled(object sender, ToggledEventArgs e)
        {
            AtualizaLista();
        }

        private void TxtDisciplina_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizaLista();
            /*ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);
            ListaDisciplinas.ItemsSource = dbDisciplinas.Buscar(txtDisciplina.Text);*/
        }
    }
}