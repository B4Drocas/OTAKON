# 🔀 Guia Prático de Integração - OTAKON (teste1 → main)

## 📍 Situação Atual

**Branch**: `teste1`  
**Status**: Compilação ✅ | Código consolidado ✅ | Git sincronizado ✅  
**Próximo passo**: Merge com código do seu amigo

---

## 🎯 Passo 1: Verificar o Estado da Branch

```powershell
# Verificar em qual branch está
git branch

# Ver commits locais
git log --oneline -5

# Ver diferenças com main (se aplicável)
git diff main..teste1
```

---

## 📥 Passo 2: Integrar Código do Seu Amigo

### Opção A: Se o seu amigo fez push para uma branch
```powershell
# Buscar todas as branches remotas
git fetch origin

# Listar branches remotas
git branch -r

# Merge com a branch do seu amigo (exemplo: origin/amigo-branch)
git merge origin/amigo-branch

# Ou fazer rebase (mais limpo, sem merge commit)
git rebase origin/amigo-branch
```

### Opção B: Se o seu amigo enviou um PR
1. Ir para GitHub: https://github.com/B4Drocas/OTAKON/pulls
2. Encontrar o PR
3. Clicar "Merge pull request"
4. Depois fazer pull local:
```powershell
git pull origin teste1
```

### Opção C: Se o seu amigo enviou código por e-mail/ZIP
```powershell
# Colocar os ficheiros na pasta correcta
# Depois adicionar ao git
git add .
git status  # Verificar mudanças
git commit -m "Integração: Código do amigo - [descrição]"
```

---

## 🔍 Passo 3: Resolver Conflitos (Se Houver)

### Identificar conflitos
```powershell
git status
```

### Ver o ficheiro com conflito
```powershell
# Exemplo: Controllers\HomeController.cs
git diff Controllers\HomeController.cs
```

### Marcadores de conflito no código
```csharp
<<<<<<< HEAD
// Seu código
=======
// Código do seu amigo
>>>>>>> branch-amigo
```

### Resolver manualmente
1. Abrir o ficheiro no VS
2. Manter ambas as partes se necessário
3. Remover marcadores `<<<<`, `====`, `>>>>`

### Marcar como resolvido
```powershell
git add Controllers\HomeController.cs
git commit -m "Resolve: Conflito em HomeController"
```

---

## ✅ Passo 4: Validar a Integração

### Compilar o código
```powershell
dotnet clean
dotnet build
```

### Se compilar com sucesso
```powershell
# Ver o histórico do merge
git log --oneline -10

# Ver quem mudou o quê
git log --oneline --all --graph
```

### Se houver erros
```powershell
# Desfazer o merge (voltar atrás)
git merge --abort

# Ou desfazer um rebase
git rebase --abort

# Ou reverter um commit (se já foi feito commit)
git revert HEAD
```

---

## 📤 Passo 5: Fazer Push para o Repositório

### Depois de tudo compilar e funcionar
```powershell
# Verificar o que vai enviar
git log origin/teste1..HEAD

# Fazer push
git push origin teste1

# Verificar no GitHub se ficou correcto
```

---

## 🎯 Passo 6: Fazer PR/Merge para Main

### Via GitHub (recomendado)
1. Ir para https://github.com/B4Drocas/OTAKON
2. Clicar "New Pull Request"
3. Comparar `main` ← `teste1`
4. Clicar "Create Pull Request"
5. Descrever as mudanças
6. Clicar "Merge pull request"

### Via Terminal (alternativa)
```powershell
# Mudar para main
git checkout main

# Fazer pull para sincronizar
git pull origin main

# Fazer merge de teste1
git merge teste1

# Se tudo ok, fazer push
git push origin main
```

---

## 🛠️ Ferramentas Úteis no Conflito

### Ver diferenças em tempo real
```powershell
# Mostrar três versões (seu código, original, código do amigo)
git mergetool
```

### Aceitar a versão completa (seu código)
```powershell
git checkout --ours ficheiro.cs
git add ficheiro.cs
```

### Aceitar a versão completa (código do amigo)
```powershell
git checkout --theirs ficheiro.cs
git add ficheiro.cs
```

---

## 📋 Checklist de Integração

- [ ] Branch `teste1` sincronizada com remoto (`git pull origin teste1`)
- [ ] Código do amigo integrado (merge, rebase, ou arquivos copiados)
- [ ] Conflitos resolvidos (se houver)
- [ ] Código compila sem erros (`dotnet build`)
- [ ] Autenticação testada (login/register funcionando)
- [ ] Commit feito com mensagem clara
- [ ] Push enviado para `teste1`
- [ ] PR criada para `main` (ou merge direto via GitHub)
- [ ] Code review do amigo (opcional)
- [ ] Merge para `main` realizado
- [ ] Testes finais em `main`

---

## 🚨 Se der Problema

### Revert completo
```powershell
# Se fez um merge que deu errado
git reset --hard HEAD~1

# Se fez um rebase que deu errado
git rebase --abort
```

### Verificar histórico antes de fazer algo arriscado
```powershell
# Ver os últimos commits
git reflog

# Voltar para um commit específico
git reset --hard <hash-do-commit>
```

### Contactar o seu amigo
- Se há conflitos, perguntar qual versão manter
- Se há namespaces diferentes, decidir qual usar
- Se há duplicatas, decidir qual remover

---

## 💡 Dicas Finais

1. **Faça commits pequenos e com descrições claras**
   ```powershell
   git commit -m "Feature: Adicionar autenticação por cookies"
   ```

2. **Sempre teste depois de um merge**
   ```powershell
   dotnet build
   dotnet run
   ```

3. **Use branches para features separadas**
   ```powershell
   git checkout -b feature/nova-feature
   # Fazer mudanças
   git push origin feature/nova-feature
   # Criar PR no GitHub
   ```

4. **Mantenha `main` sempre funcional**
   - Só marge para `main` código que compila
   - Só marge para `main` código testado

5. **Comunique com o seu amigo**
   - Avisar antes de fazer mudanças grandes
   - Sincronizar branches regularmente
   - Code review antes de merge

---

## 📞 Precisa de Ajuda?

```powershell
# Ver ajuda de qualquer comando git
git help merge
git help rebase
git help cherry-pick

# Ou procurar a documentação online
# https://git-scm.com/doc
# https://github.com/git-tips/tips
```

---

**Última actualização**: 2026-01-20  
**Status**: Pronto para integração ✅
