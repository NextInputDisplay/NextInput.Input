cd NextInput.Input
dotnet pack -c Release
cp ./bin/Release/NextInput.Input.*.nupkg /path/to/nuget/source
rm -rf ~/.nuget/packages/nextinput.input