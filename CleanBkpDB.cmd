@echo off
ForFiles /p "Z:\_BaseSQL" /s /d -10 /c "cmd /c del /q @file"
ForFiles /p "D:\Onedrive\Centrex 2.0\bin\Debug\SQL\BKP" /s /d -10 /c "cmd /c del /q @file"
