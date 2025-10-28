using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MontandoTimes.Entidades.Interfaces;

namespace MontandoTimes.Entidades
{
    public class FormacaoTime
    { 
        public Jogador? Goleiro { get; set; }
        public Jogador? LateralDireito { get; set; }  
        public Jogador? ZagueiroDireito { get; set; }
        public Jogador? ZagueiroEsquerdo { get; set; }
        public Jogador? LateralEsquerdo { get; set; }
        public Jogador? Volante { get; set; }
        public Jogador? MeiaDireita { get; set; }
        public Jogador? MeiaEsquerda { get; set; }
        public Jogador? MeiaAtacante { get; set; }
        public Jogador? PontaDireita { get; set; }
        public Jogador? PontaEsquerda { get; set; }
        public Jogador? Centroavante { get; set; }
        public Jogador? NaoDefinido { get; set; }


    }

    public class FormacaoTimeRacha
    { 
        public Jogador? NaoDefinido1 { get; set; }
        public Jogador? NaoDefinido2 { get; set; }
        public Jogador? NaoDefinido3 { get; set; }
        public Jogador? NaoDefinido4 { get; set; }
        public Jogador? NaoDefinido5 { get; set; }
        public Jogador? NaoDefinido6 { get; set; }
        public Jogador? NaoDefinido7 { get; set; }
        public Jogador? NaoDefinido8 { get; set; }

    }


}
