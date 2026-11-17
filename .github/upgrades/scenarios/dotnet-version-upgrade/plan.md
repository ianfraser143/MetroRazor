# .NET Version Upgrade Plan

## Overview

**Target**: Upgrade applicable MetroRazor application, library, and test projects to .NET 10 (`net10.0`).
**Scope**: Five SDK-style projects; four currently inherit `net8.0`, and the web project already targets `net10.0`.

### Selected Strategy
**All-At-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: Five SDK-style projects target modern .NET with no API compatibility breaks reported; an atomic update avoids prolonged mismatch across project references.

**Projects**: Libraries (Domain, Application, Infrastructure), tests, and the web application. The web project's existing `net10.0` target is retained.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | Five SDK-style projects target modern .NET with no API compatibility breaks reported; an atomic update avoids prolonged mismatch across project references. |
| Package Management | Central Package Management (CPM) | All five solution projects are SDK-style, the upgrade is modern .NET to modern .NET, and centralized package management is not already present. |

## Tasks

### 01-prerequisites: Verify .NET 10 prerequisites and centralize package versions

Confirm the installed .NET SDK and check for SDK pinning before changing project targets. Introduce central package version management for the five SDK-style solution projects, moving only existing direct package versions and preserving their exact versions and project-specific settings. The assessment flags the test project's xunit package as deprecated but does not show a missing compatible version or a recommended replacement, so do not make an unrelated package upgrade. Reconcile any discrepancy between assessment package metadata and the current project files using the repository's actual declarations and restore state.

**Done when**: .NET 10 SDK availability and SDK pinning are verified; centralized package versions are in place without changing existing package versions; the solution restores successfully.

### 02-framework-upgrade: Target shared source projects to .NET 10

Update the shared source-layer target framework so the Domain, Application, Infrastructure, and Tests projects inherit `net10.0`. Preserve their SDK-style project files and all existing settings. Keep `src/Web/BlazorApp.Web.csproj` explicitly on `net10.0`; its project-specific settings and package versions remain unchanged.

**Done when**: All four previously net8.0 projects resolve to `net10.0`, the web project remains at `net10.0`, and no unrelated project configuration or package version changes are introduced.

### 03-final-validation: Build and test the upgraded solution

Validate the complete solution after the framework and package-management changes. Resolve upgrade-related build errors and warnings, then run the test project. Report any remaining pre-existing or environment-related issue separately, and do not modify deployment configuration or credentials.

**Done when**: The full solution builds with no errors or warnings, tests pass, and relevant deployment credential/configuration concerns are explicitly reported without making deployment changes.
