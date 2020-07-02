FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY Identity-build .

ENV ASPNETCORE_URLS=http://*:5501
CMD dotnet ITLab.Identity.STS.Identity.dll
