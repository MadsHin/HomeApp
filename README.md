# HomeApp

A self-hosted home management web application built with .NET 10 and Blazor Server. Personal learning project covering Clean Architecture, CQRS, and EF Core.

## Features
g
- **Dashboard** — overview of active projects, upcoming tasks, lent/borrowed tools, and expense summary with period and scope filters
- **Home Projects** — track renovation and home improvement projects with status, budget, timeline events, materials, tools, expenses, contacts, notes, and photos
- **Household Tasks** — recurring and one-off tasks with due dates, recurrence, and family member assignment
- **Materials** — global inventory with stock levels; per-project material planning with coverage indicators; shopping list of understocked items
- **Tools** — global tool inventory with ownership status (Owned, Lent Out, Borrowed, Rented); per-project tool assignment
- **Family Members** — household member registry used for task assignment
- **Contacts** — tradespeople and other contacts linked to projects
- **Gallery** — photo browser across all projects

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | Blazor Server  (.NET 10) + MudBlazor 9.5 |
| Application | MediatR 14 (CQRS) |
| Persistence | EF Core 10 + Npgsql (PostgreSQL 16) |
| Icons | MudBlazor Material Icons + Font Awesome Free 6.7 |

## Architecture

Clean Architecture with four projects:

```
HomeApp.Domain          — entities and enums
HomeApp.Application     — CQRS commands/queries via MediatR, IAppDbContext interface
HomeApp.Infrastructure  — EF Core DbContext, migrations
HomeApp.Web             — Blazor Server pages, dialogs, shared components
```

## Getting Started

**Prerequisites:** .NET 10 SDK, Docker

**1. Start the database**

```bash
docker compose up -d
```

**2. Configure the connection string**

```bash
cd src/HomeApp.Web
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=homeapp;Username=postgres;Password=postgres"
```

**3. Apply migrations**

```bash
cd src/HomeApp.Web
dotnet ef database update
```

**4. Run**

```bash
dotnet run --project src/HomeApp.Web
```

The app will be available at `https://localhost:5001`.
