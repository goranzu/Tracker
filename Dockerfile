# Stage 1: Build the React application using a Node.js image
FROM node:20 AS build-node
WORKDIR /app/react-client

# Copy and install the React application dependencies
COPY src/react-client/package.json src/react-client/package-lock.json* ./
RUN npm install

# Build the React application
COPY src/react-client/ .
RUN npm run build

# Stage 2: Build the .NET application using the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the .NET project files and restore the dependencies
COPY src/Tracker.Api/Tracker.Api.csproj src/Tracker.Api/
RUN dotnet restore src/Tracker.Api/Tracker.Api.csproj

# Copy the .NET source code and the React build
COPY src/Tracker.Api/ src/Tracker.Api/
COPY --from=build-node /app/react-client/dist src/Tracker.Api/wwwroot

# Publish the .NET application
RUN dotnet publish src/Tracker.Api/Tracker.Api.csproj -c Release -o out

# Stage 3: Build the runtime image using the .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Tracker.Api.dll"]