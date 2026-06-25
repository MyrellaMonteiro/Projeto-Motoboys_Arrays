using System;

namespace ProjetoMotoboys_Myrella
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = -1;
            double[] faturamentoMotoboy = new double[10];
            try
            {
                while (opcao != 0)
                {
                    Console.WriteLine("\n=== MENU ===");
                    Console.WriteLine("1 - Informar entrega");
                    Console.WriteLine("2 - Listar faturamentos");
                    Console.WriteLine("3 - Listar comissões");
                    Console.WriteLine("4 - Motoboy destaque");
                    Console.WriteLine("0 - Finalizar");

                    Console.Write("\nOpção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 0:
                            Console.WriteLine("Finalizando o dia...");
                            break;
                        case 1:
                            Console.WriteLine("Digite o numero do moteboy (1-10): ");
                            int MotoboyID = int.Parse(Console.ReadLine());

                            if (MotoboyID < 1 || MotoboyID > 10)
                            {
                                Console.WriteLine("Número do motoboy inválido.");
                                break;
                            }
                            Console.WriteLine("Digite o valor da entrega: ");
                            double valorEntrega = double.Parse(Console.ReadLine());
                            if(valorEntrega < 0)
                            {
                                Console.WriteLine("Valor da entrega inválido. Digite um valor positivo.");
                                break;
                            }

                            faturamentoMotoboy[MotoboyID - 1] += valorEntrega;
                            break;
                        case 2:
                            double total = 0;
                            for (int i = 0; i < faturamentoMotoboy.Length; i++)
                            {
                                Console.WriteLine($"Motoboy: {i + 1} - R$ {faturamentoMotoboy[i]:F2}");
                                total += faturamentoMotoboy[i];
                            }
                            Console.WriteLine($"Total: R$ {total:F2}");
                            break;
                        case 3:
                            double totalComissao = 0;

                            for (int i = 0; i < faturamentoMotoboy.Length; i++)
                            {
                                double comissao = faturamentoMotoboy[i] * 0.10;
                                totalComissao += comissao;
                                Console.WriteLine($"Moto: {i + 1} - Comissão: R$ {comissao:F2}");
                            }
                                    Console.WriteLine($"Total de comissões: R$ {totalComissao:F2}");
                            break;
                        case 4:
                            int idDestaque = 1;
                            double maiorFaturamento = faturamentoMotoboy[0];
                            for (int i = 1; i < faturamentoMotoboy.Length; i++)
                            {  
                                if (faturamentoMotoboy[i] > maiorFaturamento)
                                {
                                    maiorFaturamento = faturamentoMotoboy[i];
                                    idDestaque = i + 1;
                                }
                            }

                            Console.WriteLine($"Motoboy {idDestaque} foi o de maior destaque!" +
                                                $"\nFaturamento Total: {maiorFaturamento:F2}");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}