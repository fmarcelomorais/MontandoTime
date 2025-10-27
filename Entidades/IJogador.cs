using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontandoTimes.Entidades
{
    public interface IJogador
    {
        string Nome { get; set; }
        EPosicaoJogador Posicao { get; set; }
        double Experiencia { get; set; }
    }
}
