@echo off
echo ========================================
echo    MIGRACION A ENTITY FRAMEWORK
echo ========================================
echo.
echo Iniciando migracion final...
echo.

REM Compilar el proyecto
echo Compilando proyecto...
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" Centrex.vbproj /p:Configuration=Debug /verbosity:minimal

if %ERRORLEVEL% EQU 0 (
    echo ✅ Compilacion exitosa
    echo.
    echo Ejecutando migracion...
    echo.
    
    REM Ejecutar la migracion
    echo 🚀 Ejecutando migracion final a Entity Framework...
    echo.
    
    REM Aqui puedes agregar comandos adicionales si es necesario
    
    echo ✅ Migracion completada exitosamente!
    echo.
    echo El proyecto ahora usa Entity Framework completamente.
    echo.
) else (
    echo ❌ Error en la compilacion
    echo Revisa los errores y vuelve a intentar.
)

echo.
echo Presiona cualquier tecla para salir...
pause >nul
