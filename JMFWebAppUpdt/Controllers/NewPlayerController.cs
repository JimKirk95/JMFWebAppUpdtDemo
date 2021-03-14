using JMFWebAppUpdt.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JMFWebAppUpdt.Controllers
{
    /// <summary>
    /// Criação de novos jogadores
    /// </summary>
    public class NewPlayerController : ApiController
    {
/// <summary>
/// Apenas consulta de estrutuda dos dados a serem enviados no formato Json
/// </summary>
/// <returns>Exemplo da estrutura para criação de um novo jogador</returns>
        // GET: api/UpdScores
        public NewPlayer Get()
        {
            NewPlayer player = new NewPlayer {CallerID = "ID do APP fazendo request", CallerPW = "password",  Nickname = "Nick do Novo usuário", Password = "Senha do novo usuário"};
            return player;
        }
        /// <summary>
        /// Cria um novo jogador com o Nickname e a senha passadas no corpo da chamada
        /// </summary>
        /// <param name="player">Dados para criação do novo jogador, incluindo identificação do caller</param>
        /// <returns>HttpResponseMessage indicando se houve algum problema ou se o jogador foi criado</returns>
        // POST: api/NewPlayer
        public HttpResponseMessage Post([FromBody] NewPlayer player)
        { 
            string DBResponse;
            if (player==null)
            {
                DBResponse = "Formato de dados inválido, faça um Get para receber um exemplo.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((player.CallerID == null) || (player.CallerPW == null) || (player.Nickname == null) || (player.Password == null))
            {
                DBResponse = "Estão faltando dados, faça um Get para receber um exemplo e envie todas as informações.";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            //Só pra evitar que qualquer um crie novas usuários, fiz um ID/Senha hardcoded
            //Se comentar o próximo if, qualquer coisa vai passar... senão é só passar JMF e JMF
            string CallerPW = Environment.GetEnvironmentVariable(player.CallerID);
            if ((CallerPW != null ) || (!player.CallerPW.Equals(CallerPW)))
            {   //Podia pegar do ambiente também... na próxima vou fazer isso, usar variáveis do ambiente
                DBResponse = "Credenciais inválidas, você não pode criar novos usuários";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((player.Nickname.Length == 0) || (player.Password.Length == 0))
            {
                DBResponse = "Dados inválidos, Nick e senha não podem estar vazios";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            if ((player.Nickname.Length > 20) || (player.Password.Length > 20))
            {
                DBResponse = "Sinto muito, para testes, o Nick e a senha estão limitados a 20 caracteres";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
            }
            DBResponse = Database.UpdateDB.CreateNewPlayer(player.Nickname, player.Password);
            if (DBResponse.Equals("OK"))
            {
                player.CallerID = "";
                player.CallerPW = "";
                player.Password = "";
                HttpResponseMessage response = Request.CreateResponse<NewPlayer>(HttpStatusCode.Created, player);
                string uri = Url.Link("DefaultApi", new { id = player.Nickname });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, DBResponse);
        }
    }
}