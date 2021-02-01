using System;

namespace Folha_de_pagamento
{
   
    class Program
       
    {
        public struct dados
        {
            public string nome,cargo,telefone ;
            public int situacao,registro;
            public double salario;

        }
        static void Main(string[] args)
        {
            int op;
            dados[] funcionarios = new dados[50];
            int num_funcionarios = 0;
           
           

            do
            {
                //inicio do programa, tela inicial com opções.
                Console.Clear();
                Console.WriteLine(  "\t\t\t ============PROGRAMA===========\n"
                                  + "\t\t\t |  1-CADASTRAR FUNCIONARIO       |   \n"
                                  + "\t\t\t |  2-EXCLUIR FUNCIONÁRIO         |   \n"
                                  + "\t\t\t |  3-LISTAR FUNCIONÁRIO          |   \n"
                                  + "\t\t\t |  4-ALTERAR DADOS               |   \n"
                                  + "\t\t\t |  5-TOTAL DA FOLHA DE PAGAMENTO |   \n"
                                  + "\t\t\t |  6-SAIR                        |   \n"
                                  + "\t\t\t ============ PROGRAMA ==========="
                                  + "                                           ");
                Console.Write("\t\t\t DIGITE SUA OPÇÃO:");
                op = int.Parse(Console.ReadLine());                
                switch (op) 
                {
                    case 1:
                        Console.WriteLine("               "
                                        + "\t\t\t CADASTRO DE FUNCIONARIO         " );
                        if (num_funcionarios > 50)
                        {
                            Console.WriteLine("\t\t\tVAGAS LIMITE ATINGIDA!");
                        }else
                        {
                            Cadastrar(ref num_funcionarios, funcionarios);
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        excluir(num_funcionarios, funcionarios);
                        Console.ReadKey();
                        break;
                    case 3:                       
                        Listar(num_funcionarios, funcionarios);
                        Console.ReadKey();

                        break;
                    case 4:
                        alterar(num_funcionarios, funcionarios);
                        Console.ReadKey();
                        break;
                    case 5:
                        pagamento(num_funcionarios, funcionarios);
                        break;
                    case 6:

                        break;

                }

            } while (op != 6);
            Console.WriteLine("                                       ");
            Console.WriteLine("\t\t\t  ===ENTER PARA SAIR!===");
            Console.ReadKey();
        }



        static void Cadastrar(ref int i, dados[] P) 
        {
            Console.Write("\t\t\t Digite o nome do funcionario: ");
            P[i].nome = Console.ReadLine();
            P[i].situacao = 1;
            Console.Write("\t\t\t Digite o registro do funcionario: ");
            P[i].registro = int.Parse(Console.ReadLine());

            Console.Write("\t\t\t Digite o telefone do funcionario: ");
            P[i].telefone = Console.ReadLine();

            Console.Write("\t\t\t Digite o cargo do funcionario: ");
            P[i].cargo = Console.ReadLine();           

            Console.Write("\t\t\t Digite o salario do funcionario: ");
            P[i].salario = double.Parse(Console.ReadLine());
            i++;
            
            Console.Write("\t\t\t *** ENTER PARA VOLTAR ***  ");
        }




       static void Listar(int x,dados[] P)  
       {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("       \t\t\t================LISTAS==================\n"
                                       + "\t\t\t|           A - CARGO                   |\n"
                                       + "\t\t\t|           B - SALÁRIO                 |\n"
                                       + "\t\t\t|           C - TODOS                   |\n"
                                       + "\t\t\t|           D - VOLTAR                  |\n"
                                       + "\t\t\t================LISTAS==================\n"
                                       + "                                       ");
                Console.Write("\t\t\t Digite sua opção:");
                op = Console.ReadLine().ToUpper();
                                
                switch(op)
                {
                    case "A":
                        ListaCargo(x , P);
                        break;

                    case "B":
                        ListarSalario(x, P);
                        break;

                    case "C":
                        ListarTodos(x, P);
                        break;
                }

               
            } while (op != "D");
            Console.WriteLine("                                       ");
            Console.WriteLine("\t\t\t  ===ENTER PARA SAIR!===");
            Console.ReadKey();
       } 

