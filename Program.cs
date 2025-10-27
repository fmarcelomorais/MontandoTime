
using MontandoTimes.Entidades;
using MontandoTimes.Utils;

var jogadores = new List<IJogador>
{
        new Jogador { Nome = "Alice", Posicao = EPosicaoJogador.Goleiro, Experiencia = 3.5 },
        new Jogador { Nome = "Albuquerque", Posicao = EPosicaoJogador.Goleiro, Experiencia = 2.5 },

        new Jogador { Nome = "Bruno", Posicao = EPosicaoJogador.LateralDireito, Experiencia = 2.8 },
        new Jogador { Nome = "Otávio", Posicao = EPosicaoJogador.LateralDireito, Experiencia = 2.4 },

        new Jogador { Nome = "Eduardo", Posicao = EPosicaoJogador.LateralEsquerdo, Experiencia = 2.5 },
        new Jogador { Nome = "Erick", Posicao = EPosicaoJogador.LateralEsquerdo, Experiencia = 2.25 },

        new Jogador { Nome = "Carlos", Posicao = EPosicaoJogador.ZagueiroDireito, Experiencia = 4.1 },
        new Jogador { Nome = "Marcos", Posicao = EPosicaoJogador.ZagueiroDireito, Experiencia = 2.9 },

        new Jogador { Nome = "Ricardo", Posicao = EPosicaoJogador.ZagueiroEsquerdo, Experiencia = 3.3 },
        new Jogador { Nome = "Daniel", Posicao = EPosicaoJogador.ZagueiroEsquerdo, Experiencia = 3.9 },


        new Jogador { Nome = "Natan", Posicao = EPosicaoJogador.Volante, Experiencia = 3.2 },
        new Jogador { Nome = "Felipe", Posicao = EPosicaoJogador.Volante, Experiencia = 4.3 },

        new Jogador { Nome = "Gustavo", Posicao = EPosicaoJogador.MeiaDireita, Experiencia = 3.1 },
        
        new Jogador { Nome = "Henrique", Posicao = EPosicaoJogador.MeiaEsquerda, Experiencia = 2.7 },
    
        new Jogador { Nome = "Igor", Posicao = EPosicaoJogador.MeiaAtacante, Experiencia = 5.0 },
        new Jogador { Nome = "Paulo", Posicao = EPosicaoJogador.MeiaAtacante, Experiencia = 4.0 },

        new Jogador { Nome = "João", Posicao = EPosicaoJogador.PontaDireita, Experiencia = 3.4 },
        new Jogador { Nome = "Samuel", Posicao = EPosicaoJogador.PontaDireita, Experiencia = 2.6 },
        
        new Jogador { Nome = "Kleber", Posicao = EPosicaoJogador.PontaEsquerda, Experiencia = 3.6 },
        new Jogador { Nome = "Victor", Posicao = EPosicaoJogador.PontaEsquerda, Experiencia = 4.2 },
    
        new Jogador { Nome = "Lucas", Posicao = EPosicaoJogador.Centroavante, Experiencia = 4.8 },
        new Jogador { Nome = "Thiago", Posicao = EPosicaoJogador.Centroavante, Experiencia = 3.7 },

        new Jogador { Nome = "Balbo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 1.5 },
        new Jogador { Nome = "Canela", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 1.7 },
        new Jogador { Nome = "Canela de Taça", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.7 },
        

};
var posicoesJogadore = new List<EPosicaoJogador>
{
    EPosicaoJogador.ZagueiroDireito,
    EPosicaoJogador.ZagueiroEsquerdo,
    EPosicaoJogador.LateralDireito,
    EPosicaoJogador.LateralEsquerdo,
    EPosicaoJogador.MeiaAtacante
};
var times = new List<Time>();

var qtdTimes = Ultilitarios.QuantidadeDeTimes(jogadores, posicoesJogadore);

for (var i =0; i < qtdTimes; i++)
{
    times.Add(new Time($" {i+1}", posicoesJogadore));
}

foreach (var time in times)
{   
    time.EscolherJogador(jogadores); 
}





 


