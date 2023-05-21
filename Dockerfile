FROM mcr.microsoft.com/dotnet/sdk:6.0.408-focal-amd64
RUN mkdir sample-cs-api
WORKDIR /sample-cs-api
RUN dotnet new webapi --use-program-main
RUN dotnet add package ErrorOr --version 1.2.1
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
COPY . /sample-cs-api/
CMD [ "dotnet", "run", "Program.cs" ]