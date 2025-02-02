# C# Selenium WebDriver Testing Framework

This project is a robust and scalable **Selenium WebDriver** testing framework built using **C#**. It implements the **Page Object Model (POM)** design pattern, **Web Components**, and **Data Transfer Objects (DTOs)** to ensure modularity, maintainability, and reusability. The framework is designed to automate web application testing, providing a comprehensive solution for end-to-end testing.

## Features

- **Page Object Model (POM)**: Implements the POM design pattern to separate test logic from page-specific logic, enhancing maintainability and reusability.
- **Web Components**: Encapsulates reusable UI elements (e.g., buttons, forms, tables) into components for better modularity.
- **Data Transfer Objects (DTOs)**: Uses DTOs to represent and transfer data between layers of the framework, ensuring clean and structured data handling.
- **Data-Driven Testing**: Supports data-driven testing using external data sources like JSON, CSV, or Excel files.
- **Cross-Browser Testing**: Enables testing across multiple browsers (e.g., Chrome, Firefox, Edge) with easy configuration.
- **Reporting**: Generates detailed test execution reports for better visibility into test results.
- **Logging**: Integrated logging for better debugging and traceability.
- **CI/CD Integration**: Ready to be integrated into CI/CD pipelines for automated testing.

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET SDK**: Version 5.0 or higher.
- **IDE**: Visual Studio or JetBrains Rider.
- **Git**: To clone the repository.
- **WebDriver Executables**: Download the required WebDriver executables (e.g., `chromedriver`, `geckodriver`) and ensure they are added to your system's PATH.

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Moh88CS/SeleniumApplicationTesting-CSharp.git
   cd SeleniumApplicationTesting-CSharp
   dotnet restore
   dotnet test

## Reporting
NUnit generates detailed test execution reports, which can be viewed in your IDE or CI/CD pipeline. For enhanced reporting, you can integrate tools like Allure or ExtentReports.
