# **SmartVars - Variable Management API**

Overview

SmartVars is an API designed for dynamic variable management using .NET 6, following Domain-Driven Design (DDD) principles. It allows users to define, store, retrieve, update, and receive notifications on variable changes. The project uses an in-memory database for seamless testing without requiring prior configuration.

Additionally, SendGrid is integrated to send email notifications whenever a new variable is created or an existing one is updated, ensuring subscribers are always informed of changes.

**Features**
- Define and store variables with unique identifiers, types, and default values.
- Retrieve all variables or specific ones by ID.
- Update variable values with type validation.
- Notify subscribers via SendGrid email notifications when variables are created or updated, including old and new values.
- Handle scenarios where subscribers are offline during changes.
- Lightweight and scalable architecture designed for easy extension.

**Technology Stack**
- Visual Studio 2022 - Development environment.
- .NET 6 - Backend framework.
- ASP.NET Web API - Exposes endpoints for variable management.
- EFCore - ORM for database interaction.
- Microsoft.EntityFrameworkCore.InMemory - In-memory database for testing without prior setup. A script is provided for persistent database configuration if needed.
- Swagger - API documentation and local testing.
- FluentValidation 11.11.0 - Validates data for consistent application behavior.
- SendGrid - Sends email notifications on variable changes to subscribed users.


# **API Endpoints**


# **Create Variable**

**POST /api/APISmartVars**

Description: Create a new variable. Triggers an email notification via SendGrid.

Request Body: BuildingVarsViewModel

Response: 200 OK (success) or 400 Bad Request (failure)




#  **Retrieve All Variables**

**GET /api/APISmartVars**

Description: Retrieve all stored variables.

Response: 200 OK or 400 Bad Request




#  **Retrieve Variable by ID**

**GET /api/APISmartVars/{id}**

Description: Retrieve a specific variable by its ID.

Response: 200 OK or 400 Bad Request




# **Update Variable**

**PUT /api/APISmartVars/{id}**

Description: Update an existing variable's details. Triggers an email notification via SendGrid.

Request Body: BuildingVarsViewModel

Response: 200 OK or 400 Bad Request

# **Project Management**

 - We use Trello for organizing tasks, divided into:
 - Backlog: Ideas and pending features.
 - To Do: Ready tasks.
 - In Progress: Ongoing development.
 - Review: Code under review.
 - Done: Completed tasks.

#  **Getting Started**

**Clone the repository**
```
git clone https://github.com/yourusername/SmartVars.git
```
Open with Visual Studio 2022 and restore dependencies.

Run the project - Swagger UI will open for testing endpoints locally.



### AppSettings Configuration


The `appsettings.json` file should follow this configuration pattern. For security reasons, sensitive data such as API keys have been removed from the repository:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MyDataMemory": "SmartVars_Data"
  },
  "SendGrid": {
    "ApiKey": "<YOUR_SENDGRID_API_KEY>"
  },
  "Email": {
    "EmailFrom": "<YOUR_EMAIL_ADDRESS>"
  }
}
```

> ⚠️ **Note:** Replace `<YOUR_SENDGRID_API_KEY>` and `<YOUR_EMAIL_ADDRESS>` with your actual SendGrid API key and email address before running the application.
> For more information on how to create your API key, follow the documentation link: [documentation link](https://www.twilio.com/docs/sendgrid/api-reference)

**Contributing**

Contributions are welcome! Please:

Fork the repository.

Create a feature branch (git checkout -b feature-name).

Commit changes (git commit -m 'Add feature').

Push to the branch (git push origin feature-name).

Open a pull request.

Contact

For questions or suggestions, feel free to reach out through the repository's issue tracker.
