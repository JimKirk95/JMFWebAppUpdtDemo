namespace JMFWebAppUpdt.Models
{
    /// <summary>
    /// Informações básicas para acesso a conta de jogador
    /// </summary>
    public class NewPlayer
    {
        /// <summary>
        /// Idenficação do APP que está fazendo a chamada para a API
        /// </summary>
        public string CallerID { get; set; }
        /// <summary>
        /// Senha para acesso à API
        /// </summary>
        public string CallerPW { get; set; }
        /// <summary>
        /// Nickname do Jogador
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// Senha do Jogador
        /// </summary>
        public string Password { get; set; }
    }
}