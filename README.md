# JMFWebAppUpdtDemo
Web API hospedada no Serviço de Aplicativos Azure, com acesso de modificação a base de dados do SQL Server hospedado em Máquina Virtual do Azure: 
https://jmfwebupdt2021.azurewebsites.net/

Documentação da API: https://jmfwebupdt2021.azurewebsites.net/Help

Criação de novo jogador:
POST: https://jmfwebupdt2021.azurewebsites.net/API/NewPlayer
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Novo Nick",
    "Password": "Nova Senha"
}

Atualização de um jogador:
PUT: https://jmfwebupdt2021.azurewebsites.net/API/UpdScores/42
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Rosana",
    "Password": "Senha",
        "NewStats": [
        10,
        5,
        3,
        10,
        5,
        3
    ]
}

Excluindo um jogador:
DELETE: https://jmfwebupdt2021.azurewebsites.net/API/UpdScores/42
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Rosana",
    "Password": "Senha",
    "DeleteID": "DJMF",
    "DeletePW": "DJMF"
}

Esta API faz inserções, atualizações e remoções da base de dados: https://github.com/JimKirk95/JMFWebAppUpdtDemo uma outra API é responsável por consultas gerais:
https://github.com/JimKirk95/JMFWebAppDemo

Obs: para consultar as informações de um jogador, use o PUT passando seis 0s em NewStats.

Solução desenvolvida no Microsoft Visual Studio Community 2019, Versão 16.9.1 Projeto Projeto baseado no modelo "Aplicativo Web ASP.NET (.NET Framework)" com C# Hospedado na conta gratuita do Azure. O SQL Server deve funcionar até 10 de abril de 2021.
