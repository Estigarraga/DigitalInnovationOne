
using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[10];
            int indiceAluno = 0;
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {

                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                             aluno.Nota = nota;
                             aluno.id = indiceAluno;
                             alunos[indiceAluno] = aluno;

                             indiceAluno++;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal.");
                        }

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        
                        

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.e;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.d;
                        }
                         else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.c;
                        }
                         else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.b;
                        }
                         else
                        {
                            conceitoGeral = Conceito.a;
                        }

                        
                        Console.WriteLine($"Média Geral: {mediaGeral} - CONCEITO: {conceitoGeral}");


                        break;
                    default:
                        throw new ArgumentOutOfRangeException();


                }
            
            OpcaoUsuario = ObterOpcaoUsuario();

            }



        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}