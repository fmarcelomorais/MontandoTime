
using MontandoTimes.Entidades;
using MontandoTimes.Utils;

var jogadores = new List<IJogador>
{
        new Jogador { Nome = " maniesta", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.5 },
        new Jogador { Nome = " Daniel", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.0 },
        new Jogador { Nome = " Joseph", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.5 },
        new Jogador { Nome = " Matheus Lopes", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 5.0 },
        new Jogador { Nome = " Kauan(c.pedro)", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.0 },
        new Jogador { Nome = " Flad", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.5 },
        new Jogador { Nome = " Wladi", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.5 },
        new Jogador { Nome = " Jeffg2", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.0 },
        new Jogador { Nome = " desio", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.0 },
        new Jogador { Nome = " Wesdras", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.5 },
        new Jogador { Nome = " Márcio", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.0 },
        new Jogador { Nome = " Fabio cr7", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.5 },
        new Jogador { Nome = " Jefferson Veneza", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.5 },
        new Jogador { Nome = " Victor G2", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.5 },
        new Jogador { Nome = " Rudger", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.0 },
        new Jogador { Nome = " Wanderson", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.0 },
        new Jogador { Nome = " Mateus rache", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 5.0 },
        new Jogador { Nome = " PedroH", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 2.7 },
        new Jogador { Nome = " Matheus (c.pedro)", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.2 },
        new Jogador { Nome = " Neném", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.8 },
        new Jogador { Nome = " Keldery", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.1 },
        new Jogador { Nome = " Joermeson", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 3.9 },
        new Jogador { Nome = " Mailton", Posicao = EPosicaoJogador.NaoDefinido, Experiencia = 4.3 },

};
var posicoesJogadore = new List<EPosicaoJogador>
{
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
    times.Add(new Time($" {i+1}", posicoesJogadore));
}

foreach (var time in times)
{   
    time.EscolherJogador(jogadores); 
}





 


