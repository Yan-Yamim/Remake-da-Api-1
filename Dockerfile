FROM mcr.microsoft.com/dotnet/sdk:10.0-preview-noble

RUN apt-get update && apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs && \
    rm -rf /var/lib/apt/lists/*

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app

RUN npm create vite@latest frontend -- --template react-ts

RUN cd frontend && npm install

EXPOSE 5000
EXPOSE 5173