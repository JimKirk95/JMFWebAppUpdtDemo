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
## Chamadas para a API:

### Chamada `POST` para criação de novo jogador:
Além do Nickname e da senha do novo jogador, o "_Caller_" (aplicativo ou página web) deve informar seu ID e sua senha.

Para testes pode usar "JMF" e "JMF", como no exemplo a seguir.

Enviar um `POST` para: `https://jmfwebupdt2021.azurewebsites.net/API/NewPlayer`

Com o seguinte `JSON body`:
```
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Github",
    "Password": "JimKirk95"
}

```
### Chamada `DELETE` para exclusão de um jogador:
Além do Nickname e da senha do jogador, o "_Caller_" (aplicativo ou página web) deve informar seu ID e sua senha, e ainda um ID e senha adicionais para Exclusão.

Além disso o `id` do `DELETE` deve ser `42`, ou a API vai recursar a chamada.

Para testes pode usar "JMF" e "JMF", e "DJMF" e "DJMF", como no exemplo a seguir.

Enviar um `DELETE` para: `https://jmfwebupdt2021.azurewebsites.net/API/UpdScores/42`

Com o seguinte `JSON body`: 
```
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Github",
    "Password": "JimKirk95",
    "DeleteID": "DJMF",
    "DeletePW": "DJMF"
}
```

### Chamada `PUT` para atualização dos dados de um jogador:
Além do Nickname e da senha do jogador, o "_Caller_" (aplicativo ou página web) deve informar seu ID e sua senha.

Além disso o `id` do `PUT` deve ser `42`, ou a API vai recursar a chamada.

Para testes pode usar "JMF" e "JMF", como no exemplo a seguir.

Enviar um `PUT` para: `https://jmfwebupdt2021.azurewebsites.net/API/UpdScores/42`

Com o seguinte `JSON body`:
```
{
    "CallerID": "JMF",
    "CallerPW": "JMF",
    "Nickname": "Github",
    "Password": "JimKirk95",
        "NewStats": [
        4,
        2,
        1,
        2,
        1
    ]
}
```

Obs: para consultar as informações de um jogador, use o `PUT` passando seis `0`s em `NewStats`.

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
