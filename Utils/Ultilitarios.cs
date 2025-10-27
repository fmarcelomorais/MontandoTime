using MontandoTimes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontandoTimes.Utils
{
    public static class Ultilitarios
    {
        public static int QuantidadeDeTimes(List<IJogador> jogadores, List<EPosicaoJogador> posicaoJogadore)
        {
            if(!posicaoJogadore.Any(posicao => posicao == EPosicaoJogador.Goleiro))
                posicaoJogadore.Add(EPosicaoJogador.Goleiro);
           
            double qtdTimesPossiveis = (double)jogadores.Count / posicaoJogadore.Count;

            return (int)qtdTimesPossiveis;
        }
    }
}
