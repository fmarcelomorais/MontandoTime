using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void EscolherJogador(List<IJogador> jogadores, EPosicaoJogador posicaoJogador)
        {
            var goleiros = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.Goleiro).ToList();
            var lateraisDireito = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.LateralDireito).ToList();
            var lateraisEsquerdo = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.LateralEsquerdo).ToList();
            var zagueirosDireito = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.ZagueiroDireito).ToList();
            var zagueirosEsquerdo = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.ZagueiroEsquerdo).ToList();
            var volantes = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.Volante).ToList();
            var meiaDireita = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaDireita).ToList();
            var meiaEsquerda = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaEsquerda).ToList();
            var meiaAtacante = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaAtacante).ToList();
            var pontaDireita = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.PontaDireita).ToList();
            var pontaEsquerda = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.PontaEsquerda).ToList();
            var centroavantes = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.Centroavante).ToList();
            var naoDefinido = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido).ToList();
            
            var randon = new Random().NextDouble() * 5.0;

            var jogador = (Jogador?)(jogadores?
                .Where(jogador => jogador.Posicao == posicaoJogador)
                .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                .FirstOrDefault());

            if(jogador is null)
                jogador = (Jogador?)(naoDefinido?
                .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                .FirstOrDefault());

            SetaJogador(jogador, posicaoJogador);
            jogadores?.Remove(jogador);

        }

        private void SetaJogador(Jogador jogador, EPosicaoJogador posicaoJogador)
        {          
                
            if (posicaoJogador == EPosicaoJogador.Goleiro)
                Goleiro = jogador;
            if(posicaoJogador == EPosicaoJogador.LateralDireito)
                LateralDireito = jogador;
            if (posicaoJogador == EPosicaoJogador.LateralEsquerdo)
                LateralEsquerdo = jogador;
            if (posicaoJogador == EPosicaoJogador.ZagueiroEsquerdo)
                ZagueiroEsquerdo = jogador;
            if (posicaoJogador == EPosicaoJogador.ZagueiroDireito)
                ZagueiroDireito = jogador;
            if (posicaoJogador == EPosicaoJogador.PontaEsquerda)
                PontaEsquerda = jogador;
            if (posicaoJogador == EPosicaoJogador.PontaDireita)
                PontaDireita = jogador;
            if (posicaoJogador == EPosicaoJogador.Centroavante)
                Centroavante = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaAtacante)
                MeiaAtacante = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaDireita)
                MeiaDireita = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaEsquerda)
                MeiaEsquerda = jogador;
            if (posicaoJogador == EPosicaoJogador.Volante)
                Volante = jogador;
        }

        private void TemPropriedadesNulas(Jogador jogador)
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                var valor = prop.GetValue(this);
                if (valor == null)
                {
                    prop.SetValue(jogador, jogador);
                    break;
                }
            }
            
        }
    }


}
