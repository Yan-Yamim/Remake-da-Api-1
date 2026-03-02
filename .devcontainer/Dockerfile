FROM mcr.microsoft.com/dotnet/sdk:10.0-preview-noble

RUN curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app
EXPOSE 5000
EXPOSE 5173