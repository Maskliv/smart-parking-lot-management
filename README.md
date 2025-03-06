# Smart Parking Lot Management System (IoT)

This project is a simple backend API built with .NET that simulates a smart parking lot management system using IoT sensor data. It provides RESTful endpoints to track parking spot occupancy, manage parking spaces, and simulate sensor interactions.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)
- [Project Structure](#project-structure)
- [Usage](#usage)

## Overview

The Smart Parking Lot Management System API is designed to:

- **Detect** when a car enters or leaves a parking spot.
- **Track** the number of available and occupied parking spots.
- **Expose** a RESTful API that provides real-time status of parking spots.
- **Manage** parking spot data with basic CRUD operations.

## Features

- **Simulated IoT Sensor Integration:** Mimic sensor signals with API calls to mark spots as occupied or free.
- **Real-Time Status:** Retrieve the current status (occupied/free) of all parking spots.
- **CRUD Operations:** Add or remove parking spots as needed.
- **Test Coverage:** Comprehensive tests to validate API functionality using XUnit and mocking frameworks.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/maskliv/smart-parking-lot-management.git
   cd smart-parking-lot-management
   ```

1. **Restore Dependencies:**

   ```bash
   dotnet restore
   ```

1. **Build the Project:**

   ```bash
   dotnet build
   ```

## API Endpoints

1. **Mark Parking Spot as Occupied**
   - Endpoint: POST /api/parking-spots/{id}/occupy
   - Description: Marks a specific parking spot as occupied, needs a registered Device-Id.
   - Example:

   ```bash
   curl -X POST -H "Device-Id: 3fa85f64-5717-4562-b3fc-2c963f66afa6" http://localhost:5119/api/parking-spots/1/occupied 
   ```

1. **Mark Parking Spot as Free**
   - Endpoint: POST /api/parking-spots/{id}/free
   - Description: Marks a specific parking spot as free, needs a registered Device-Id.
   - Example:

   ```bash
   curl -X POST -H "Device-Id: 3fa85f64-5717-4562-b3fc-2c963f66afa6" http://localhost:5119/api/parking-spots/1/free
   ```

1. **Get All Parking Spots**
   - Endpoint: GET /api/parking-spots
   - Description: Retrieves all parking spots with its status.
   - Example:

   ```bash
   curl http://localhost:5119/api/parking-spots
   ```

1. **Add a New Parking Spot**
   - Endpoint: POST /api/parking-spots
   - Description: Adds a new parking spot.
   - Payload Example:

   ```json
   {
      "status": "free",
      "zone": "A",
      "positionId": "A-405"
   }
   ```

   - Example:

   ```bash
   curl -X POST -H "Content-Type: application/json" -d '{"status": "free","spotId": 0,"zone": "A","positionId": "A-405"}' http://localhost:5119/api/parking-spots
   ```

1. **Remove a Parking Spot**
   - Endpoint: DELETE /api/parking-spots/{id}
   - Description: Removes a parking spot from the system.
   - Example:

   ```bash
   curl -X DELETE http://localhost:5119/api/parking-spots/2
   ```

1. **Register a new device**
   - Endpoint: POST /api/parking-devices
   - Description: Adds a new a parking device.
   - Example:

   ```bash
   curl -X POST -H "Content-Type: application/json" -d '{"deviceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"}' http://localhost:5119/api/parking-devices
   ```

## Testing

The project includes tests to ensure the API behaves as expected.

Running Tests
Execute the following command to run the tests:

```bash
dotnet test
```

## Test Frameworks

NUnit: Used for unit and integration testing.

## Project Structure

```bash
smart-parking-lot-management/
│
├── SmartParkingLot.Api/         # Main API project
├── SmartParkingLot.Tests/       # Test project
├── README.md                    # This file
└── .gitignore
└── SmartParkingLot.sln          # Solution file
```

## Usage

After building the project, you can run the API by executing:

```bash
dotnet run --project ./SmartParkingLot.Api
```

By default, the API listens on <http://localhost:5119> (or as configured). Use your preferred REST client (e.g., Postman, cURL) to interact with the endpoints.
