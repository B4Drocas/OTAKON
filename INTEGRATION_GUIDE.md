# 📋 Guia de Integração de Código - OTAKON

## Status Atual

✅ **Compilação bem-sucedida**  
✅ **Namespaces consolidados para `OTAKode`**  
✅ **Ficheiros duplicados removidos**  
✅ **Autenticação por cookies implementada**

---

## 🔧 Estrutura do Projeto

```
OTAKON/
├── Controllers/
│   ├── AccountController.cs       ✅ Autenticação (Login/Register/Dashboard/Logout)
│   ├── HomeController.cs          ✅ Página inicial
│   ├── InfoController.cs          ✅ Informações
│   ├── NavegacaoController.cs     ✅ Navegação
│   ├── ProfileController.cs       ✅ Perfil do usuário
│   ├── StoreController.cs         ✅ Loja/Mangas
│   └── LojaController.cs          ✅ Alternativa de Loja
├── Models/
│   ├── AccountViewModels.cs       ✅ ViewModels (Login/Register)
│   ├── User.cs                    ✅ Modelo de Utilizador
│   ├── Manga.cs                   ✅ Modelo de Manga
│   └── ErrorViewModel.cs          ✅ Erro de página
├── Data/
│   └── OtakonDbContext.cs         ✅ Contexto EF Core
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   ├── Register.cshtml
│   │   ├── Dashboard.cshtml
│   │   └── Profile.cshtml
│   ├── Home/
│   ├── Shared/
│   └── _ViewImports.cshtml        ✅ Namespace corrigido
├── Program.cs                      ✅ Configuração completa
└── appsettings.json               📝 Verificar connection string
```

---

## 🔐 Autenticação Implementada

### Sistema de Autenticação por Cookies
- **Tipo**: `CookieAuthenticationDefaults.AuthenticationScheme`
- **Duração**: 30 minutos (com sliding expiration)
- **Claims**: NameIdentifier, Name, Email, FullName, Role (Admin/User)
- **Banco de Dados**: SQL Server

### Endpoints de Autenticação
```
POST   /Account/Login        → Autenticar utilizador
GET    /Account/Dashboard    → Dashboard autenticado [Authorize]
GET    /Account/Logout       → Sair da sessão [Authorize]
GET    /Account/Register     → Formulário de registo
POST   /Account/Register     → Criar nova conta
```

### Validações Implementadas
```csharp
LoginViewModel:
- Username: Obrigatório
- Password: Obrigatório

RegisterViewModel:
- Username: Obrigatório
- Email: Obrigatório + validação de email
- Password: Obrigatório + 8-100 caracteres
- PasswordConfirm: Obrigatório + comparação com Password
- FullName: Opcional
```

---

## 📦 Dependências Configuradas

### NuGet Packages Necessários
```xml
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.AspNetCore.Authentication.Cookies
- BCrypt.Net-Next
```

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=OtakonDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=true;"
  }
}
```

---

## 🛠️ Como Integrar Código do Seu Amigo

### 1. **Se há conflitos de namespace**
   ```csharp
   ❌ namespace OTAKON
   ✅ namespace OTAKode
   ```

### 2. **Se há controllers duplicados**
   - Manter apenas a versão mais recente
   - Combinar funcionalidades se ambas têm valor
   - Remover ficheiros com sufixo "Cópia", "Copy", "v2", etc.

### 3. **Se há models duplicados**
   - Garantir que cada model existe apenas uma vez
   - Consolidar propriedades se necessário
   - Usar mesma `DbSet<T>` no `OtakonDbContext`

### 4. **Se há views duplicadas**
   - Remover pastas "Views - Cópia", "Views - Backup"
   - Manter apenas `Views/` principal
   - Actualizar `_ViewImports.cshtml` com namespace correto

### 5. **Merge via Git**
   ```powershell
   # Verificar branch actual
   git branch
   
   # Se necessário rebase com main
   git rebase main
   
   # Resolver conflitos
   git status
   git add .
   git commit -m "Merge: Integração de código"
   git push origin teste1
   ```

---

## ✅ Checklist de Integração

- [ ] Remover ficheiros duplicados ("*Cópia", "*Copy", "*v2")
- [ ] Consolidar namespaces para `OTAKode`
- [ ] Garantir única versão de cada controller
- [ ] Garantir única versão de cada model
- [ ] Garantir única versão de cada view
- [ ] Testar compilação: `dotnet build`
- [ ] Testar autenticação de utilizador
- [ ] Testar criação de nova conta
- [ ] Executar migrations se necessário: `dotnet ef database update`
- [ ] Fazer commit com mensagem clara

---

## 🚀 Comandos Úteis

```powershell
# Compilar
dotnet build

# Executar
dotnet run

# Migrations
dotnet ef migrations add NomeMigracao
dotnet ef database update

# Ver ficheiros duplicados
Get-ChildItem -Recurse | Where-Object {$_.Name -like "*Cópia*" -or $_.Name -like "*Copy*"}

# Git - Ver diferenças
git diff Controllers/
git diff Models/
git diff Views/
```

---

## 📝 Notas Importantes

1. **Cada ficheiro deve ter apenas UM namespace** - sem duplicatas
2. **Controllers, Models e Views devem estar no namespace `OTAKode`**
3. **Autenticação está funcional** - testes recomendados
4. **Session middleware está configurado** - compatível com cookies
5. **BCrypt está implementado** - passwords com hash seguro

---

**Status**: ✅ Pronto para integração  
**Última actualização**: $(date)  
**Branch**: teste1
