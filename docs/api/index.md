<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![Codecov][codecov-shield]][codecov-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/karafra/twitter-stream">
    <img src="../img/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Twitter Stream </h3>

  <p align="center">
    Streaming twitter hashtag to browser
    <br />
    <a href="https://github.com/karafra/twitter-stream/wiki/"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/karafra/twitter-stream">View Demo</a>
    ·
    <a href="https://github.com/karafra/twitter-stream/issues">Report Bug</a>
    ·
    <a href="https://github.com/karafra/twitter-stream/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<div align="center">

[![Product Name Screen Shot][product-screenshot]](https://github.com/karafra/twitter-stream/)

</div>

Simple website project that allows convention hosts to interact with their audiences by streaming tweets with given hashtag to screen.
<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

* [.Net 6](https://dotnet.microsoft.com/en-us/)
* [Razor](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/)
* [Bootstrap](https://getbootstrap.com/)
* [JQuery](https://jquery.com/)
* [Asp.net Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
* [XUnit](https://xunit.net/)
* [Make](https://www.gnu.org/software/make/)
<p align="right">(<a href="#top">back to top</a>)</p>



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
   ```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Running this application is as simple as opening web browser. Literally ... :tada:

_For more examples, please refer to the [Documentation](https://karafra.github.io/twitter-stream/api/index.html)_

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Add Tests
  - [x] Connect to codecov
- [x] Add CI
- [x] Add Websocket communication between client and server
  - [x] Frontend javascript to receive messages 
  - [x] Backend to send tweets
- [ ] Improve UI
  - [ ] Add styles
  - [ ] Add effects when new tweet appears

See the [open issues](https://github.com/karafra/twitter-stream/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the Apache2.0. See [LICENSE](https://github.com/karafra/twitter-stream/blob/master/LICENSE) for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Karafro - [@karafro](https://twitter.com/karafro) - dariusKralovic@protonmail.com.com

Project Link: [https://github.com/karafra/twitter-stream](https://github.com/karafra/twitter-stream)

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/karafra/twitter-stream.svg?style=for-the-badge
[contributors-url]: https://github.com/karafra/twitter-stream/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/karafra/twitter-stream.svg?style=for-the-badge
[forks-url]: https://github.com/karafra/twitter-stream/network/members
[stars-shield]: https://img.shields.io/github/stars/karafra/twitter-stream.svg?style=for-the-badge
[stars-url]: https://github.com/karafra/twitter-stream/stargazers
[issues-shield]: https://img.shields.io/github/issues/karafra/twitter-stream.svg?style=for-the-badge
[issues-url]: https://github.com/karafra/twitter-stream/issues
[license-shield]: https://img.shields.io/github/license/karafra/twitter-stream.svg?style=for-the-badge
[license-url]: https://github.com/karafra/twitter-stream/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: ../img/screenshot.gif
[codecov-shield]: https://img.shields.io/codecov/c/gh/karafra/twitter-stream?style=for-the-badge&token=6dyM57ThGb
[codecov-url]: https://app.codecov.io/gh/karafra/twitter-stream/