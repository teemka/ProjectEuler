Remove-Item -Recurse -Force Coverage -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force ProjectEuler.Tests/bin/Release/net10.0/TestResults -ErrorAction SilentlyContinue
dotnet run --project ProjectEuler.Tests -c Release --coverage --coverage-output-format xml
reportgenerator -reports:ProjectEuler.Tests/bin/Release/net10.0/TestResults/*.xml -targetdir:Coverage
Start-Process Coverage\index.html
