# .NET Minimal APIS, Razor Components, and HTMX
This is a demo on how to use Minimal APIs + Razor Components + HTMX to create dynamic server side rendered apps.

Using Minimal APIs and Razor components is possible because of a new class in .NET 8: **RazorComponentResult**

This returns an IResult after initializing a Razor component, making it possible to use Razor components in Minimal APIs.

## Requirements

Requires .NET 8 RC1 installed.

## Why do this?

Minimal APIs are a great way to organize your app. 1 endpoint corresponds to 1 method in a handler class. Simple and effective.

Razor components are great because you can re-use markup. But with Blazor WASM and Server, you are relying on a lot of magic and niche web technologies (web assembly and web sockets). With this setup, you are simply making normal HTTP requests and returning markup.

Pairing these 2 things together is an easy way to create maintainable, straightforward server side web apps. Add HTMX to this combination and you can build very powerful interfaces.

## HTMX Usage

### Partial page reload on navigation with hx-boost

The HTMX attribute hx-boost turns internal links into ajax calls. This speeds up site speed since there are no full page reloads. You can opt in and out of this behavior on a link by link basis.

This app uses hx-boost on the body tag, turning on this functionality for all links.

### Get and Post requests with hx-get and hx-post

The HTMX attributes hx-get and hx-post sets up ajax calls to endpoints and swaps html on the page with what was returned.

This is useful for submitting forms, searching tables, and modifying the dom from a user interaction on the page.

### Polling

The HTMX attribute hx-trigger can be used to poll the server. This can setup ajax calls to endpoints at an interval and swap html on the page with what was returned.

This is demonstrated on the /Components/Pages/Home.razor page in combination with the /Components/Pages/RandomNumber.razor component.