        static void ListaCargo (int x, dados[] P)
        {
            Console.Clear();
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("\t\t\t Digite o cargo desejado: ");
            pesquisa = Console.ReadLine();
            for (int i = 0; i < x; i++)
            {   
                if (pesquisa == P[i].cargo && P[i].situacao == 1)
                {                                
                        Console.WriteLine("{0}º Nome: {1} | Registro {2} | Salario: {3} | Cargo:{4}", i + 1, P[i].nome, P[i].registro, P[i].salario, P[i].cargo);     
                    
                        achou = 'S';                    
                }

            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t        *** CLIENTE NÃO CADASTRADO!***\n");
                Console.WriteLine("\t\t\t           *** ENTER PARA VOLTAR ***");
                Console.ReadKey();
        }




        static void ListarSalario(int x, dados[] P) //fazer listagem por salario, nescessario conversão...
        {
            Console.Clear();
            double pesquisa;
            char achou;
            achou = 'N';
            Console.Write("\t\t\t Digite o salario desejado: ");
            pesquisa = double.Parse(Console.ReadLine());
           
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].salario && P[i].situacao == 1)
                {
                    Console.WriteLine("{0}º Nome: {1} | Registro {2} | Salario: {3} | Cargo:{4}", i + 1, P[i].nome, P[i].registro, P[i].salario, P[i].cargo);
                    
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t        *** CLIENTE NÃO CADASTRADO!***\n");
                Console.WriteLine("\t\t\t          *** ENTER PARA VOLTAR ***");
                Console.ReadKey();
        }



        static void ListarTodos(int x, dados[] P)
        {
        Console.Clear();
        if (x == 0)
        {
            Console.WriteLine("\t\t\t *** NEM UM FUNCIONARIO ENCONTRADO ***  ");                
        }
        else
        {
            for (int i = 0; i < x; i++)
            {                    
                if (P[i].situacao == 1)
                    Console.WriteLine("{0}º Nome: {1} | Registro {2} | Salario: {3} | Cargo:{4}", i + 1, P[i].nome, P[i].registro, P[i].salario, P[i].cargo);                        
            }
        }
        Console.WriteLine("\t\t\t*** ENTER PARA VOLTAR ***");
        Console.ReadKey();
        }   



        static void alterar(int x, dados[] P)
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("       \t\t\t================ALTERAR==================\n"
                                       + "\t\t\t|           A - POR NOME                |\n"
                                       + "\t\t\t|           B - POR REGISTRO            |\n"
                                       + "\t\t\t|           C - VOLTAR                  |\n"                                     
                                       + "\t\t\t================ALTERAR==================\n"
                                       + "                                       ");
                Console.Write("\t\t\t Digite sua opção:");
                op = Console.ReadLine().ToUpper();



