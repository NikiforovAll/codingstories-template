FROM mcr.microsoft.com/dotnet/sdk:5.0 AS sdk
# To use the debug build configuration pass --build-arg PERSONAL_ACCESS_TOKEN=<PAT>

ARG PERSONAL_ACCESS_TOKEN=Release
ARG TEMPLATE_VERSION=*
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true

WORKDIR /out

RUN dotnet nuget add source https://nuget.pkg.github.com/nikiforovall/index.json -n github -u nikiforovall -p $PERSONAL_ACCESS_TOKEN --store-password-in-clear-text

RUN dotnet new --nuget-source https://nuget.pkg.github.com/nikiforovall/index.json --install Epam.CodingStories.Template::$TEMPLATE_VERSION

ENTRYPOINT ["dotnet", "new"]
