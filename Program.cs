using System;

internal class Program
{
    private char[,] tabuleiro;
    private Program()
    {
        tabuleiro = new char[10, 10];
        IniciarTabuleiro(tabuleiro);
        int tentativas = 15;

        PosicionarNavios(tabuleiro, 'P', 10);
        PosicionarNavios(tabuleiro, 'C', 1);
        PosicionarNavios(tabuleiro, 'R', 2);
        MostrarMapa(tabuleiro);

        while(tentativas > 0)
        {
            MostrarMapa(tabuleiro);
            Console.WriteLine($"Tentativas restantes: {tentativas}");
            FazerTiro();
            tentativas--;
        }

    }

    private void FazerTiro()
    {
        Console.Write("Informe a linha do tiro: ");
        int linha = int.Parse(Console.ReadLine());

        Console.Write("Informe a coluna do tiro: ");
        int coluna = int.Parse(Console.ReadLine());

        if (tabuleiro[linha, coluna] != ' ')
        {
            Console.WriteLine("Você atingiu um navio!");
            tabuleiro[linha, coluna] = 'X'; // Marque o tiro como acerto no tabuleiro
        }
        else
        {
            Console.WriteLine("Você errou o tiro!");
            tabuleiro[linha, coluna] = 'O'; // Marque o tiro como erro no tabuleiro
        }
        
      
        
    }

    private static void IniciarTabuleiro(char[,] tabuleiro)
    {
        for (int l = 0; l < 10; l++)
        {
            for (int c = 0; c < 10; c++)
            {
                tabuleiro[l, c] = ' ';
            }
        }
    }

    private static void PosicionarNavios(char[,] tabuleiro, char nomeNavio, int quantidadeNavio)
    {
        Random rnd = new Random();

        for (int i = 0; i < quantidadeNavio; i++)
        {
            int linha, coluna;
            do
            {
                linha = rnd.Next(0, 10);
                coluna = rnd.Next(0, 10);
            } while (tabuleiro[linha, coluna] != ' ');

            tabuleiro[linha, coluna] = nomeNavio;
        }
    }

    private static void MostrarMapa(char[,] tabuleiro)
    {
        Console.WriteLine("\t0\t1\t2\t3\t4\t5\t6\t7\t8\t9");
        Console.WriteLine("    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

        for (int x = 0; x < 10; x++)
        {
            Console.Write($"  {x} |");
            for (int c = 0; c < 10; c++)
            {
                if(tabuleiro[x, c]!= ' ')
                {
                    Console.Write("       |");
                }
                else{
                    Console.Write($"   {tabuleiro[x, c]}   |");
                }
            }
            Console.WriteLine();
        Console.WriteLine("    - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        }
    }

    private static void Main(string[] args)
    {
        new Program();
    }
}
 