                switch (op)
                {
                    case "A":
                       alterarnome(x, P);
                        break;

                    case "B":
                        alterarregistro(x, P);
                        break;
                }


            } while (op != "C");
            Console.WriteLine("                                       ");
            Console.WriteLine("\t\t\t  ===ENTER PARA VOLTAR!===");
            Console.ReadKey();
        }

        static void alterarnome(int x, dados[] P)
        {
            Console.Clear();
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("\t\t\t Digite o nome a ser alterado: ");
            pesquisa = Console.ReadLine();
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].nome && P[i].situacao == 1)
                {
                    Console.Clear();
                    Console.Write("\t\t\t Digite o novo nome: ");
                    P[i].nome = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo registro: ");
                    P[i].registro = int.Parse(Console.ReadLine());
                    Console.Write("\t\t\t Digite Telefone: ");
                    P[i].telefone = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo cargo: ");
                    P[i].cargo = Console.ReadLine();
                    Console.WriteLine("\t\t\t ALTERADO COM SUCESSO!"); Console.Beep(); Console.Beep(); Console.Beep();
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t        *** FUNCIONARIO NÃO CADASTRADO!***");
        }


        static void alterarregistro(int x, dados[] P)
        {
            Console.Clear();
            int pesquisa;
            char achou;
            achou = 'N';
            Console.Write("\t\t\t Digite o registro a ser alterado: ");
            pesquisa = int.Parse(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].registro && P[i].situacao == 1)
                {
                    Console.Clear();
                    Console.Write("\t\t\t Digite o novo nome: ");
                    P[i].nome = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo registro: ");
                    P[i].registro = int.Parse(Console.ReadLine());
                    Console.Write("\t\t\t Digite Telefone: ");
                    P[i].telefone = Console.ReadLine();
                    Console.Write("\t\t\t Digite o novo cargo: ");
                    P[i].cargo = Console.ReadLine();
                    Console.WriteLine("\t\t\t ALTERADO COM SUCESSO!"); Console.Beep(); Console.Beep(); Console.Beep();
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t        *** FUNCIONARIO NÃO CADASTRADO!***");
        }


        static void excluir(int x,dados[] P) //Meu levara para até as funções de exclusão
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("       \t\t\t================EXCLUIR==================\n"
                                       + "\t\t\t|           A - NOME                    |\n"
                                       + "\t\t\t|           B - REGISTRO                |\n"                                   
                                       + "\t\t\t|           C - VOLTAR                  |\n"
                                       + "\t\t\t================EXCLUIR==================\n"
                                       + "                                       ");
                Console.Write("\t\t\t Digite sua opção:");
                op = Console.ReadLine().ToUpper();



                switch (op)
                {
                    case "A":
                        excluirNome(x, P);
                        break;

                    case "B":
                        excluirRegistro(x, P);
                        break;
                    
                }


            } while (op != "C");
            Console.WriteLine("                                       ");
            Console.WriteLine("\t\t\t  ===ENTER PARA SAIR!===");
            Console.ReadKey();

        } 

        static void excluirNome(int x, dados[] P)
        {
            Console.Clear();
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Clear();
            Console.Write("Digite o nome a ser excluido: ");
            pesquisa = Console.ReadLine();

            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].nome && P[i].situacao == 1)
                {
                    P[i].situacao = 0;
                    
                    Console.WriteLine("\t\t\t  ***FUNCIONARIO EXCLUIDO COM SUCESSO!***");Console.Beep(); Console.Beep(); Console.Beep();
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t         *** FUNCIONARIO NÃO CADASTRADO!***");
        }


        static void excluirRegistro(int x,dados[] P) 
        {
            Console.Clear();
            int pesquisa;
            char achou;
            achou = 'N';
            Console.Clear();
            Console.Write("Digite o registro a ser excluido: ");
            pesquisa = int.Parse(Console.ReadLine());

            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].registro && P[i].situacao == 1)
                {
                    P[i].situacao = 0;

                    Console.WriteLine("\t\t\t  ***FUNCIONARIO EXCLUIDO COM SUCESSO!***"); Console.Beep(); Console.Beep(); Console.Beep();
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("\t\t\t         *** FUNCIONARIO NÃO CADASTRADO!***");
        }


        static void pagamento (int x, dados[] P)// guardar a soma dos salarios, mostrando no final 
        {
            Console.Clear();
            double salarioTotal = 0;
            for (int i = 0; i < x; i++)
            {
                if (P[i].situacao == 1)
                {
                    salarioTotal += P[i].salario;
                }
            }

            Console.WriteLine("\t\t\t Sua folha de pagamento atual é de {0}", salarioTotal);
            
            Console.ReadKey();
        }
    }
}

