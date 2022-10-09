FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG VERSION=0.0.0
WORKDIR /app
COPY . ./
RUN dotnet publish --runtime linux-musl-x64 --configuration Release --output out -p:DebugType=none -p:GenerateDocumentationFile=false -p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/core/runtime-deps:7.0-alpine
COPY --from=build /app/out/GitHubSettingsSync .
ENTRYPOINT ["./GitHubSettingsSync"]
