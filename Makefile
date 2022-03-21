build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet run watch --project src/Presentation/Presentation.csproj
start:
	dotnet run --project src/Presentation/Presentation.csproj
test:
	dotnet test
coverage:
	dotnet-coverage collect "make test" --output-format cobertura