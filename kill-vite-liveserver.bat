@echo off
set PORT_VITE=5173
set PORT_LIVE_SERVER=5500

for /f "tokens=5" %%P in ('netstat -ano ^| findstr :%PORT_VITE%') do (
    echo Mating process with PID %%P on port %PORT_VITE%
    taskkill /F /PID %%P
)

for /f "tokens=5" %%P in ('netstat -ano ^| findstr :%PORT_LIVE_SERVER%') do (
    echo Mating process with PID %%P on port %PORT_LIVE_SERVER%
    taskkill /F /PID %%P
)

echo Done.