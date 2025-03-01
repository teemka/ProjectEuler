Remove-Item -Recurse -Force Coverage -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force ProjectEuler.Tests/TestResults -ErrorAction SilentlyContinue
dotnet test -v normal -c Release --collect:"XPlat Code Coverage"
reportgenerator -reports:ProjectEuler.Tests/TestResults/**/coverage.cobertura.xml -targetdir:Coverage
Start-Process Coverage\index.html
