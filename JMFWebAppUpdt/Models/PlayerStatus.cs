using System.Collections.Generic;

namespace JMFWebAppUpdt.Models
{/// <summary>
/// Dados do jogador para atualização
/// </summary>
    public class PlayerStatus:NewPlayer
    {/// <summary>
    /// Lista com números de jogos para atualização. Pode ter de 1 a 6 inteiros
    /// </summary>
        public List<int> NewStats { get; set; } = new List<int>();
    }
}