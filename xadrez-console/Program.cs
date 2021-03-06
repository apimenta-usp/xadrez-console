﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                Tela.imprimirTelaInicial();

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {

                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);
                    } catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey(true);
                        //Console.ReadLine();
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        //Console.WriteLine(e.StackTrace);
                        Console.ReadKey(true);
                        //Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey(true);
            //Console.ReadLine();
        }
    }
}
