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

        public void EscalarTime(List<IJogador> jogadores)
        {     
 
            var indice = 1;
            foreach (var posicao in PosicoesJogadores)
            {

                double experiencia = 2.5;
                Jogador? jogador = new Jogador();

                if (Racha)
                {
                    experiencia =  new Random().NextDouble() * 5.0;                    

                    var jogadorRacha = (Jogador?)(jogadores?
                                        .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                                        .OrderBy(jogador => Math.Abs(jogador.Experiencia - experiencia))
                                        .FirstOrDefault());

                    SetaFormacaoRacha(jogadorRacha, indice);
                    indice++;
                    
                }
                else
                {
                   
                     jogador = (Jogador?)(jogadores?
                                    .Where(jogador => jogador.Posicao == posicao)
                                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - experiencia))
                                    .FirstOrDefault());

                    var jogadoresPosicoesNaoDefinida = jogadores?.Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido).ToList();

                    if (jogador is null)

                        jogador = (Jogador?)(jogadoresPosicoesNaoDefinida?
                                    .Where(jogador => jogador.Posicao == EPosicaoJogador.NaoDefinido)
                                    .OrderBy(jogador => Math.Abs(jogador.Experiencia - experiencia))
                                    .FirstOrDefault());
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
        private bool TemPropriedadesNulas(Jogador jogador)
        {
            if (jogador is null) 
                return false;
            return true;

        }
        public void MostrarEscalacaoTime()
        {
            Console.WriteLine($"TIME: {Nome}\n");

            if(Racha)
            {
               if(TemPropriedadesNulas(FormacaoRacha.Jogador1)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador1.Nome} - Posição: {FormacaoRacha.Jogador1.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador1.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador2)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador2.Nome} - Posição: {FormacaoRacha.Jogador2.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador2.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador3)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador3.Nome} - Posição: {FormacaoRacha.Jogador3.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador3.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador4)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador4.Nome} - Posição: {FormacaoRacha.Jogador4.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador4.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador5)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador5.Nome} - Posição: {FormacaoRacha.Jogador5.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador5.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador6)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador6.Nome} - Posição: {FormacaoRacha.Jogador6.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador6.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador7)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador7.Nome} - Posição: {FormacaoRacha.Jogador7.Posicao.ToString()} - Experiencia: {FormacaoRacha?.Jogador7.Experiencia}");
               if(TemPropriedadesNulas(FormacaoRacha.Jogador8)) 
                    Console.WriteLine($"JOGADOR: {FormacaoRacha?.Jogador8.Nome} - Posição: {FormacaoRacha.Jogador8.Posicao.ToString()} - Experiencia: {FormacaoRacha.Jogador8.Experiencia}");
                
                Console.WriteLine($"------------------------------------------------------");
            }
            
        }
    }
}
