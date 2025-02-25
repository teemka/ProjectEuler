rm -rf Coverage
rm -rf ProjectEuler.Tests/TestResults
dotnet test -v normal -c Release --collect:"XPlat Code Coverage"
reportgenerator -reports:ProjectEuler.Tests/TestResults/**/coverage.cobertura.xml -targetdir:Coverage
start Coverage/index.html
