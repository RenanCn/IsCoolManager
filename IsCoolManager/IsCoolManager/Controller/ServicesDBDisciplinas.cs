using IsCoolManager.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsCoolManager.Controller
{
    public class ServicesDBDisciplinas
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServicesDBDisciplinas(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath); //define o bd
            conn.CreateTable<ModelDisciplinas>(); // cria tabela disciplinas
        }

        public void InserirDisciplinas(ModelDisciplinas disciplina)
        {
            try
            {
                if (string.IsNullOrEmpty(disciplina.Nome))
                    throw new Exception("Título da disciplina não informado.");

                int result = conn.Insert(disciplina);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("{0} registro(s) adicionados:\n[Disciplina: {1}]", result, disciplina.Nome);
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
        // ^ok
        public List<ModelDisciplinas> ListarDisciplinas()
        {
            List<ModelDisciplinas> lista = new List<ModelDisciplinas>();

            try
            {
                lista = conn.Table<ModelDisciplinas>().ToList();
                this.StatusMessage = "Listagem das Disciplinas";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }

        public void AlterarDisciplinas(ModelDisciplinas disciplina)
        {
            try
            {
                if (string.IsNullOrEmpty(disciplina.Nome))
                    throw new Exception("Título da disciplina não informado.");

                if (disciplina.Id <= 0)
                    throw new Exception("ID da disciplina não informado.");
                conn.Update(disciplina);

                StatusMessage = "Atualizado.";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
                //StatusMessage = string.Format("Erro: {0}", ex.Message);
            }
        }

        public void ExcluirDisciplinas(int id)
        {
            try
            {
                int result = conn.Table<ModelDisciplinas>().Delete(r => r.Id == id);
                StatusMessage = "Excluido.";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
                //StatusMessage = string.Format("Erro: {0}", ex.Message);
            }
        }

        public List<ModelDisciplinas> Buscar(string nome)
        {
            List<ModelDisciplinas> lista = new List<ModelDisciplinas>();

            try
            {
                var resp = from p in conn.Table<ModelDisciplinas>()
                           where p.Nome.ToLower().Contains(nome.ToLower())
                           select p;

                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

            return lista;
        }

        public List<ModelDisciplinas> Buscar(string nome, bool emAndamento)
        {
            List<ModelDisciplinas> lista = new List<ModelDisciplinas>();

            try
            {
                string _emAndamento = emAndamento == true ? "Em andamento" : "Encerrada";


                var resp = from p in conn.Table<ModelDisciplinas>()
                           where p.Nome.ToLower().Contains(nome.ToLower()) &&
                           p.Andamento == _emAndamento
                           select p;

                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

            return lista;
        }

        public List<ModelDisciplinas> ListarDisciplinasEmAndamento()
        { // buscar/exibir apenas disciplinas em andamento
            List<ModelDisciplinas> lista = new List<ModelDisciplinas>();

            try
            {
                var resp = from p in conn.Table<ModelDisciplinas>()
                           where p.Andamento == "Em andamento"
                           select p;

                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

            return lista;
        }

        public ModelDisciplinas GetDisciplinas(int id) // rec dsc / rtn = f
        {
            ModelDisciplinas m = new ModelDisciplinas();

            try
            {
                m = conn.Table<ModelDisciplinas>().First(d => d.Id == id);
                StatusMessage = "Encontrou a nota";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }

            return m;
        }

    }
}
