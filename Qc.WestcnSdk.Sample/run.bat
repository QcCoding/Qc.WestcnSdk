taskkill /F /T /FI "WINDOWTITLE eq Qc.WestcnSdk.Sample" /IM dotnet.exe
start "Qc.WestcnSdk.Sample" dotnet run
exit