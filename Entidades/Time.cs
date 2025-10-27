using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontandoTimes.Entidades
{
    public class Time
    {
        public string Nome { get; set; } = string.Empty;
        public int QuantidadeJogadores { get; set; } = 5;
        public FormacaoTime Formacao { get; set; } = new FormacaoTime();
        public List<EPosicaoJogador> PosicoesJogadores { get; set; } = new List<EPosicaoJogador>();

        public Time(string nomeTime, List<EPosicaoJogador> posisaoJogaroes)
        {
            Nome = nomeTime;
            PosicoesJogadores = posisaoJogaroes;
            QuantidadeJogadores = posisaoJogaroes.Count;
        }

        public void EscolherJogador(List<IJogador> jogadores, EPosicaoJogador posicaoJogador)
        {
            foreach(var posicao in PosicoesJogadores)
            {
                
                var jogadoresEscolhidos = jogadores.Where(jogador => jogador.Posicao == posicao).ToList();
                var randon = new Random().NextDouble() * 5.0;

                var jogador = (Jogador?)(jogadores?
                    .Where(jogador => jogador.Posicao == posicao)
                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                    .FirstOrDefault());

                var naoDefinido = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido).ToList();

                if (jogador is null)
                    jogador = (Jogador?)(naoDefinido?
                    .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                    .FirstOrDefault());

                SetaJogador(jogador, posicao);
                jogadores?.Remove(jogador);
                //var lateraisDireito = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.LateralDireito).ToList();
                //var lateraisEsquerdo = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.LateralEsquerdo).ToList();
                //var zagueirosDireito = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.ZagueiroDireito).ToList();
                //var zagueirosEsquerdo = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.ZagueiroEsquerdo).ToList();
                //var volantes = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.Volante).ToList();
                //var meiaDireita = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaDireita).ToList();
                //var meiaEsquerda = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaEsquerda).ToList();
                //var meiaAtacante = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.MeiaAtacante).ToList();
                //var pontaDireita = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.PontaDireita).ToList();
                //var pontaEsquerda = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.PontaEsquerda).ToList();
                //var centroavantes = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.Centroavante).ToList();
            }

            //var randon = new Random().NextDouble() * 5.0;

            //var jogador = (Jogador?)(jogadores?
            //    .Where(jogador => jogador.Posicao == posicaoJogador)
            //    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
            //    .FirstOrDefault());

            //if (jogador is null)
            //    jogador = (Jogador?)(naoDefinido?
            //    .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
            //    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
            //    .FirstOrDefault());

            //SetaJogador(jogador, posicaoJogador);
            //jogadores?.Remove(jogador);

        }

        private void SetaJogador(Jogador jogador, EPosicaoJogador posicaoJogador)
        {

            if (posicaoJogador == EPosicaoJogador.Goleiro)
                Formacao.Goleiro = jogador;
            if (posicaoJogador == EPosicaoJogador.LateralDireito)
               Formacao.LateralDireito = jogador;
            if (posicaoJogador == EPosicaoJogador.LateralEsquerdo)
                Formacao.LateralEsquerdo = jogador;
            if (posicaoJogador == EPosicaoJogador.ZagueiroEsquerdo)
                Formacao.ZagueiroEsquerdo = jogador;
            if (posicaoJogador == EPosicaoJogador.ZagueiroDireito)
                Formacao.ZagueiroDireito = jogador;
            if (posicaoJogador == EPosicaoJogador.PontaEsquerda)
                Formacao.PontaEsquerda = jogador;
            if (posicaoJogador == EPosicaoJogador.PontaDireita)
                Formacao.PontaDireita = jogador;
            if (posicaoJogador == EPosicaoJogador.Centroavante)
                Formacao.Centroavante = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaAtacante)
                Formacao.MeiaAtacante = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaDireita)
                Formacao.MeiaDireita = jogador;
            if (posicaoJogador == EPosicaoJogador.MeiaEsquerda)
                Formacao.MeiaEsquerda = jogador;
            if (posicaoJogador == EPosicaoJogador.Volante)
                Formacao.Volante = jogador;
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
