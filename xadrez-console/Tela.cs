using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {

        public static void imprimirPartida(PartidaDeXadrez partida) {
            Tela.imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque) {
                    Console.WriteLine("\nXEQUE!");
                }
            } else {
                Console.WriteLine("\nXEQUE-MATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            ConsoleColor corPadrao = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corPadrao;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[ ");
            foreach (Peca x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.linhas; i++) {
                imprimirNumero(tab, i);
                for (int j = 0; j < tab.colunas; j++) {
                    imprimirPeca(tab.peca(i, j), i, j);
                }
                Console.WriteLine();
            }
            imprimirLetra(tab);
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++) {
                imprimirNumero(tab, i);
                for (int j = 0; j < tab.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j), i, j);
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
                Console.BackgroundColor = fundoOriginal;
            }
            imprimirLetra(tab);
        }

        private static bool validarLinha(string s, int linha) {
            if ((int.TryParse((s[1] + ""), out linha)) && (linha == 1 || linha == 2 || linha == 3 || 
                linha == 4 || linha == 5 || linha == 6 || linha == 7 || linha == 8)) {
                return true;
            } else {
                return false;
            }
        }

        private static bool validarColuna(string s, char coluna) {
            if (coluna == 'a' || coluna == 'b' || coluna == 'c' || coluna == 'd' || 
                coluna == 'e' || coluna == 'f' || coluna == 'g' || coluna == 'h') {
                return true;
            } else {
                return false;
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = 0;
            if (validarLinha(s, linha) && validarColuna(s, coluna)) {
                coluna = s[0];
                linha = int.Parse(s[1] + "");
            } else {
                throw new TabuleiroException("O valor digitado está incorreto!");
            }
            //int linha = int.Parse(s[1] + "");
            /* Na linha acima, para o programa entender o Parse do char na posição 1, foi 
               preciso acrescentar as aspas para fazer uma conversão explícita para string. */
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca, int i, int j) {
            if (peca == null) {
                imprimirTraco(i, j);
                Console.Write(" ");
            } else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corPadrao;
                }
                Console.Write(" ");
            }
        }

        public static void imprimirTraco(int i, int j) {
            if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1) {
                Console.Write("-");
            } else {
                ConsoleColor corPadrao = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("-");
                Console.ForegroundColor = corPadrao;
            }
        }

        public static void imprimirLetra(Tabuleiro tab) {
            if (tab.linhas < 10) {
                Console.Write("  ");
            } else {
                Console.Write("   ");
            }
            char letra = 'a';
            for (int i = 0; i < tab.colunas; i++) {
                Console.Write((char)(letra + i) + " ");
            }
            Console.WriteLine();
        }

        public static void imprimirNumero(Tabuleiro tab, int i) {
            if (tab.linhas < 10) {
                Console.Write(tab.linhas - i + " ");
            } else if (tab.linhas - i < 10) {
                Console.Write(" " + (tab.linhas - i) + " ");
            } else {
                Console.Write(tab.linhas - i + " ");
            }
        }
    }
}
