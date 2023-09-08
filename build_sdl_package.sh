cd NextInput.Input.SDL
dotnet pack -c Release
cp ./bin/Release/NextInput.Input.SDL.1.0.0.nupkg /path/to/nuget/source
rm -rf ~/.nuget/packages/nextinput.input.sdl