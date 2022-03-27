<!-- GETTING STARTED -->
## Getting Started

For starting this application follow these steps

### Prerequisites

First verify that you have installed .Net by running the following command

  ```sh
  $ dotnet --version
  ```
If output is in format `6.0.xxx` then you have the correct version, if command results in error or you have outdated version of .net framework then follow installation steps mentioned [here](https://dotnet.microsoft.com/en-us/download).
### Installation

1. Get a Twitter API keys at [https://developer.twitter.com/](https://developer.twitter.com/en)
2. Clone the repo
   ```sh
   git clone https://github.com/karafra/twitter-stream.git
   ```
3. Install dependencies
   ```sh
   dotnet restore
   ```
4. Enter your API keys into *twitter* section of configuration file
   ```yml
    twitter:
      apiKey: YOUR_API_KEY
      apiSecret: YOUR_API_SECRET
      bearerToken: YOUR_BEARER_TOKEN
      hashtag: "#ukraine"
   ```
_For more information, look at [API reference](https://karafra.github.io/twitter-stream/api/index.html)_

<p align="right">(<a href="#top">back to top</a>)</p>