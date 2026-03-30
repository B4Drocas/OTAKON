# Script de limpeza - Remove ficheiros duplicados e desnecessários
# Uso: .\cleanup.ps1

Write-Host "===================================" -ForegroundColor Cyan
Write-Host "Limpeza do Projeto OTAKON" -ForegroundColor Cyan
Write-Host "===================================" -ForegroundColor Cyan

# Remover pastas duplicadas
Write-Host "`n[1/4] Removendo pastas duplicadas..." -ForegroundColor Yellow
$pastas = @("Controllers - Cópia", "Models - Cópia", "Views - Cópia", "Data - Cópia")
foreach ($pasta in $pastas) {
    if (Test-Path $pasta) {
        Remove-Item -Path $pasta -Recurse -Force -ErrorAction SilentlyContinue
        Write-Host "  ✓ Removida: $pasta" -ForegroundColor Green
    }
}

# Remover ficheiros temporários
Write-Host "`n[2/4] Removendo ficheiros temporários..." -ForegroundColor Yellow
Get-ChildItem -Path . -Recurse -Include "*~", "*.bak", "*.tmp" -ErrorAction SilentlyContinue | 
    ForEach-Object {
        Remove-Item $_.FullName -Force -ErrorAction SilentlyContinue
        Write-Host "  ✓ Removido: $($_.Name)" -ForegroundColor Green
    }

# Limpar build artifacts
Write-Host "`n[3/4] Limpando build artifacts..." -ForegroundColor Yellow
$buildFolders = @("bin", "obj", ".vs")
foreach ($pasta in $buildFolders) {
    if (Test-Path $pasta) {
        Remove-Item -Path $pasta -Recurse -Force -ErrorAction SilentlyContinue
        Write-Host "  ✓ Removida: $pasta" -ForegroundColor Green
    }
}

# Verificar ficheiros restantes com "Cópia" ou "Copy"
Write-Host "`n[4/4] Verificando ficheiros restantes..." -ForegroundColor Yellow
$duplicados = Get-ChildItem -Path . -Recurse -ErrorAction SilentlyContinue | 
    Where-Object { $_.Name -like "*Cópia*" -or $_.Name -like "*Copy*" -or $_.Name -like "*v2*" }

if ($duplicados) {
    Write-Host "AVISO: Ficheiros com sufixo suspeito encontrados:" -ForegroundColor Red
    $duplicados | ForEach-Object {
        Write-Host "  - $($_.FullName)" -ForegroundColor Red
    }
} else {
    Write-Host "  ✓ Nenhum ficheiro duplicado encontrado" -ForegroundColor Green
}

Write-Host "`n===================================" -ForegroundColor Cyan
Write-Host "Limpeza concluída!" -ForegroundColor Green
Write-Host "===================================" -ForegroundColor Cyan

Write-Host "`nPróximos passos:" -ForegroundColor Yellow
Write-Host "  1. dotnet build" -ForegroundColor White
Write-Host "  2. dotnet run" -ForegroundColor White
Write-Host "===================================" -ForegroundColor Cyan
