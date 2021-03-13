using JMFWebAppUpdt.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JMFWebAppUpdt.Controllers
{/// <summary>
/// Atualiza estatísticas do jogador
/// </summary>
    public class UpdScoresController : ApiController
    {
        /// <summary>
        /// Retorna estrutura que deve ser usada no Update
        /// </summary>
        /// <returns>Exemplo de Informações do Jogador</returns>
        // GET: api/UpdScores
        public PlayerStatus Get()
        {
            PlayerStatus player = new PlayerStatus { CallerID = "ID do APP fazendo request", CallerPW = "password do APP", Nickname = "Nick do Usuário", Password = "Senha do usuário" };
            for (int i = 0; i < 5; i++)
            {
                player.NewStats.Add(i);
            }
            return player;
        }
        /// <summary>
        /// Atualiza dados do Jogador
        /// </summary>
        /// <param name="id">Código para atualização</param>
        /// <param name="player">Dados de atualização</param>
        /// <returns> Mensagem com OK ou descrição do erro </returns>
        // PUT: api/UpdScores/5
        public HttpResponseMessage Put(int id, [FromBody] PlayerStatus player)
        {
            string DBResponse;
            if (id != 42) //Just an easy check, if you don't know why 42, I do not want to work with you :-)
            {
                DBResponse = "PUT inválido.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if (player == null)
            {
                DBResponse = "Formato de dados inválido, faça um Get para receber um exemplo.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((player.CallerID == null) || (player.CallerPW == null) || (player.Nickname == null) || (player.Password == null) || (player.NewStats == null))
            {
                DBResponse = "Estão faltando dados, faça um Get para receber um exemplo e envie todas as informações.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if (player.NewStats.Count == 0)
            {
                DBResponse = "Você deve enviar pelo menos um valor no NewStat";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((player.Nickname.Length == 0) || (player.Password.Length == 0))
            {
                DBResponse = "Dados inválidos, Nick e senha não podem estar vazios";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((!player.CallerID.Equals("JMF")) || (!player.CallerPW.Equals("JMF")))
            {
                DBResponse = "Credenciais inválidas, você não pode atualizar o status";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            int NScores = Math.Min(6, player.NewStats.Count);
            int[] NewScores = new int[NScores];
            int total = player.NewStats[0];
            int parcial = 0;
            for (int i = 0; i < NewScores.Length; i++)
            {
                NewScores[i] = player.NewStats[i];
                if (i % 3 != 0)
                {
                    parcial += player.NewStats[i];
                }
                if (i == 3)
                {
                    if (parcial > total)                    
                    {
                        DBResponse = "Dados parciais maiores que o total.";
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
                    }
                    if (player.NewStats.Count > 3)
                    {
                        total = player.NewStats[3];
                        parcial = 0;
                    }
                }
                if ((i > 2) && (player.NewStats[i] > player.NewStats[i-3]))
                {
                    DBResponse = "Dados semanais maiores que os totais.";
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
                }
            }
            if (parcial > total)
            {
                DBResponse = "Dados parciais maiores que o total.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            DBResponse = Database.UpdateDB.UpdatePlayerStats(player.Nickname, player.Password, NewScores);
            if (DBResponse.Equals("OK"))
            {
                player.CallerID = "";
                player.CallerPW = "";
                player.Password = "";
                player.NewStats.Clear();
                for (int i = 0; i < NewScores.Length; i++)
                {
                    player.NewStats.Add(NewScores[i]);
                }
                HttpResponseMessage response = Request.CreateResponse<PlayerStatus>(HttpStatusCode.Created, player);
                string uri = Url.Link("DefaultApi", new { id = player.Nickname });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
        }
        /// <summary>
        /// Apaga jogador da base de dados
        /// </summary>
        /// <param name="id">Código para apagar jogador</param>
        /// <param name="dp">Dados do jogador a ser apagado</param>
        /// <returns> Mensagem com OK ou descrição do erro </returns>
        // DELETE: api/UpdScores/5
        public HttpResponseMessage Delete(int id, [FromBody] DeletePlayer dp)
        {
            string DBResponse = "OI";
            if (id != 42) //Just an easy check, if you don't know why 42, I do not want to work with you :-)
            {
                DBResponse = "DELETE inválido.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if (dp == null)
            {
                DBResponse = "Formato de dados inválido. Verifique a documentação.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((dp.CallerID == null) || (dp.CallerPW == null) || (dp.Nickname == null) || (dp.Password == null) || (dp.DeleteID == null) || (dp.DeletePW == null))
            {
                DBResponse = "Estão faltando dados. Verifique a documentação.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((dp.Nickname.Length == 0) || (dp.Password.Length == 0))
            {
                DBResponse = "Dados inválidos, Nick e senha não podem estar vazios";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((!dp.CallerID.Equals("JMF")) || (!dp.CallerPW.Equals("JMF")) || (!dp.DeleteID.Equals("DJMF")) || (!dp.DeletePW.Equals("DJMF")))
            {
                DBResponse = "Credenciais inválidas, você não pode apagar o jogador";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            DBResponse = Database.UpdateDB.DeletePlayer(dp.Nickname, dp.Password);
            if (DBResponse.Equals("OK"))
            {
                dp.CallerID = "";
                dp.CallerPW = "";
                dp.Password = "";
                dp.DeleteID = "";
                dp.DeletePW = "";
                HttpResponseMessage response = Request.CreateResponse<DeletePlayer>(HttpStatusCode.Created, dp);
                string uri = Url.Link("DefaultApi", new { id = dp.Nickname });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
        }
    }
}