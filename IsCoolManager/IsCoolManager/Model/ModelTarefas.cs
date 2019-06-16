using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsCoolManager.Model
{
    [Table("Tarefas")]
    public class ModelTarefas
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string Disciplina { get; set; }
        [PrimaryKey,NotNull]
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Nota { get; set; }
        public string Data { get; set; }
        public string Tipo { get; set; }
        public double Prioridade { get; set; }

        public ModelTarefas()
        {
            this.Id = 0;
            this.Disciplina = "";
            this.Descricao = "";
            this.Valor = 0;
            this.Nota = 0;
            this.Data = "";
            this.Tipo = "";
            this.Prioridade = 0;
        }

    }

}

/*
- Disciplina Disciplina `a qual a tarefa pertence (ex.: CSI401);
- Descrição Breve descri¸c˜ao da tarefa (ex.: Prova 1);
- Valor N´umero de pontos que a atividade vale (ex.: 30 pontos);
- Nota Nota obtida na atividade (ex.: 25 pontos);
- Data de entrega Data na qual a atividade dever´a ser entregue/realizada (ex.: 26/jun/19);
- Tipo Caracterizador do tipo de atividade com, ao menos, as seguintes opções de tipo:
prova, trabalho, seminário, outro;
- Prioridade Objetivo de nota a ser alcan¸cado (ex.: 80 pontos); 
*/
