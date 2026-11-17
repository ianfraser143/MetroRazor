# 02-framework-upgrade: Target shared source projects to .NET 10

Update the shared source-layer target framework so the Domain, Application, Infrastructure, and Tests projects inherit `net10.0`. Preserve their SDK-style project files and all existing settings. Keep `src/Web/BlazorApp.Web.csproj` explicitly on `net10.0`; its project-specific settings and package versions remain unchanged.

**Done when**: All four previously net8.0 projects resolve to `net10.0`, the web project remains at `net10.0`, and no unrelated project configuration or package version changes are introduced.
