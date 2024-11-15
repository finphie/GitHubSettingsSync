FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0-noble-aot AS build
ARG VERSION
WORKDIR /source
COPY --link . .
RUN --mount=type=cache,target=/root/.nuget/packages \
    --mount=type=cache,target=/source/bin \
    --mount=type=cache,target=/source/obj \
    dotnet publish --runtime linux-x64 --output /app -p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/nightly/runtime-deps:9.0-noble-chiseled-aot
WORKDIR /app
COPY --link --from=build /app .
ENTRYPOINT ["/app/GitHubSettingsSync"]
