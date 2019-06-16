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
    public partial class PageListarTarefa : ContentPage
    {
        public PageListarTarefa()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {

            string nome = "";

            if (txtTarefa.Text != null)
            {
                nome = txtTarefa.Text;
            }

            ServicesDBTarefas dBTarefas = new ServicesDBTarefas(App.DbPath);

            ListaTarefas.ItemsSource = dBTarefas.BuscarTarefas(nome);

            Console.WriteLine(" txtTAREFA >>>>>> " + txtTarefa.Text);
        }

        private void TxtTarefa_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizaLista();
        }

        private void ListaTarefas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelTarefas tarefa = (ModelTarefas)ListaTarefas.SelectedItem;

            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrarTarefa(tarefa));
        }

        /* public void AtualizaLista()
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
             ListaDisciplinas.ItemsSource = dbDisciplinas.Buscar(txtDisciplina.Text);
         }
         
        }*/
    }
}