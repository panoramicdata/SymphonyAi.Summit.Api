# SymphonyAi.Summit.Api

[![Nuget](https://img.shields.io/nuget/v/SymphonyAi.Summit.Api)](https://www.nuget.org/packages/SymphonyAi.Summit.Api/)
[![Nuget](https://img.shields.io/nuget/dt/SymphonyAi.Summit.Api)](https://www.nuget.org/packages/SymphonyAi.Summit.Api/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/962e948e6c054870ad95ebc6191cd144)](https://www.codacy.com/gh/panoramicdata/SymphonyAi.Summit.Api/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=panoramicdata/SymphonyAi.Summit.Api&amp;utm_campaign=Badge_Grade)

This project implements access to the Symphony AI Summit API.

See the [contribution guide](CONTRIBUTING.md) for more information regarding contributing to this project

To use the Symphony AI Summit API nuget package:

## Visual Studio

1. Open your project in Visual Studio
1. Right-click on the project and click "Manage Nuget packages"
1. Find the package "SymphonyAi.Summit.Api" - install the latest version

## Example code (C# 11)

``` C#
using SymphonyAi.Summit.Api;
using System;
using System.Threading.Tasks;

namespace My.Project
{
	public static class Program
	{
		public static async Task Main()
		{
			using var summitClient = new SummitClient(new SummitClientOptions
			{
				ApiKey = "0123456789abcdef0123456789abcdef01234567"
			});

			var incidents = await merakiClient
				.Incidents
				.GetMyIncidentsAsync(new GetMyIncidentsRequest
					{
						...
					}
				)
				.ConfigureAwait(false);
		}
	}
}
```

## API Documentation

The Symphony AI Summit API documentation can be found here:

- [Symphony AI Summit API Documentation v1](https://docs.symphonysummitai.com/display/DS/SummitAI+API+Docs)
