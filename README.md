# Sankhya SDK

📊⚙️ [Sankhya](https://www.sankhya.com.br/) .NET SDK.

[![GitHub license](https://img.shields.io/github/license/guibranco/Sankhya-SDK-dotnet)](https://github.com/guibranco/Sankhya-SDK-dotnet)
[![Time tracker](https://wakatime.com/badge/github/guibranco/Sankhya-SDK-dotnet.svg)](https://wakatime.com/badge/github/guibranco/Sankhya-SDK-dotnet)

![Sankhya logo](https://raw.githubusercontent.com/guibranco/Sankhya-SDK-dotnet/main/logo.png)

## CI/CD

| Build status | Last commit | Tests | Coverage | Code Smells | LoC | 
|--------------|-------------|-------|----------|-------------|-----|
| [![Build status](https://ci.appveyor.com/api/projects/status/e1midttew0yykr59/branch/main?svg=true)](https://ci.appveyor.com/project/guibranco/Sankhya-SDK-dotnet/branch/main) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/Sankhya-SDK-dotnet/main)](https://github.com/guibranco/Sankhya-SDK-dotnet) | [![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/Sankhya-SDK-dotnet/main?compact_message)](https://ci.appveyor.com/project/guibranco/Sankhya-SDK-dotnet/branch/main/tests) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=coverage)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet) | [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet) | [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)

## Code Quality

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/f6d787f9a2fe4116a7a8a0043489ba67)](https://app.codacy.com/gh/guibranco/Sankhya-SDK-dotnet/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/f6d787f9a2fe4116a7a8a0043489ba67)](https://app.codacy.com/gh/guibranco/Sankhya-SDK-dotnet/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_coverage)

[![codecov](https://codecov.io/gh/guibranco/Sankhya-SDK-dotnet/branch/main/graph/badge.svg)](https://codecov.io/gh/guibranco/Sankhya-SDK-dotnet)
[![CodeFactor](https://www.codefactor.io/repository/github/guibranco/Sankhya-SDK-dotnet/badge)](https://www.codefactor.io/repository/github/guibranco/Sankhya-SDK-dotnet)

[![Maintainability](https://api.codeclimate.com/v1/badges/d753c91651260c3da761/maintainability)](https://codeclimate.com/github/guibranco/Sankhya-SDK-dotnet/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/d753c91651260c3da761/test_coverage)](https://codeclimate.com/github/guibranco/Sankhya-SDK-dotnet/test_coverage)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)

[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_Sankhya-SDK-dotnet&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_Sankhya-SDK-dotnet)

---

## Installation

### Github Releases

[![GitHub last release](https://img.shields.io/github/release-date/guibranco/Sankhya-SDK-dotnet.svg?style=flat)](https://github.com/guibranco/Sankhya-SDK-dotnet) [![Github All Releases](https://img.shields.io/github/downloads/guibranco/Sankhya-SDK-dotnet/total.svg?style=flat)](https://github.com/guibranco/Sankhya-SDK-dotnet)

Download the latest zip file from the [Release](https://github.com/GuiBranco/Sankhya-SDK-dotnet/releases) page.

### Nuget package manager

| Package | Version | Downloads |
|------------------|:-------:|:-------:|
| **Sankhya** | [![Sankhya NuGet Version](https://img.shields.io/nuget/v/Sankhya.svg?style=flat)](https://www.nuget.org/packages/Sankhya/) | [![Sankhya NuGet Downloads](https://img.shields.io/nuget/dt/Sankhya.svg?style=flat)](https://www.nuget.org/packages/Sankhya/) |

---

## Features

This SDK implements many of Sankhya's web services. Some of them are called Know Services. If the service you seek is not set in the SDK, you can implement the service request/response independently (and use it on your code or submit a pull request to this repository).

Some Request Wrappers allow you to make some requests easily.

### Known Services

[Wiki page about KSRW](https://github.com/guibranco/Sankhya-SDK-dotnet/wiki/1.1.1-%E2%80%90-Know-Services-Request-Wrapper-(KSRW))

### Sankhya Wrapper

The *last-mile operations* are done on these wrappers.
This class defines all HTTP request/response, login/logout, serialization, and download/upload operations.

**Avoid** using this class directly from your implementation. Only call its methods if you are extending the SDK's functionality or implementing a new feature. Otherwise, I prefer using one of the request wrappers or the Sankhya Context class.

---

## Usage

### Service registration (IoC / DI)

This SDK is based on [CrispyWaffle toolkit](https://github.com/guibranco/CrispyWaffle), so you can use its [Service Locator](https://guibranco.github.io/CrispyWaffle/user-guide/serviceLocator/) feature to register it.

Assuming you are using Crispy Waffle, you can register the Sankhya wrapper in the `Bootstrapper.cs` file this way:

```cs
var connectionSankhya = new Connection(); //Fill in your details
ServiceLocator.Register(() => new SankhyaContext(connectionSankhya), LifeStyle.Singleton);
```

Later, when you need to access the [Sankhya Context]() in your code, you can just pass it as the constructor's argument or retrieve it from **Service Locator**

#### Constructor argument

```cs
public class MyClass {

    private readonly SankhyaContext _sankhyaContext;

    public MyClass(SankhyaContext sankyaContext) {
        _sankhyaContext = sankhyaContext ?? throw new ArgumentNullException(nameof(sankhyaContext));
    }
}
```

#### Retrieving manually

```cs
var sankhyaContext = ServiceLocator.Resolve<SankhyaContext>();
```

### Know Services Wrapper

The `KnowServicesRequestWrapper` is a static class that can be used anywhere since SankhyaContext is registered through ServiceLocator.

### Session management

You can use this to get all active sessions in Sankhya and kill them one by one:

```cs
var sessions = KnowServicesRequestWrapper.GetSessions();
foreach (var session in sessions) {
    KnowServicesRequestWrapper.KillSession(session.Id);
}
```
---

## Support

Please [open an issue](https://github.com/guibranco/Sankhya-SDK-dotnet/issues/new) for support.

---

## Contributing

Refer to [CONTRIBUTING.md](CONTRIBUTING.md) to learn how to contribute to this project!

### Contributors

<!-- readme: collaborators,contributors,snyk-bot/- -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/guibranco">
                    <img src="https://avatars.githubusercontent.com/u/3362854?v=4" width="100;" alt="guibranco"/>
                    <br />
                    <sub><b>Guilherme Branco Stracini</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/fandriyaninkov">
                    <img src="https://avatars.githubusercontent.com/u/18394528?v=4" width="100;" alt="fandriyaninkov"/>
                    <br />
                    <sub><b>Fedor Andriyaninkov</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/pedrowindisch">
                    <img src="https://avatars.githubusercontent.com/u/30203228?v=4" width="100;" alt="pedrowindisch"/>
                    <br />
                    <sub><b>Pedro Henrique</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/viktoriussuwandi">
                    <img src="https://avatars.githubusercontent.com/u/68414300?v=4" width="100;" alt="viktoriussuwandi"/>
                    <br />
                    <sub><b>Viktorius Suwandi</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators,contributors,snyk-bot/- -end -->

### Bots

<!-- readme: bots,snyk-bot -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/dependabot[bot]">
                    <img src="https://avatars.githubusercontent.com/in/29110?v=4" width="100;" alt="dependabot[bot]"/>
                    <br />
                    <sub><b>dependabot[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/github-actions[bot]">
                    <img src="https://avatars.githubusercontent.com/in/15368?v=4" width="100;" alt="github-actions[bot]"/>
                    <br />
                    <sub><b>github-actions[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/penify-dev[bot]">
                    <img src="https://avatars.githubusercontent.com/in/399279?v=4" width="100;" alt="penify-dev[bot]"/>
                    <br />
                    <sub><b>penify-dev[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/stack-file[bot]">
                    <img src="https://avatars.githubusercontent.com/in/408123?v=4" width="100;" alt="stack-file[bot]"/>
                    <br />
                    <sub><b>stack-file[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/codefactor-io[bot]">
                    <img src="https://avatars.githubusercontent.com/in/25603?v=4" width="100;" alt="codefactor-io[bot]"/>
                    <br />
                    <sub><b>codefactor-io[bot]</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/gitauto-ai[bot]">
                    <img src="https://avatars.githubusercontent.com/in/844909?v=4" width="100;" alt="gitauto-ai[bot]"/>
                    <br />
                    <sub><b>gitauto-ai[bot]</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/snyk-bot">
                    <img src="https://avatars.githubusercontent.com/u/19733683?v=4" width="100;" alt="snyk-bot"/>
                    <br />
                    <sub><b>Snyk bot</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: bots,snyk-bot -end -->
