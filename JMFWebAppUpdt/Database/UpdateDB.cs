using System;
using System.Data.SqlClient;

namespace JMFWebAppUpdt.Database
{
    public class UpdateDB
    {
        private static string ConnectionString;
        private static void SetConnectionString()
        {   //Should change from Environment variables to user secrets or Azure key vault
            string DS = Environment.GetEnvironmentVariable("JMFSERVER");
            string UI = Environment.GetEnvironmentVariable("JMFUPDT"); //UPDATE USER, WITH GRANT IN THE TABLE
            string PW = Environment.GetEnvironmentVariable("JMFPASS");
            string IC = Environment.GetEnvironmentVariable("JMFDB");
            ConnectionString = $"Data Source= {DS}; User ID={UI}; Password={PW}; Initial Catalog={IC}";
        }
        public static string CreateNewPlayer(string Nick, string Pass)
        {
            SetConnectionString(); //Variáveis de ambiente podem ter sido atualizadas
            using (SqlConnection connection = new SqlConnection(ConnectionString)) //Cria conexão com o DB
            {
                SqlDataReader dr=null;
                SqlCommand command = new SqlCommand($"select max(id) from AppUsers", connection); //Check if nick exist
                try
                {
                    command.Connection.Open(); //Oppen Connection to the database
                    dr = command.ExecuteReader();
                    if (dr.HasRows) //Found info
                    {
                        dr.Read();
                        int id = (int)dr[0]; //max id
                        if (id > int.MaxValue - 10)
                        {
                            dr.Close();
                            return "Desculpe, número máximo de usuáris atingido. Por favor entre em contato com o administrador.";
                        }
                    }
                    dr.Close(); //Empty table?
                    command = new SqlCommand($"select NICK from AppUsers where Nick = '{Nick}'", connection); //Check if nick exist
                    dr = command.ExecuteReader();
                    if (dr.HasRows) //Found info
                    { //OK, deveria ter feito com um username, ou e-mail único e nick repetido, fica pra próxima
                        dr.Close();
                        return "Nickname já usado, por favor escolha outro";
                    }
                    dr.Close();
                    command = new SqlCommand($"Insert into AppUsers VALUES ('{Nick}', '{Pass}', 0, 0, 0, 0, 0, 0, 0)", connection);
                    if (command.ExecuteNonQuery() > 0)
                        return "OK"; //UPDATE CONCLUIDO
                    return "Não foi possível criar o novo usuário. Por favor tente ou nick ou tente mais tarde!";
                }
                catch (Exception e)
                {
                    if (dr != null)
                        dr.Close();
                    return e.Message; //Problemas de conexão com o banco de dados (permissão ou internet)
                }
            }
        }


        public static string DeletePlayer(string Nick, string Pass)
        {
            SetConnectionString(); //Variáveis de ambiente podem ter sido atualizadas 
            using (SqlConnection connection = new SqlConnection(ConnectionString)) //Cria conexão com o DB
            {
                SqlDataReader dr = null; //Retorno da Query
                SqlCommand command = new SqlCommand($"select ID, NICK, PASS from AppUsers where Nick = '{Nick}' and Pass = '{Pass}'", connection); //Cria a Query propriamente dita 
                try
                {
                    command.Connection.Open(); //Oppen Connection to the database
                    dr = command.ExecuteReader();
                    if (dr.HasRows) //Found info
                    {
                        dr.Read();
                        int id = (int)dr[0]; //first info is the id
                        dr.Close();
                        command = new SqlCommand($"DELETE FROM AppUsers WHERE ID = {id}", connection);
                        if (command.ExecuteNonQuery() > 0)
                            return "OK"; //DELETOU REGISTRO
                        return "Não foi possível apagar o usuário. Por favor tente mais tarde!";
                    }
                    else
                    {
                        return "Não foi possível localizar o usuário, por favor confira o Nick e a senha.";
                    }
                }
                catch (Exception e)
                {
                    if (dr != null)
                        dr.Close();
                    return e.Message;
                }
            }
        }

        public static string UpdatePlayerStats(string Nick, string Pass, int[] Scores)
        {
            SetConnectionString();
            using (SqlConnection connection = new SqlConnection(ConnectionString)) //Cria conexão com o DB
            {
                SqlDataReader dr = null; //Retorno da Query
                SqlCommand command = new SqlCommand($"select ID, NICK, PASS from AppUsers where Nick = '{Nick}' and Pass = '{Pass}'", connection); //Cria a Query propriamente dita 
                try
                {
                    command.Connection.Open(); //Oppen Connection to the database
                    dr = command.ExecuteReader();
                    if (dr.HasRows) //Found info
                    {
                        int[] PS = new int[6];
                        dr.Read();
                        int id = (int)dr[0]; //first info is the id
                        dr.Close();
                        command = new SqlCommand($"select * from PlayerInfo where ID = '{id}'", connection);
                        dr = command.ExecuteReader();
                        dr.Read();
                        for (int i = 0; i < PS.Length; i++)
                        {
                            if (i < Scores.Length)
                            { //Os Scores vão saturar em int.MaxValue, sem overflow
                                PS[i] = Scores[i] < (int.MaxValue - (int)dr[i + 1]) ? (int)dr[i + 1] + Scores[i] : int.MaxValue;
                                Scores[i] = PS[i];
                            }
                            else
                            {
                                PS[i] = (int)dr[i + 1];
                            }
                        }
                        dr.Close();
                        command = new SqlCommand($"UPDATE AppUsers SET TOTGAMES = {PS[0]}, TOTWINS = {PS[1]}, TOTDRAW = {PS[2]}, WGAMES = {PS[3]}, WWINS = {PS[4]}, WDRAW = { PS[5]} WHERE ID = '{id}'", connection);
                        if (command.ExecuteNonQuery() > 0)
                            return "OK"; //UPDATE CONCLUIDO
                        return "Não foi possível atualizar o usuário. Por favor tente mais tarde!";
                    }
                    else
                    {
                        return "Não foi possível localizar o usuário, por favor confira o Nick e a senha.";
                    }
                }
                catch (Exception e)
                {
                    if (dr != null)
                        dr.Close();
                    return e.Message;
                }
            }
        }
    }
}