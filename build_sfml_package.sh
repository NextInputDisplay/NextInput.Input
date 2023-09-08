cd NextInput.Input.SFML
dotnet pack -c Release
cp ./bin/Release/NextInput.Input.SFML.*.nupkg /path/to/nuget/source
rm -rf ~/.nuget/packages/nextinput.input.sfml