using System.Drawing;

namespace Warship
{
    class Program
    {
        static void Main(string[] args)
        {

            // Definindo tamanho do tabuleiro
            const int boardSize = 10;
            int[,] board = new int[boardSize, boardSize]; //Gerando uma matriz quadrada
            int score = 0;

            // Colocando os navios
            PlaceShips(board);
            AlteraCorTextoConsole(ConsoleColor.Cyan);
            // Partida...
            bool gameOver = false;
            while (!gameOver)
            {
                try
                {

                    // Mostra e atualiza o tabuleiro
                    DisplayBoard(board);

                    // Pegando a resposta do usuário
                    Console.WriteLine("Dê um tiro! (EX:  A1):");
                    string input = Console.ReadLine().ToUpper();
                    int x = input[0] - 'A';
                    int y = int.Parse(input.Substring(1)) - 1;

                    // Dispara um tiro na coordenada informada
                    bool hit = FireShot(board, x, y);

                    // Verifica se o jogo acabou...
                    gameOver = IsGameOver(board);

                    // Mostra se o usuário acertou ou não 
                    if (hit)
                    {
                        /**
                         * Aumentar pontuação de acordo com o barco
                         **/

                        Console.WriteLine("Acertou miserávi!");
                    }
                    else
                    {
                        Console.WriteLine("Puts, ruim demais!");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Cordenada inválida");

                    /**
                     * Ao cair aqui tratar o tipo de disparo!
                     */
                }
                finally
                {
                    Console.Clear();
                }
            }

            // Resultado final 
            DisplayBoard(board);
            Console.WriteLine("ACABOU O JOGO MALANDRÂO? MATO TODO MUNDO!");
            Console.ReadLine();
        }

        /**
         * Insere os navios no tabuleiro
         */
        static void PlaceShips(int[,] board)
        {
            {
                Random rand = new Random();

                // Navio 1 (tamanho 3)
                bool placed = false;
                while (!placed)
                {
                    int x = rand.Next(0, board.GetLength(0) - 2);
                    int y = rand.Next(0, board.GetLength(1));
                    if (board[x, y] == 0 && board[x + 1, y] == 0 && board[x + 2, y] == 0)
                    {
                        board[x, y] = 1;
                        board[x + 1, y] = 1;
                        board[x + 2, y] = 1;
                        placed = true;
                    }
                }

                // Navio 2 (tamanho 3)
                placed = false;
                while (!placed)
                {
                    int x = rand.Next(0, board.GetLength(0) - 2);
                    int y = rand.Next(0, board.GetLength(1));
                    if (board[x, y] == 0 && board[x + 1, y] == 0 && board[x + 2, y] == 0)
                    {
                        board[x, y] = 1;
                        board[x + 1, y] = 1;
                        board[x + 2, y] = 1;
                        placed = true;
                    }
                }

                // Navio 3 (tamanho 4)
                placed = false;
                while (!placed)
                {
                    int x = rand.Next(0, board.GetLength(0));
                    int y = rand.Next(0, board.GetLength(1) - 3);
                    if (board[x, y] == 0 && board[x, y + 1] == 0 && board[x, y + 2] == 0 && board[x, y + 3] == 0)
                    {
                        board[x, y] = 1;
                        board[x, y + 1] = 1;
                        board[x, y + 2] = 1;
                        board[x, y + 3] = 1;
                        placed = true;
                    }
                }
            }
        }

        static void DisplayBoard(int[,] board)
        {
            AlteraCorTextoConsole(ConsoleColor.Yellow);
            Console.WriteLine("     1      2      3      4      5      6      7      8      9      10");
            Console.ResetColor();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                AlteraCorTextoConsole(ConsoleColor.Yellow);
                Console.Write((char)('A' + i) + " ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    switch (board[i, j])
                    {
                        case 0:
                            AlteraCorTextoConsole(ConsoleColor.Cyan);
                            Console.Write("[  -  ]");
                            Console.ResetColor();
                            break;
                        case 1:
                            AlteraCorTextoConsole(ConsoleColor.Green);
                            Console.Write("[  O  ]");
                            Console.ResetColor();
                            break;
                        case 2:
                            AlteraCorTextoConsole(ConsoleColor.Red);
                            Console.Write("[  X  ]");
                            Console.ResetColor();
                            break;
                        default: //Tratar esse case
                            AlteraCorTextoConsole(ConsoleColor.Red);
                            Console.Write("[  Sexo? ]");
                            Console.ResetColor();
                            break;
                    }
                }

                Console.WriteLine();
            }
        }

        static void AlteraCorTextoConsole(ConsoleColor color)
        {
            Console.ResetColor();
            Console.ForegroundColor = color;
        }

        static bool FireShot(int[,] board, int x, int y)
        {
            if (board[x, y] == 1)
            {
                board[x, y] = 2; //Acertou
                return true;
            }
            else
            {
                board[x, y] = 3; //Errou
                return false;
            }
        }

        static bool IsGameOver(int[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == 1)
                    {
                        return false;
                    }
                }
            }
            return true; // Mato TODO MUNDO
        }
    }
}