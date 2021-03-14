<p align="center">
  <a href="http://gg.gg/jpwork">
    <img src="https://drive.google.com/uc?export=view&id=1e59cCO6e4Uu1oeO0YFUYwV58rVM_ABMQ">
  </a>
</p>
<h1 align="center">JMFWebAppUpdtDemo</h1>
<!---🗃️🌍 🌎🌎 📝 🗃️  🌏
<img src="https://simpleicons.org/icons/csharp.svg" width="20px;" />
---> 

## Web API desenvolvida em C# com acesso de inclusão, atualização e exclusão a SQL Server 
Uma versão está hospedada no Serviço de Aplicativos Azure, com acesso a uma base de dados SQL Server hospedada em Máquina Virtual do Azure: https://jmfwebupdt2021.azurewebsites.net/
Documentação da API: https://jmfwebupdt2021.azurewebsites.net/Help

---

## Chamadas `GET` da API:
Jogadores com mais vitórias no total 🥇🥈🥉 ([experimente aqui](https://jmfwebapi2021.azurewebsites.net/API/TopWinners "GET TopWinners")):
```
https://jmfwebapi2021.azurewebsites.net/API/TopWinners
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



```
Jogadores com mais jogos no total ([experimente aqui](https://jmfwebapi2021.azurewebsites.net/API/TopPlayers "GET TopPlayers")): 
```
https://jmfwebapi2021.azurewebsites.net/API/TopPlayers
```
Jogadores com mais vitórias na semana 🥇🥈🥉 ([experimente aqui](https://jmfwebapi2021.azurewebsites.net/API/WeekWinners "GET WeekWinners")):
```
https://jmfwebapi2021.azurewebsites.net/API/WeekWinners
```
Jogadores com mais jogos na semana ([experimente aqui](https://jmfwebapi2021.azurewebsites.net/API/WeekPlayers "GET WeekPlayers")):
```
https://jmfwebapi2021.azurewebsites.net/API/WeekPlayers
```
Passando um número de 1 a 3 em qualquer uma dessas chamadas, apenas o jogador nessa colocação é retornado.
Por exemplo ([experimente aqui](https://jmfwebapi2021.azurewebsites.net/API/WeekWinners/2 "GET 2nd WeekWinner")):
```
https://jmfwebapi2021.azurewebsites.net/API/WeekWinners/2
```
Traz o segundo jogador 🥈 com mais vitórias na semana.

Obs: para consultar as informações de um jogador, use o PUT passando seis 0s em NewStats.

---
Esta API faz inserções, atualizações e remoções da base de dados. Uma outra API é responsável por consultas públicas:

https://github.com/JimKirk95/JMFWebAppDemo


- 👀 Solução desenvolvida no Microsoft Visual Studio Community 2019, Versão 16.9.1
- 👀 Projeto baseado no modelo "Aplicativo Web ASP.NET (.NET Framework)" com C#
- 👀 Hospedado na conta gratuita do Azure. O SQL Server deve funcionar até 10 de abril de 2021.

---

<!---
## Autor
<a href="http://gg.gg/jpwork">
 <img src="https://drive.google.com/uc?export=view&id=17_6ZWPP0DJx4fiLnO4EiWNFaNRaB2Abp" width="100px;" alt=""/>
 <br />
 <sub><b>Jackson Matsuura</b></sub></a>
 <br />
---> 
## Autor [![Github Badge](https://img.shields.io/badge/-Github/JimKirk95-000?style=flat-square&logo=Github&logoColor=white&link=https://github.com/JimKirk95)](https://github.com/JimKirk95) [![Linkedin Badge](https://img.shields.io/badge/-LinkedIn/jacksonmatsuura-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/jacksonmatsuura/)](https://www.linkedin.com/in/jacksonmatsuura/) [![Gmail Badge](https://img.shields.io/badge/-jackson.matsuura@Gmail-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:seu_emjackson.matsuura@gmail.comail)](mailto:jackson.matsuura@gmail.com)
<!---
[![Whatsapp Badge](https://img.shields.io/badge/-Whatsapp-4CA143?style=flat-square&labelColor=4CA143&logo=whatsapp&logoColor=white&link=https://api.whatsapp.com/send?phone=seu_telefone_55+12+981082413&text=Hello!)](https://api.whatsapp.com/send?phone=seu_telefone_55+12+981082413&text=Hello!)
--->

---
## 📝 Licença [MIT](./LICENSE).
