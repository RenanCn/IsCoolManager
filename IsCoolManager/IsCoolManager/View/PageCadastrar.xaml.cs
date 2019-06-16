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
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        public PageCadastrar(ModelDisciplinas disciplina)
        {
            InitializeComponent();
            btCadastrar.Text = "Alterar";

            txtId.IsVisible = true;
            btExcluir.IsVisible = true;

            txtId.Text = disciplina.Id.ToString();
            txtNome.Text = disciplina.Nome;
            txtSemestre.Text = disciplina.Semestre.ToString();
            txtFaltas.Text = disciplina.Faltas.ToString();
            txtLimiteFaltas.Text = disciplina.LimiteFaltas.ToString();
            txtNotaMeta.Text = disciplina.NotaMeta.ToString();
            swAndamento.IsToggled = disciplina.Andamento == "Em andamento" ? true : false;
        }

        /*public void InserirItens()
        {
            ModelDisciplinas disciplina = new ModelDisciplinas();

            disciplina.Nome = txtNome.Text;
            disciplina.Semestre = Convert.ToInt32(txtSemestre.Text);
            disciplina.Faltas = Convert.ToInt32(txtFaltas.Text);
            disciplina.LimiteFaltas = Convert.ToInt32(txtLimiteFaltas.Text);
            disciplina.NotaMeta = Convert.ToInt32(txtNotaMeta.Text);
            disciplina.Andamento = swAndamento.IsToggled == true ? "Em andamento" : "Encerrada";

            ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);
            dbDisciplinas.Inserir(disciplina);
            DisplayAlert("Resultado da operação: ", dbDisciplinas.StatusMessage, "OK");
        }*/


        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            // InserirItens();
            try
            {
                ModelDisciplinas disciplina = new ModelDisciplinas();

                disciplina.Nome = txtNome.Text;
                disciplina.Semestre = Convert.ToInt32(txtSemestre.Text);
                disciplina.Faltas = Convert.ToInt32(txtFaltas.Text);
                disciplina.LimiteFaltas = Convert.ToInt32(txtLimiteFaltas.Text);
                disciplina.NotaMeta = Convert.ToInt32(txtNotaMeta.Text);
                disciplina.Andamento = swAndamento.IsToggled == true ? "Em andamento" : "Encerrada";

                ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);

                if (btCadastrar.Text == "Cadastrar")
                {
                    dbDisciplinas.InserirDisciplinas(disciplina);
                    DisplayAlert("Resultado da operação: ", dbDisciplinas.StatusMessage, "OK");
                }
                else // alterar
                {
                    disciplina.Id = Convert.ToInt32(txtId.Text);
                    dbDisciplinas.AlterarDisciplinas(disciplina);
                    DisplayAlert("Resultado da operação: ", dbDisciplinas.StatusMessage, "OK");
                }

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageListar());

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "OK");
            }
     
        }

        private void BtCancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new PagePrincipal();
        }

        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir", "Deseja excluir esta disciplina?", "Sim", "Não");

            if (resp == true)
            {
                ServicesDBDisciplinas dbDisciplinas = new ServicesDBDisciplinas(App.DbPath);
                int id = Convert.ToInt32(txtId.Text);
                dbDisciplinas.ExcluirDisciplinas(id);
                DisplayAlert("Resultado da operação: ", dbDisciplinas.StatusMessage, "OK");

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new PageListar();
            }
        }
    }
}