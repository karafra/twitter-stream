FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

LABEL name="TweetStream"

LABEL maintainer="Karafra"

LABEL author="Karafra"

LABEL description="Streams tweets with given hashtag to webbrowser"

WORKDIR /app

COPY . ./

RUN apt-get update && apt-get install make

RUN make restore

RUN make publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS=http://+:5000  

EXPOSE 5000

ENTRYPOINT ["dotnet", "Presentation.dll"]
