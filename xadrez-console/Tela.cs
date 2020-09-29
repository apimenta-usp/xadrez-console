using System;
using System.Drawing;
using tabuleiro;

namespace xadrez_console {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.linhas; i++) {
                if (tab.linhas < 10) {
                    Console.Write(tab.linhas - i + " ");
                } else if (tab.linhas - i < 10) {
                    Console.Write(" " + (tab.linhas - i) + " ");
                } else {
                    Console.Write(tab.linhas - i + " ");
                }
                for (int j = 0; j < tab.colunas; j++) {
                    if (tab.peca(i, j) == null) {
                        imprimirTraco(i, j);
                        Console.Write(" ");
                    } else {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
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

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branco) {
                Console.Write(peca);
            } else {
                ConsoleColor corPadrao = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corPadrao;
            }
        }

        public static void imprimirTraco(int i, int j) {
            if (i%2 == 0 && j%2 == 0 || i%2 == 1 && j%2 == 1) {
                Console.Write("-");
            } else {
                ConsoleColor corPadrao = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("-");
                Console.ForegroundColor = corPadrao;
            }
        }
    }
}
