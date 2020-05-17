# signalr-functions-demo
A demo on how to use SignalR service with Azure Functions

## What is ASP.NET Core SignalR?

It is an open-source library that adds real-time web functionality to apps. Apps that require high frequency updates from the server, social networks, gaming, dashboards, monitoring, apps that require notifications, are all great candidates for SignalR.

SignalR:

- Handles connection management automatically.
- Sends messages to all connected clients simultaneously, or to specific clients or groups of clients.
- Scales to handle increasing traffic.

### **Transports**

Transports are methods of handling real time communication. 

SignalR automatically chooses the best method that is within the capabilities of the server and client. 

The following techniques are supported:

- [WebSockets](https://tools.ietf.org/html/rfc7118)
- Server-Sent Events
- Long Polling

### **Hubs**

SignalR uses hubs to communicate between clients and servers. In the server code, you define methods that are called by client. In the client code, you define methods that are called from the server and a hub is a high-level pipeline that allows a client and server to call methods on each other. 

SignalR provides two built-in hub protocols: a text protocol based on JSON and a binary protocol based on [MessagePack](https://msgpack.org/). 

## Azure SignalR Service

Is the hosted on Azure version of SignalR.

- Removes the need to manage back planes that handle the scales and client connections.
- Simplifies web applications and saves hosting cost.
- Global reach, SLA, scales to millions of connections, all the security and compliance goodies that are standards when using an Azure service.

## Azure SignalR service and Azure functions

A Function of any trigger type can push out messages to clients using Azure Functions SignalR bindings. 

Azure SignalR Service and Azure Functions are both fully managed services and we're going to use the two together to provide real-time communications in a serverless environment in this demo.

[You'll need an instance of Azure SignalR service to get this working](https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet-core)

In this [video](https://youtu.be/ILV0OpMq01c), I walk through a simple example of SignalR service, Azure functions and Blazor Wasm.

