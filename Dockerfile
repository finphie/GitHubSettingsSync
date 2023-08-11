FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build
ARG VERSION
WORKDIR /app
RUN apk add clang gcc lld musl-dev build-base zlib-dev
COPY . ./
RUN dotnet publish --configuration Release --runtime linux-musl-x64 --output out -p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-preview-alpine
WORKDIR /app
COPY --from=build /app/out/GitHubSettingsSync /app/
ENTRYPOINT ["/app/GitHubSettingsSync"]
