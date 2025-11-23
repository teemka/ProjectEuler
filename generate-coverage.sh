rm -rf Coverage
rm -rf ProjectEuler.Tests/bin/Release/net10.0/TestResults
dotnet run --project ProjectEuler.Tests -c Release --coverage --coverage-output-format xml
reportgenerator -reports:ProjectEuler.Tests/bin/Release/net10.0/TestResults/*.xml -targetdir:Coverage
start Coverage/index.html
