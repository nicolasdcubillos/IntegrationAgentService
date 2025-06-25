@echo off
echo ===============================
echo Registrando COM...
echo ===============================

:: Ruta base del proyecto
set PROJECT_PATH=..\IntegrationAgentComLibrary

:: Ruta a regasm
set REGASM=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\regasm.exe

:: Registrar la DLL como COM
%REGASM% %PROJECT_PATH%\bin\Debug\IntegrationAgentComLibrary.dll /codebase /tlb

if errorlevel 1 (
    echo Error al registrar la DLL.
    pause
    exit /b 1
)

echo Listo. DLL compilada y registrada correctamente.
pause
