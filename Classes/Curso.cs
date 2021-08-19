using MADN.Cursos.Enum;
using System;

namespace MADN.Cursos.Classes
{
    public class Curso : EntidadeBase
    {
        // Atributos
        private Area Area { get; set; }
        private string Nome_Curso { get; set; }
        private string Professor { get; set; }
        private int Carga_Horaria { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Curso(int id, Area area, string curso, string professor, int carga_horaria)
        {
            Id = id;
            Area = area;
            Nome_Curso = curso;
            Professor = professor;
            Carga_Horaria = carga_horaria;
            Excluido = false;
        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Area: " + Area + Environment.NewLine;
            retorno += "Curso: " + Nome_Curso + Environment.NewLine;
            retorno += "Professor: " + Professor + Environment.NewLine;
            retorno += "Carga Horária: " + Carga_Horaria + Environment.NewLine;
            retorno += "Excluido: " + Excluido;
            return retorno;
        }

        public string retornaCurso()
        {
            return Nome_Curso;
        }

        public int retornaId()
        {
            return Id;
        }
        public bool retornaExcluido()
        {
            return Excluido;
        }
        public void Excluir()
        {
            Excluido = true;
        }
    }
}