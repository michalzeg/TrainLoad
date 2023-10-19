Set-Location ./src/TrainLoad.Web/TrainLoadClientApp
npm install
Set-Location ../

# Start the .NET application using dotnet run
Start-Process -FilePath "cmd" -ArgumentList "/c", "dotnet run"

# Start the Angular application using ng serve
Start-Process -FilePath "cmd" -ArgumentList "/c", "cd ./TrainLoadClientApp && ng serve"
