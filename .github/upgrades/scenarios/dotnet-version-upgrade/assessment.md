# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v10.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
  - [Binding Redirect Configuration](#binding-redirect-configuration)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [src\Application\BlazorApp.Application\BlazorApp.Application.csproj](#srcapplicationblazorappapplicationblazorappapplicationcsproj)
  - [src\Domain\BlazorApp.Domain\BlazorApp.Domain.csproj](#srcdomainblazorappdomainblazorappdomaincsproj)
  - [src\Infrastructure\BlazorApp.Infrastructure\BlazorApp.Infrastructure.csproj](#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj)
  - [src\Tests\BlazorApp.Tests\BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj)
  - [src\Web\BlazorApp.Web.csproj](#srcwebblazorappwebcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 5 | 4 require upgrade |
| Total NuGet Packages | 21 | 1 need upgrade |
| Total Code Files | 17 |  |
| Total Code Files with Incidents | 4 |  |
| Total Lines of Code | 538 |  |
| Total Number of Issues | 5 |  |
| Estimated LOC to modify | 0+ | at least 0.0% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Binding Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :---: | :--- |
| [src\Application\BlazorApp.Application\BlazorApp.Application.csproj](#srcapplicationblazorappapplicationblazorappapplicationcsproj) | net8.0 | 🟢 Low | 0 | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [src\Domain\BlazorApp.Domain\BlazorApp.Domain.csproj](#srcdomainblazorappdomainblazorappdomaincsproj) | net8.0 | 🟢 Low | 0 | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [src\Infrastructure\BlazorApp.Infrastructure\BlazorApp.Infrastructure.csproj](#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj) | net8.0 | 🟢 Low | 0 | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [src\Tests\BlazorApp.Tests\BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | net8.0 | 🟢 Low | 1 | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [src\Web\BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | net10.0 | ✅ None | 0 | 0 | 0 |  | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 20 | 95.2% |
| ⚠️ Incompatible | 1 | 4.8% |
| 🔄 Upgrade Recommended | 0 | 0.0% |
| ***Total NuGet Packages*** | ***21*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 56 |  |
| ***Total APIs Analyzed*** | ***56*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| DnsClient | 1.6.1 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| Microsoft.AspNetCore.App.Internal.Assets | 10.0.14 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| Microsoft.CodeCoverage | 17.11.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| Microsoft.NET.Test.Sdk | 17.11.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| Microsoft.TestPlatform.ObjectModel | 17.11.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| Microsoft.TestPlatform.TestHost | 17.11.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| MongoDB.Bson | 3.4.2 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| MongoDB.Driver | 3.4.2 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| Newtonsoft.Json | 13.0.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| SharpCompress | 0.30.1 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| Snappier | 1.0.0 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |
| System.Reflection.Metadata | 1.6.0 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit | 2.8.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ⚠️NuGet package is deprecated |
| xunit.abstractions | 2.0.3 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.analyzers | 1.14.0 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.assert | 2.8.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.core | 2.8.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.extensibility.core | 2.8.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.extensibility.execution | 2.8.1 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| xunit.runner.visualstudio | 2.8.0 |  | [BlazorApp.Tests.csproj](#srctestsblazorapptestsblazorapptestscsproj) | ✅Compatible |
| ZstdSharp.Port | 0.7.3 |  | [BlazorApp.Web.csproj](#srcwebblazorappwebcsproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
    P2["<b>📦&nbsp;BlazorApp.Domain.csproj</b><br/><small>net8.0</small>"]
    P3["<b>📦&nbsp;BlazorApp.Infrastructure.csproj</b><br/><small>net8.0</small>"]
    P4["<b>📦&nbsp;BlazorApp.Web.csproj</b><br/><small>net10.0</small>"]
    P5["<b>📦&nbsp;BlazorApp.Tests.csproj</b><br/><small>net8.0</small>"]
    P1 --> P2
    P1 --> P3
    P3 --> P2
    P4 --> P1
    P5 --> P2
    P5 --> P1
    P5 --> P3
    click P1 "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
    click P2 "#srcdomainblazorappdomainblazorappdomaincsproj"
    click P3 "#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"
    click P4 "#srcwebblazorappwebcsproj"
    click P5 "#srctestsblazorapptestsblazorapptestscsproj"

```

## Project Details

<a id="srcapplicationblazorappapplicationblazorappapplicationcsproj"></a>
### src\Application\BlazorApp.Application\BlazorApp.Application.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 2
- **Dependants**: 2
- **Number of Files**: 2
- **Number of Files with Incidents**: 1
- **Lines of Code**: 19
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (2)"]
        P4["<b>📦&nbsp;BlazorApp.Web.csproj</b><br/><small>net10.0</small>"]
        P5["<b>📦&nbsp;BlazorApp.Tests.csproj</b><br/><small>net8.0</small>"]
        click P4 "#srcwebblazorappwebcsproj"
        click P5 "#srctestsblazorapptestsblazorapptestscsproj"
    end
    subgraph current["BlazorApp.Application.csproj"]
        MAIN["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
    end
    subgraph downstream["Dependencies (2"]
        P2["<b>📦&nbsp;BlazorApp.Domain.csproj</b><br/><small>net8.0</small>"]
        P3["<b>📦&nbsp;BlazorApp.Infrastructure.csproj</b><br/><small>net8.0</small>"]
        click P2 "#srcdomainblazorappdomainblazorappdomaincsproj"
        click P3 "#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"
    end
    P4 --> MAIN
    P5 --> MAIN
    MAIN --> P2
    MAIN --> P3

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 11 |  |
| ***Total APIs Analyzed*** | ***11*** |  |

<a id="srcdomainblazorappdomainblazorappdomaincsproj"></a>
### src\Domain\BlazorApp.Domain\BlazorApp.Domain.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 3
- **Number of Files**: 2
- **Number of Files with Incidents**: 1
- **Lines of Code**: 16
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (3)"]
        P1["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
        P3["<b>📦&nbsp;BlazorApp.Infrastructure.csproj</b><br/><small>net8.0</small>"]
        P5["<b>📦&nbsp;BlazorApp.Tests.csproj</b><br/><small>net8.0</small>"]
        click P1 "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
        click P3 "#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"
        click P5 "#srctestsblazorapptestsblazorapptestscsproj"
    end
    subgraph current["BlazorApp.Domain.csproj"]
        MAIN["<b>📦&nbsp;BlazorApp.Domain.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#srcdomainblazorappdomainblazorappdomaincsproj"
    end
    P1 --> MAIN
    P3 --> MAIN
    P5 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 15 |  |
| ***Total APIs Analyzed*** | ***15*** |  |

<a id="srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"></a>
### src\Infrastructure\BlazorApp.Infrastructure\BlazorApp.Infrastructure.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 1
- **Dependants**: 2
- **Number of Files**: 2
- **Number of Files with Incidents**: 1
- **Lines of Code**: 45
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (2)"]
        P1["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
        P5["<b>📦&nbsp;BlazorApp.Tests.csproj</b><br/><small>net8.0</small>"]
        click P1 "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
        click P5 "#srctestsblazorapptestsblazorapptestscsproj"
    end
    subgraph current["BlazorApp.Infrastructure.csproj"]
        MAIN["<b>📦&nbsp;BlazorApp.Infrastructure.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"
    end
    subgraph downstream["Dependencies (1"]
        P2["<b>📦&nbsp;BlazorApp.Domain.csproj</b><br/><small>net8.0</small>"]
        click P2 "#srcdomainblazorappdomainblazorappdomaincsproj"
    end
    P1 --> MAIN
    P5 --> MAIN
    MAIN --> P2

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 28 |  |
| ***Total APIs Analyzed*** | ***28*** |  |

<a id="srctestsblazorapptestsblazorapptestscsproj"></a>
### src\Tests\BlazorApp.Tests\BlazorApp.Tests.csproj

#### Project Info

- **Current Target Framework:** net8.0
- **Proposed Target Framework:** net10.0
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 3
- **Dependants**: 0
- **Number of Files**: 3
- **Number of Files with Incidents**: 1
- **Lines of Code**: 6
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BlazorApp.Tests.csproj"]
        MAIN["<b>📦&nbsp;BlazorApp.Tests.csproj</b><br/><small>net8.0</small>"]
        click MAIN "#srctestsblazorapptestsblazorapptestscsproj"
    end
    subgraph downstream["Dependencies (3"]
        P2["<b>📦&nbsp;BlazorApp.Domain.csproj</b><br/><small>net8.0</small>"]
        P1["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
        P3["<b>📦&nbsp;BlazorApp.Infrastructure.csproj</b><br/><small>net8.0</small>"]
        click P2 "#srcdomainblazorappdomainblazorappdomaincsproj"
        click P1 "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
        click P3 "#srcinfrastructureblazorappinfrastructureblazorappinfrastructurecsproj"
    end
    MAIN --> P2
    MAIN --> P1
    MAIN --> P3

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 2 |  |
| ***Total APIs Analyzed*** | ***2*** |  |

<a id="srcwebblazorappwebcsproj"></a>
### src\Web\BlazorApp.Web.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** AspNetCore
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 66
- **Lines of Code**: 452
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BlazorApp.Web.csproj"]
        MAIN["<b>📦&nbsp;BlazorApp.Web.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#srcwebblazorappwebcsproj"
    end
    subgraph downstream["Dependencies (1"]
        P1["<b>📦&nbsp;BlazorApp.Application.csproj</b><br/><small>net8.0</small>"]
        click P1 "#srcapplicationblazorappapplicationblazorappapplicationcsproj"
    end
    MAIN --> P1

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

