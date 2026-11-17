# 01-prerequisites: Verify .NET 10 prerequisites and centralize package versions

Confirm the installed .NET SDK and check for SDK pinning before changing project targets. Introduce central package version management for the five SDK-style solution projects, moving only existing direct package versions and preserving their exact versions and project-specific settings. The assessment flags the test project's xunit package as deprecated but does not show a missing compatible version or a recommended replacement, so do not make an unrelated package upgrade. Reconcile any discrepancy between assessment package metadata and the current project files using the repository's actual declarations and restore state.

**Done when**: .NET 10 SDK availability and SDK pinning are verified; centralized package versions are in place without changing existing package versions; the solution restores successfully.
