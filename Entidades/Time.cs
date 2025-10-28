using MontandoTimes.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontandoTimes.Entidades
{
    public class Time
    {
        public string Nome { get; set; } = "Time: ";
        public int QuantidadeJogadores { get; set; }
        private bool Racha { get; set; } = false;
        public FormacaoTime Formacao { get; set; } = new FormacaoTime();
        public FormacaoTimeRacha FormacaoRacha { get; set; } = new FormacaoTimeRacha();
        public List<EPosicaoJogador> PosicoesJogadores { get; set; } = new List<EPosicaoJogador>();

        public Time(string nomeTime, List<EPosicaoJogador> posisaoJogaroes, bool racha=true)
        {
            //posisaoJogaroes.Add(EPosicaoJogador.Goleiro);
            Racha = racha;
            Nome += nomeTime;
            PosicoesJogadores = posisaoJogaroes;
            QuantidadeJogadores = posisaoJogaroes.Count;
        }

        public void EscolherJogador(List<IJogador> jogadores)
        {
       
            double qtdTimesPossiveis = (double)jogadores.Count / QuantidadeJogadores;
            double qtdJogaresNãoAlocados = Math.Round((qtdTimesPossiveis - Math.Truncate(qtdTimesPossiveis)) * QuantidadeJogadores, 1);
            var qtdGoleiros = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido).Count();
            
            //if ( qtdGoleiros < (int)qtdTimesPossiveis)
            //{
            //     Console.WriteLine("Não é possivel montar todos os times pois não há goleiros suficiente");
            //}

            var indice = 1;
            foreach (var posicao in PosicoesJogadores)
            {                
                var jogadoresEscolhidos = jogadores.Where(jogador => jogador.Posicao == posicao).ToList();
                var randon = new Random().NextDouble() * 5.0;

                var jogador = (Jogador?)(jogadores?
                    .Where(jogador => jogador.Posicao == posicao)
                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                    .FirstOrDefault());

                var jogadoresRacha = jogadores.Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido).ToList();

                if (jogador is null)
                    jogador = (Jogador?)(jogadoresRacha?
                    .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                    .FirstOrDefault());


                if (Racha)
                {
                    var jogadorRacha = (Jogador?)(jogadoresRacha?
                    .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - randon))
                    .FirstOrDefault());
                    
                    SetaFormacaoRacha(jogadorRacha, indice);
                    indice++;
                    
                }
                else
                {

                    SetaFormacao(jogador, posicao);
                }

                jogadores?.Remove(jogador);
                               
            }

        }

 
        
        private void SetaFormacaoRacha(IJogador jogador, int i)
        {
            FormacaoRacha.GetType().GetProperty($"Jogador{i}")?.SetValue(FormacaoRacha, jogador);
        }
        private void SetaFormacao(Jogador jogador, EPosicaoJogador posicaoJogador)
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
