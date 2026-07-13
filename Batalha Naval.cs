using System;

public class Game
{
    public static void Main()
    {
        bool Truelevel = false;
        int size = 0;
        int ship = 0;

        while (!Truelevel)
        {
            System.Console.Clear();

            System.Console.WriteLine(new string('-', 45));
            System.Console.WriteLine(new string(' ', 14) + "SELECIONE O NIVEL");
            System.Console.WriteLine(new string('-', 45));
            System.Console.WriteLine("\n\n\t1. Facil   (Grade 5x5 - 3 Navios Ocultos)");
            System.Console.WriteLine("\n\t2. Medio   (Grade 6x6 - 5 Navios Ocultos)");
            System.Console.WriteLine("\n\t3. Dificil (Grade 8x8 - 8 Navios Ocultos)\n");

            Console.Write("");
            string number = Console.ReadLine();
            int level;

            if (int.TryParse(number, out level))
            {
                System.Console.Clear();

                if (level == 1)
                {
                    size = 5;
                    ship = 3;
                    Truelevel = true;
                    System.Console.WriteLine("\nNivel Selecionado:" + level);
                    System.Threading.Thread.Sleep(2000);
                }
                else if (level == 2)
                {
                    size = 6;
                    ship = 5;
                    Truelevel = true;
                    System.Console.WriteLine("\nNivel Selecionado:" + level);
                    System.Threading.Thread.Sleep(2000);
                }
                else if (level == 3)
                {
                    size = 8;
                    ship = 8;
                    Truelevel = true;
                    System.Console.WriteLine("\nNivel Selecionado:" + level);
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    System.Console.WriteLine("\nO nivel " + level + " ainda nao existe, tente novamente");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            else
            {
                System.Console.WriteLine("\nTexto invalido");
                System.Threading.Thread.Sleep(2000);
            }
        }

        char[,] mesh = new char[size, size];
        bool[,] ships = new bool[size, size];

        for (int line = 0; line < size; line++)
        {
            for (int column = 0; column < size; column++)
            {
                mesh[line, column] = '~';
                ships[line, column] = false;
            }
        }

        Random random = new Random();
        int shippos = 0;

        while (shippos < ship)
        {
            int sline = random.Next(0, size);
            int scolumn = random.Next(0, size);

            if (!ships[sline, scolumn])
            {
                ships[sline, scolumn] = true;
                shippos++;
            }
        }

        int attempts = 0;
        int hits = 0;
        bool play = true;
        string mensage = "Comandante!, informe as coordenadas do ataque";

        while (play)
        {
            System.Console.Clear();
            System.Console.WriteLine("\n" + new string('=', 45));
            System.Console.WriteLine("\n\t\t\tBatalha Naval");
            System.Console.WriteLine("\n" + new string('=', 45));
            System.Console.WriteLine("Tentativas:" + attempts + "|acertos:" + hits);
            System.Console.WriteLine(new string('-', 45));
            System.Console.WriteLine("\n" + mensage + "\n");
            
            System.Console.Write("    ");
            for (int col = 0; col < size; col++)
            {
                System.Console.Write(col + " ");
            }
            System.Console.WriteLine("\n");

            for (int line = 0; line < size; line++)
            {
                System.Console.Write(line + " | ");
                for (int col = 0; col < size; col++)
                {
                    System.Console.Write(mesh[line, col] + " ");
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine(new string('-', 45));
            System.Console.Write("Digite a posicao (LINHA COLUNA): ");
            string rawInput = System.Console.ReadLine();

            if (rawInput.Trim().ToLower() == "pular")
            {
                hits = ship;
            }
            else
            {
                string[] input = rawInput.Split(' ');

                if (input.Length == 2 && int.TryParse(input[0], out int playerLine) && int.TryParse(input[1], out int playerColumn))
                {
                    if (playerLine >= 0 && playerLine < size && playerColumn >= 0 && playerColumn < size)
                    {
                        attempts++;

                        if (ships[playerLine, playerColumn] == true)
                        {
                            hits++;
                            mesh[playerLine, playerColumn] = 'X';
                            ships[playerLine, playerColumn] = false;
                            mensage = "Fogo certeiro! Um navio inimigo foi atingido.";
                        }
                        else
                        {
                            if (mesh[playerLine, playerColumn] != 'X' && mesh[playerLine, playerColumn] != 'O')
                            {
                                mesh[playerLine, playerColumn] = 'O';
                            }
                            mensage = "Agua! Nenhum alvo encontrado nessas coordenadas.";
                        }
                    }
                    else
                    {
                        mensage = "Coordenadas fora do tabuleiro! Escolha numeros entre 0 e " + (size - 1) + ".";
                    }
                }
                else
                {
                    mensage = "Formato invalido! Digite a LINHA e a COLUNA separadas por um espaco (Ex: 0 1).";
                }
            }

            if (hits == ship)
            {
                System.Console.Clear();
                System.Console.WriteLine("=============================================");
                System.Console.WriteLine("    PARABENS, COMANDANTE! VITORIA TOTAL!     ");
                System.Console.WriteLine("=============================================");
                System.Console.WriteLine("Voce destruiu todos os " + ship + " navios em " + attempts + " tentativas.");
                
                System.Console.WriteLine("\n" + new string('-', 45));
                System.Console.WriteLine(new string(' ', 18) + "CREDITOS");
                System.Console.WriteLine(new string('-', 45));
                System.Console.WriteLine("Autor: DAVIDVS");
                System.Console.WriteLine("Colaboracao: Gemini (3.5 Flash-Estendido)");
                System.Console.WriteLine(new string('-', 45));
                
                play = false;
            }
        }
    }
}
