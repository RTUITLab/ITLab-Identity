FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY Admin-build .

ENV ASPNETCORE_URLS=http://*:5502
CMD dotnet ITLab.Identity.Admin.dll
