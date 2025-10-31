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
            Nome += nomeTime;
            PosicoesJogadores = posisaoJogaroes;
            QuantidadeJogadores = posisaoJogaroes.Count;
            Racha = QuantidadeJogadores < 8 ? true : false;
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
                    jogador = jogadorRacha;
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
        ica{
            if (posicaoJogador == EPosicaoJogador.NaoDefinido)
                SetFormacaoAleatoria(jogador);
            else
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
        }

        private void SetFormacaoAleatoria(Jogador jogador)
        {
            var randon = new Random().Next(0, 11);

            if (randon == EPosicaoJogador.Goleiro.GetHashCode())
                Formacao.Goleiro = jogador;
            if (randon == EPosicaoJogador.LateralDireito.GetHashCode())
                Formacao.LateralDireito = jogador;
            if (randon == EPosicaoJogador.LateralEsquerdo.GetHashCode())
                Formacao.LateralEsquerdo = jogador;
            if (randon == EPosicaoJogador.ZagueiroEsquerdo.GetHashCode())
                Formacao.ZagueiroEsquerdo = jogador;
            if (randon == EPosicaoJogador.ZagueiroDireito.GetHashCode())
                Formacao.ZagueiroDireito = jogador;
            if (randon == EPosicaoJogador.PontaEsquerda.GetHashCode())
                Formacao.PontaEsquerda = jogador;
            if (randon == EPosicaoJogador.PontaDireita.GetHashCode())
                Formacao.PontaDireita = jogador;
            if (randon == EPosicaoJogador.Centroavante.GetHashCode())
                Formacao.Centroavante = jogador;
            if (randon == EPosicaoJogador.MeiaAtacante.GetHashCode())
                Formacao.MeiaAtacante = jogador;
            if (randon == EPosicaoJogador.MeiaDireita.GetHashCode())
                Formacao.MeiaDireita = jogador;
            if (randon == EPosicaoJogador.MeiaEsquerda.GetHashCode())
                Formacao.MeiaEsquerda = jogador;
            if (randon == EPosicaoJogador.Volante.GetHashCode())
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
            else
            {

                if (TemPropriedadesNulas(Formacao.Goleiro))
                    Console.WriteLine($"JOGADOR: {Formacao?.Goleiro.Nome} - Posição: {Formacao?.Goleiro.Posicao.ToString()} - Experiencia: {Formacao?.Goleiro.Experiencia}");
                if (TemPropriedadesNulas(Formacao.ZagueiroDireito))
                    Console.WriteLine($"JOGADOR: {Formacao?.ZagueiroDireito.Nome} - Posição: {Formacao?.ZagueiroDireito.Posicao.ToString()} - Experiencia: {Formacao?.ZagueiroDireito.Experiencia}");
                if (TemPropriedadesNulas(Formacao.ZagueiroEsquerdo))
                    Console.WriteLine($"JOGADOR: {Formacao?.ZagueiroEsquerdo.Nome} - Posição: {Formacao?.ZagueiroEsquerdo.Posicao.ToString()} - Experiencia: {Formacao?.ZagueiroEsquerdo.Experiencia}");
                if (TemPropriedadesNulas(Formacao.LateralDireito))
                    Console.WriteLine($"JOGADOR: {Formacao?.LateralDireito.Nome} - Posição: {Formacao?.LateralDireito.Posicao.ToString()} - Experiencia: {Formacao?.LateralDireito.Experiencia}");
                if (TemPropriedadesNulas(Formacao.LateralEsquerdo))
                    Console.WriteLine($"JOGADOR: {Formacao?.LateralEsquerdo.Nome} - Posição: {Formacao?.LateralEsquerdo.Posicao.ToString()} - Experiencia: {Formacao?.LateralEsquerdo.Experiencia}");
                if (TemPropriedadesNulas(Formacao.MeiaDireita))
                    Console.WriteLine($"JOGADOR: {Formacao?.MeiaDireita.Nome} - Posição: {Formacao?.MeiaDireita.Posicao.ToString()} - Experiencia: {Formacao?.MeiaAtacante.Experiencia}");
                if (TemPropriedadesNulas(Formacao.MeiaEsquerda))
                    Console.WriteLine($"JOGADOR: {Formacao?.MeiaEsquerda.Nome} - Posição: {Formacao?.MeiaEsquerda.Posicao.ToString()} - Experiencia: {Formacao?.MeiaEsquerda.Experiencia}");
                if (TemPropriedadesNulas(Formacao.Volante))
                    Console.WriteLine($"JOGADOR: {Formacao?.Volante.Nome} - Posição: {Formacao?.Volante.Posicao.ToString()} - Experiencia: {Formacao?.Volante.Experiencia}");
                if (TemPropriedadesNulas(Formacao.Centroavante))
                    Console.WriteLine($"JOGADOR: {Formacao?.Centroavante.Nome} - Posição: {Formacao?.Centroavante.Posicao.ToString()} - Experiencia: {Formacao?.Centroavante.Experiencia}");
                if (TemPropriedadesNulas(Formacao.MeiaAtacante))
                    Console.WriteLine($"JOGADOR: {Formacao?.MeiaAtacante.Nome} - Posição: {Formacao?.MeiaAtacante.Posicao.ToString()} - Experiencia: {Formacao?.MeiaAtacante.Experiencia}");
                if (TemPropriedadesNulas(Formacao.PontaDireita))
                    Console.WriteLine($"JOGADOR: {Formacao?.PontaDireita.Nome} - Posição: {Formacao?.PontaDireita.Posicao.ToString()} - Experiencia: {Formacao?.PontaDireita.Experiencia}");
                if (TemPropriedadesNulas(Formacao.PontaEsquerda))
                    Console.WriteLine($"JOGADOR: {Formacao?.PontaEsquerda.Nome} - Posição: {Formacao?.PontaEsquerda.Posicao.ToString()} - Experiencia: {Formacao?.PontaEsquerda.Experiencia}");

                Console.WriteLine($"------------------------------------------------------");
            }

            
        }
    }
}
