ARG DOTNETVERSION=5.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNETVERSION}-buster-slim AS build-env
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNETVERSION}-buster-slim
# Create a group and user
ARG uid=1000
ARG gid=1000
RUN groupadd -g $gid appgroup && useradd -lm -u $uid -g $gid appuser
# Copy publish as our user
COPY --chown=appuser:appgroup --from=build-env /src/publish/ /app
USER appuser
WORKDIR /app
ENTRYPOINT ["dotnet", "permtest.dll"]