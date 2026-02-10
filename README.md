# Onboarding Custommer - Client App

This is the client application for the Onboarding Custommer project.

## Setup Project

### Clone Repositories

```bash
git clone https://github.com/feri-irawansyah/Asp.NET-Core-Vue.git
```

Rename folder project nya dari Asp.NET-Core-Vue ke OnboardingClient misalnya. Atau biarin aja tidak masalah

### Install Dependencies

1. Ketik `Ctrl + Shift + P` untuk membuka comand palette
2. Ketikan `Run Task`
3. Pilih `Tasks: Run Task`
4. Pilih `setup` (Jangan Setup Punya VS Code, biasanya ada di baris ke dua)
5. Pilin `Continue whitout scanning the task output`

### Run Project

```bash
sh .tools/start.sh
```

### Build Project

```bash
sh .tools/publish.sh
```

## Project Structure

```bash
src
│
├── OnboardingClient
│   ├── node_modules    # Dependencies
│   ├── public  # Static files
│   ├── src     # Source code
│   │   ├── assets  # Style, Fonts, Assets
│   │   ├── components  # Components Vue
│   │   ├── router  # Route Configuration
│   │   ├── stores  # State Management
│   │   ├── views   # Views
│   │   ├── App.vue # Root Component
│   │   └── main.js # Main Entry Point
│   ├── .gitattributes # Git Attributes
│   ├── index.html # HTML Template Single Pake Application
│   ├── package.json # Dependencies
│   ├── README.md # Readme
│   └── vite.config.js # Vite Configuration
│
└── OnboardingClientApi
    ├── bin  # Build Output
    ├── Controllers # Controllers http request
    ├── Handlers # Http handler request & response
    ├── Interfaces # Interfaces / Ccontract Service
    ├── Middlewares # Middlewares
    ├── Properties # Configuration Web Api Running
    ├── Services # Services / Business Logic
    ├── appsettings.json # Configuration Application
    ├── OnboardingClient.Api.csproj # Project Configuration
    ├── OnboardingClient.Api.http # Http Configuration
    ├── Program.cs # Main Entry Point
    └── web.config # Web Configuration
```

## Other Documentation

- [Vue](https://vuejs.org/)
- [Vite](https://vitejs.dev/)
- [Volar](https://github.com/johnsoncodehk/volar)
- [Pinia](https://pinia.vuejs.org/)
- [ESLint](https://eslint.org/)
- [Prettier](https://prettier.io/)
- [OxLint](https://oxlint.com/)
- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Husky](https://github.com/typicode/husky)
- [Vue JS Adalah Frontend Library Yang Mudah Dan Menyenangkan](https://feri-irawansyah.my.id/catatan/frontend/vue-js-adalah-frontend-library-yang-mudah-dan-menyenangkan)

## Debugging

| Action      | Shortcut    |
| ----------- | ----------- |
| Start Debug | F5          |
| Stop        | Shift + F5  |
| Step Over   | F10         |
| Step Into   | F11         |
| Step Out    | Shift + F11 |
