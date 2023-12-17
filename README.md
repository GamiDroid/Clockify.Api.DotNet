# Clockify.Api.DotNet

Stable documentation:
https://docs.clockify.me/

Application:
https://app.clockify.me/

## Usage

1. Get your Clockify API key
See [Clockify Docs](https://docs.clockify.me/#section/Authentication "Clockify Docs - Authentication") for instructions how to get your Clockify API key.

2. Create client

```csharp
using Clockify.Api.DotNet;

using var clockify = new ClockifyApiClient("YOUR_API_KEY");
var userInfoResponse = await clockify.GetCurrentUserInfoAsync();
if (userInfoResponse.IsSuccessStatusCode)
{
    var userInfo = userInfoResponse.CurrentUserInfo;
}
```