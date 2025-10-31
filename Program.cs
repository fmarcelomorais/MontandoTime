
using MontandoTimes.Entidades;
using MontandoTimes.Utils;

var jogadores = new List<IJogador>
{
        new Jogador { Nome = "Alice", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.5 },
        new Jogador { Nome = "Albuquerque", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.5 },

        new Jogador { Nome = "Bruno", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.8 },
        new Jogador { Nome = "Otávio", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.4 },

        new Jogador { Nome = "Eduardo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.5 },
        new Jogador { Nome = "Erick", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.25 },

        new Jogador { Nome = "Carlos", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.1 },
        new Jogador { Nome = "Marcos", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.9 },

        new Jogador { Nome = "Ricardo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.3 },
        new Jogador { Nome = "Daniel", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.9 },


        new Jogador { Nome = "Natan", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.2 },
        new Jogador { Nome = "Felipe", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.3 },

        new Jogador { Nome = "Gustavo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.1 },
        
        new Jogador { Nome = "Henrique", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.7 },
    
        new Jogador { Nome = "Igor", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 5.0 },
        new Jogador { Nome = "Paulo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.0 },

        new Jogador { Nome = "João", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.4 },
        new Jogador { Nome = "Samuel", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.6 },
        
        new Jogador { Nome = "Kleber", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.6 },
        new Jogador { Nome = "Victor", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.2 },
    
        new Jogador { Nome = "Lucas", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.8 },
        new Jogador { Nome = "Thiago", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.7 },

        new Jogador { Nome = "Balbo", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 1.5 },
        new Jogador { Nome = "Canela", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 1.7 },
        new Jogador { Nome = "Canela de Taça", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.7 },
        

};
var posicoesJogadore = new List<EPosicaoJogador>
{
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido,
    EPosicaoJogador.NaoDefinido
};
var times = new List<Time>();

var qtdTimes = Ultilitarios.QuantidadeDeTimes(jogadores, posicoesJogadore);

for (var i =0; i < qtdTimes; i++)
{
    times.Add(new Time($" {i+1}", posicoesJogadore, true));
}

foreach (var time in times)
{   
    time.EscalarTime(jogadores);
    time.MostrarEscalacaoTime();
}


