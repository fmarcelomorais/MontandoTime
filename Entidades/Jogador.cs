using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontandoTimes.Entidades
{
    public class Jogador: IJogador
    {
        public string Nome { get; set; } = string.Empty;
        public EPosicaoJogador Posicao { get; set; }
        public double Experiencia { get; set; } = 2.5;
    }
}
