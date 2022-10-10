FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
ARG VERSION
WORKDIR /app
RUN apk add clang gcc lld musl-dev build-base zlib-dev
COPY . ./
RUN dotnet publish --runtime linux-musl-x64 --configuration Release --output out -p:DebugType=none -p:GenerateDocumentationFile=false -p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/runtime-deps:7.0-alpine
WORKDIR /app
COPY --from=build /app/out/GitHubSettingsSync /app/
ENTRYPOINT ["/app/GitHubSettingsSync"]
