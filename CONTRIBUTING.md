# Contributing to [YourProjectName]

Thank you for considering contributing to [YourProjectName]! Your help is what makes this project great.

## How Can I Contribute?

### 🐛 Reporting Bugs

- Search [issues](../../issues) to see if your bug has already been reported.
- Open a new issue and include:
  - A clear title and description.
  - Steps to reproduce the bug.
  - Expected and actual results.
  - Screenshots or logs if helpful.

### ✨ Suggesting Enhancements

- Search [issues](../../issues) for similar suggestions.
- Open a new issue and describe your idea, why it would help, and any thoughts on implementation.

### 👩‍💻 Submitting Pull Requests

1. **Fork** the repository.
2. **Clone** your fork to your local machine.
3. **Create a branch** for your fix or feature:
    ```bash
    git checkout -b feature/my-feature
    ```
4. **Write clear, concise commit messages.**
5. **Write or update tests** as needed.
6. **Push** your branch to your fork:
    ```bash
    git push origin feature/my-feature
    ```
7. **Open a pull request** from your branch to the `main` branch here.
8. **Fill out the PR template** and link any related issues.

---

## Code Style

- Follow the [`.editorconfig`](../.editorconfig) and coding conventions used in this repository.
- Use clear, descriptive variable and function names.
- Keep methods short and focused.
- Write XML or Markdown documentation for public methods where appropriate.

## Running the Project Locally

1. Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.
2. In the `src/YourProject.Api` directory, run:
    ```bash
    dotnet run
    ```
3. Access the API at `https://localhost:5001` (or as configured).

## Running Tests

From the repository root:
```bash
dotnet test
