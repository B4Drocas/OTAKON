@echo off
REM Script de limpeza - Remove ficheiros duplicados e desnecessários

echo ===================================
echo Limpeza do Projeto OTAKON
echo ===================================

REM Remover pastas duplicadas
echo.
echo [1/4] Removendo pastas duplicadas...
rmdir /S /Q "Controllers - Copia" 2>nul
rmdir /S /Q "Models - Copia" 2>nul
rmdir /S /Q "Views - Copia" 2>nul
rmdir /S /Q "Data - Copia" 2>nul
echo ✓ Pastas duplicadas removidas

REM Remover ficheiros temporários
echo.
echo [2/4] Removendo ficheiros temporários...
del /S "*~" 2>nul
del /S "*.bak" 2>nul
echo ✓ Ficheiros temporários removidos

REM Limpar build artifacts
echo.
echo [3/4] Limpando build artifacts...
rmdir /S /Q "bin" 2>nul
rmdir /S /Q "obj" 2>nul
echo ✓ Build artifacts removidos

REM Verificar ficheiros restantes com "Cópia" ou "Copy"
echo.
echo [4/4] Verificando ficheiros restantes...
setlocal enabledelayedexpansion
set found=0
for /R . %%F in (*Copia* *Copy* *-v2*) do (
    if !found!==0 (
        echo.
        echo AVISO: Ficheiros com sufixo suspeito encontrados:
        set found=1
    )
    echo   - %%F
)

if !found!==0 (
    echo ✓ Nenhum ficheiro duplicado encontrado
)

echo.
echo ===================================
echo Limpeza concluída!
echo ===================================
echo.
echo Próximos passos:
echo  1. dotnet build
echo  2. dotnet run
echo ===================================
pause
