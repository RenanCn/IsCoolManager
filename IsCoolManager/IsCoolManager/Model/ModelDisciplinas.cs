using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsCoolManager.Model
{
    [Table("Disciplinas")]
    public class ModelDisciplinas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull, Unique]
        public string Nome { get; set; }
        public int Semestre { get; set; }
        public int Faltas { get; set; }
        public int LimiteFaltas { get; set; }
        public double NotaMeta { get; set; }
        public string Andamento { get; set; }

        public ModelDisciplinas()
        {
            this.Id = 0;
            this.Nome = "";
            this.Semestre = 0;
            this.Faltas = 0;
            this.LimiteFaltas = 0;
            this.NotaMeta = 0f;
            this.Andamento = "Em andamento";
        }
    }
}


/*
- Nome Identificador da disciplina/ mat´eria (ex.: CSI401);
- Semestre Indicador do semestre em que o aluno est´a cursando a disciplina (ex.: 2o);
- Faltas N´umero de faltas que o aluno teve na disciplina;
- Limite de Faltas Limite de faltas que o aluno pode ter para n˜ao ser reprovado;
- Meta Objetivo de nota a ser alcan¸cado (ex.: 80 pontos);
- Andamento Indica se a disciplina est´a em andamento ou j´a foi encerrada;
 */
