namespace JMFWebAppUpdt.Models
{/// <summary>
/// Informações para apagar um jogador
/// </summary>
    public class DeletePlayer:NewPlayer
    {
        /// <summary>
        /// ID do aplicativo para apagar jogador
        /// </summary>
        public string DeleteID { get; set; }
        /// <summary>
        /// Senha para dar permissão para apagar o jogador
        /// </summary>
        public string DeletePW { get; set; }
    }
}