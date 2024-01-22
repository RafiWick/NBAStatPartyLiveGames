# NBAStatPartyLiveGames
**Overview**: NBAStatPartyLiveGames is a console application that periodically retrieves play-by-play data from the Sportradar NBA API trial version.
The application then publishes this data in the form of Redis streams so that it can be accessed by the NBAStatParty web application.

## Getting Started
### Prerequisites
* Sportradar NBA trial key
* Redis Cloud instance

### Set up
1. Make a clone of this repo and open it in Visual Studio.
2. Set the user environment variables:
   * "NBA_SPORTRADAR_API_KEY" - the API key for your application.
   * "REDIS_ENDPOINT" - The endpoint of your Redis instance.
   * "REDIS_PASSWORD" - The password for your Redis instance.
  
### Operation
Follow the instructions in the console to enter the delay between each update.
Be aware of the limitations of the trial API key; these limitations are that the minimum delay allowed is one second and that you can only make 1000 API calls per month.
At the minimum dalay this app can be ran for ~15 minutes total per month.
The application makes one call per live game so at a delay of 1 minute while there are 5 ongoing games, the app will make 5 calls per minute.
To run constantly a delay of around half an hour (4-5 calls per game) is needed to not exceed API call allowence.

View the play-by-play data with [NBAStatParty](https://github.com/RafiWick/NBAStatParty)
