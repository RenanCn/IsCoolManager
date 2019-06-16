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
    public partial class PageCadastrarTarefa : ContentPage
    {
        public PageCadastrarTarefa()
        {
            InitializeComponent();

            ServicesDBDisciplinas disciplina = new ServicesDBDisciplinas(App.DbPath);

            foreach (var item in disciplina.ListarDisciplinas())
            {
                pckDisciplina.Items.Add(item.Nome);
            }

        }

        public PageCadastrarTarefa(ModelTarefas tarefa)
        {
            InitializeComponent();

            ServicesDBDisciplinas disciplina = new ServicesDBDisciplinas(App.DbPath);

            btCadastrarTarefa.Text = "Alterar";

            txtIdTarefa.IsVisible = true;
            btExcluirTarefa.IsVisible = true;

            txtIdTarefa.Text = tarefa.Id.ToString();
            foreach (var item in disciplina.ListarDisciplinas())
            {
                pckDisciplina.Items.Add(item.Nome);
            }
            pckDisciplina.SelectedItem = tarefa.Disciplina;
            txtDescricao.Text = tarefa.Descricao;
            txtValor.Text = tarefa.Valor.ToString();
            txtNota.Text = tarefa.Nota.ToString();
            dpData.Date = System.DateTime.Parse(tarefa.Data);
            pckTipo.SelectedItem = tarefa.Tipo;
            txtPrioridade.Text = tarefa.Prioridade.ToString();
        }

        private void BtCadastrarTarefa_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelTarefas tarefa = new ModelTarefas();
                tarefa.Id = Convert.ToInt32(txtIdTarefa.Text);
                tarefa.Disciplina = pckDisciplina.SelectedItem.ToString();
                tarefa.Descricao = txtDescricao.Text;
                tarefa.Valor = Convert.ToInt32(txtValor.Text);
                tarefa.Nota = Convert.ToInt32(txtNota.Text);
                tarefa.Data = dpData.Date.ToString();
                tarefa.Tipo = pckTipo.SelectedItem.ToString();
                tarefa.Prioridade = Convert.ToInt32(txtPrioridade.Text);

                ServicesDBTarefas dbTarefas = new ServicesDBTarefas(App.DbPath);

                if (btCadastrarTarefa.Text == "Cadastrar")
                {
                    dbTarefas.InserirTarefas(tarefa);
                    DisplayAlert("Resultado da operação: ", dbTarefas.StatusMessage, "OK");
                }
                else // alterar
                {
                    tarefa.Id = Convert.ToInt32(txtIdTarefa.Text);
                    dbTarefas.AlterarTarefas(tarefa);
                    DisplayAlert("Resultado da operação: ", dbTarefas.StatusMessage, "OK");
                }

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageListarTarefa());

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "OK");
            }
        }

        private void BtCancelarTarefa_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new PagePrincipal();
        }

        private async void BtExcluirTarefa_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir", "Deseja excluir esta disciplina?", "Sim", "Não");

            if (resp == true)
            {
                ServicesDBTarefas dbTarefas = new ServicesDBTarefas(App.DbPath);
                string desc = txtDescricao.Text;
                dbTarefas.ExcluirTarefas(txtDescricao.Text);
                DisplayAlert("Resultado da operação: ", dbTarefas.StatusMessage, "OK");

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new PageListarTarefa();
            }
        }

        private void PckDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicesDBDisciplinas disciplina = new ServicesDBDisciplinas(App.DbPath);

            foreach (var item in disciplina.ListarDisciplinas())
            {
                if (item.Nome == pckDisciplina.SelectedItem.ToString())
                {
                    txtIdTarefa.Text = item.Id.ToString();
                }

            }
        }
    }
}