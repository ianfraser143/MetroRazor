# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: develop
- **Working Branch**: dotnet-version-upgrade
- **Pending Changes**: Committed before branch creation as `Save work before starting dotnet-version-upgrade`
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## Scope
- Upgrade applicable application/library/test projects and shared target framework settings to .NET 10.
- Preserve the web project's existing net10.0 target and unrelated project-specific configuration.
- Avoid unrelated edits.
- Do not make deployment changes; call out relevant deployment credential or configuration blockers if discovered.

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

### Project Structure
- Package Management: Central Package Management (CPM)

## Strategy
**Selected**: All-at-Once
**Rationale**: Five SDK-style projects target modern .NET with no API compatibility breaks reported; an atomic update avoids prolonged mismatch across project references.

### Execution Constraints
- Treat the framework and package reference management changes as one all-at-once upgrade, without dependency-tier phasing.
- Verify the .NET SDK and any global.json compatibility before editing project targets.
- Preserve the web project's existing net10.0 target and package versions while consolidating version declarations.
- Restore, build the full solution, and run tests after the changes.
- Fix build errors and warnings relevant to the updated solution; do not make deployment changes.
