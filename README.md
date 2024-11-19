# Modelagem de Dominios Ricos - Desenvolvedor.io

www.desenvolvedor.io
 
 ![image](https://github.com/user-attachments/assets/7c8040a6-ef35-4297-b630-32846b1ec807)


### Docker e Entity Framework

```bash
 docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server

 dotnet tool install --global dotnet-ef
```


### Connection Stringo
- Server=localhost;Database=master;User Id=sa;Password=Your_password123;

### Na pasta raiz

```bash
PS C:\Users\PatrickSouza\Desktop\Courses\Desenvolvedor.io\ArquiteturaDeSoftware\ModelandoDominiosRicos>
```

```bash
dotnet ef migrations add AjusteDecimalParaValor -p .\NerdStore.Catalogo.Data\NerdStore.Catalogo.Data.csproj -s .\NerdStore.Catalogo.API\NerdStore.Catalogo.API.csproj
```

- na API tem que ser instalado o Microsoft.EntityFrameworkCore.Design
  
```bash
dotnet ef database update -p .\NerdStore.Catalogo.Data\NerdStore.Catalogo.Data.csproj -s .\NerdStore.Catalogo.API\NerdStore.Catalogo.API.csproj
```

* No projeto da Api (camada de apresentação) Deve ter o design Entity framework

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=SeuBancoDeDados;User Id=sa;Password=SUASENHA;"
  }
}
```

### Remover Migration
dotnet ef migrations remove -p .\NerdStore.Catalogo.Data.csproj -s .\NerdStore.Catalogo.API\NerdStore.Catalogo.API.csproj


### Docker Commands
```bash
docker start <nome-do-conteiner>
docker inspect <nome-do-conteiner>
docker restart <nome-do-conteiner>
```
