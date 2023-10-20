# Train Load Simulator
| Branch  | Build Status |
| ------------- | ------------- |
| main | [![Build Status](https://michalzeg.visualstudio.com/GitHub/_apis/build/status%2FCalculators%2Fmichalzeg.TrainLoad?branchName=main)](https://michalzeg.visualstudio.com/GitHub/_build/latest?definitionId=33&branchName=main) |


<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
<!-- ABOUT THE PROJECT -->
## About The Project
Simulation of train load moving accross the bridge. The simulation is performed using finite element anlysis with finite difference method to solve equation of motion. The simulation is written in C#.

![image](https://github.com/michalzeg/TrainLoad/assets/16364170/7c6fb107-c542-48a7-aed2-776b8ace7cab)

### Built With

* .NET
* Angular
* Bootstrap
* svg.js
* three.js

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Prerequisites

Before you start please make sure you have installed the following software
* Node.js
* .NET SDK

### Installation
Clone the repo
   ```sh
   git clone https://github.com/michalzeg/TrainLoad.git
   ```
Run the project using provided PowerShell script
   ```sh
   .\run.ps1
   ```
Open in your browser http://localhost:4200

OR use the provided docker image
   ```sh
   docker-compose -f .\build\docker-compose.yml up
   ```
and open in your browser http://localhost:5000
<!-- USAGE EXAMPLES -->
## Usage

You can see usage on the follwing animation

![trainload](https://github.com/michalzeg/TrainLoad/assets/16364170/b1f5e0d2-7d5b-42db-a997-7439d44fd352)

<!-- LICENSE -->
## License

Distributed under the MIT License.
