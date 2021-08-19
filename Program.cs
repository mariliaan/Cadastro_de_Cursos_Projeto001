using MADN.Cursos.Classes;
using MADN.Cursos.Enum;
using System;

namespace MADN.Cursos
{
    class Program
    {
        static CursoRepositorio repositorio = new CursoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarCursos();
                        break;
                    case "2":
                        InserirCurso();
                        break;
                    case "3":
                        AtualizarCurso();
                        break;
                    case "4":
                        ExcluirCurso();
                        break;
                    case "5":
                        VisualizarCurso();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Opção inválida");

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine();
            Console.WriteLine("Até mais...");
            Console.ReadLine();
        }

        private static void ExcluirCurso()
        {
            Console.Write("Digite o id do curso: ");
            int indiceCurso = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceCurso);
        }

        private static void VisualizarCurso()
        {
            Console.Write("Digite o id do curso: ");
            int indiceCurso = int.Parse(Console.ReadLine());

            var curso = repositorio.RetornaPorId(indiceCurso);

            Console.WriteLine(curso);
        }

        private static void AtualizarCurso()
        {
            Console.Write("Digite o id do curso: ");
            int indiceCurso = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in System.Enum.GetValues(typeof(Area)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Area), i));
            }
            Console.Write("Digite a area entre as opções acima: ");
            int entradaArea = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Curso: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Professor: ");
            string entradaProfessor = Console.ReadLine();

            Console.Write("Digite a carga horária: ");
            int entradaCargaHoraria = int.Parse(Console.ReadLine());

            Curso atualizaCurso = new Curso(id: indiceCurso,
                                        area: (Area)entradaArea,
                                        curso: entradaNome,
                                        professor: entradaProfessor,
                                        carga_horaria: entradaCargaHoraria);

            repositorio.Atualiza(indiceCurso, atualizaCurso);
        }
        private static void ListarCursos()
        {
            Console.WriteLine("Listar Cursos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum curso cadastrado.");
                return;
            }

            foreach (var curso in lista)
            {
                var excluido = curso.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", curso.retornaId(), curso.retornaCurso(), excluido ? "*Excluído*" : "");
            }
        }

        private static void InserirCurso()
        {
            Console.WriteLine("Inserir novo curso");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in System.Enum.GetValues(typeof(Area)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Area), i));
            }
            Console.Write("Digite a Area entre as opções acima: ");
            int entradaArea = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Curso: ");
            string entradaCurso = Console.ReadLine();

            Console.Write("Digite o Professor:");
            string entradaProfessor = Console.ReadLine();

            Console.Write("Digite a carga horária: ");
            int entradaCargaHoraria = int.Parse(Console.ReadLine());


            Curso novoCurso = new Curso(id: repositorio.ProximoId(),
                                        area: (Area)entradaArea,
                                        curso: entradaCurso,
                                        professor: entradaProfessor,
                                        carga_horaria: entradaCargaHoraria);

            repositorio.Insere(novoCurso);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(">> MADN - Cursos de Tecnologia da Informação <<");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar Cursos");
            Console.WriteLine("2- Inserir novo curso");
            Console.WriteLine("3- Atualizar curso");
            Console.WriteLine("4- Excluir curso");
            Console.WriteLine("5- Visualizar curso");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
