cd NextInput.Input.SDL
dotnet pack -c Release
cp ./bin/Release/NextInput.Input.SDL.*.nupkg /path/to/nuget/source
rm -rf ~/.nuget/packages/nextinput.input.sdl