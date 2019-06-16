using IsCoolManager.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsCoolManager.Controller
{
    public class ServicesDBTarefas
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServicesDBTarefas(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath); //define o bd
            conn.CreateTable<ModelTarefas>(); // cria tabela tarefas
        }

        public void InserirTarefas(ModelTarefas tarefa)
        {
            try
            {
                if (tarefa.Id <= 0)
                    throw new Exception("Id da tarefa não informado.");

                if (string.IsNullOrEmpty(tarefa.Disciplina))
                    throw new Exception("Disciplina da tarefa não informado.");

                int result = conn.Insert(tarefa);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("{0} registro(s) adicionados:\n[Tarefas: {1}]", result, tarefa.Disciplina);
                }
                else
                {
                    this.StatusMessage = string.Format("0 registro(s) adicionados.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
            //

            public void AlterarTarefas(ModelTarefas tarefa)
            {
                try
                {
                    if (string.IsNullOrEmpty(tarefa.Disciplina))
                        throw new Exception("Título da disciplina não informado.");

                    if (tarefa.Id <= 0)
                        throw new Exception("ID da tarefa não informado.");
                    conn.Update(tarefa);

                    StatusMessage = "Atualizado.";
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro: {0}", ex.Message));
                    //StatusMessage = string.Format("Erro: {0}", ex.Message);
                }
            }

            public void ExcluirTarefas(string desc)
            {
                try
                {
                    int result = conn.Table<ModelTarefas>().Delete(r => r.Descricao == desc);
                    StatusMessage = "Excluido.";
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro: {0}", ex.Message));
                    //StatusMessage = string.Format("Erro: {0}", ex.Message);
                }
            }

            public List<ModelTarefas> BuscarTarefas(string desc)
            {
                List<ModelTarefas> lista = new List<ModelTarefas>();

                try
                {
                var resp = from p in conn.Table<ModelTarefas>()
                           where p.Descricao.ToLower().Contains(desc.ToLower())
                           select p;

                lista = resp.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Erro: {0}", ex.Message));
                }

                return lista;
            }

        
    }
}
