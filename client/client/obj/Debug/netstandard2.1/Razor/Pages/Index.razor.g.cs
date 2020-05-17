#pragma checksum "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1306ef7f27157f0685e71cd2895e026c93176ba"
// <auto-generated/>
#pragma warning disable 1591
namespace client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/_Imports.razor"
using client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h1");
            __builder.AddContent(1, " ");
            __builder.AddContent(2, 
#nullable restore
#line 6 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
      hubConnection.State

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\r\n\r\n");
#nullable restore
#line 8 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
 foreach (var quote in quotes){

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "    ");
            __builder.OpenElement(5, "h3");
            __builder.AddContent(6, " ");
            __builder.AddContent(7, 
#nullable restore
#line 9 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
          quote.Author

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "p");
            __builder.AddContent(10, " ");
            __builder.AddContent(11, 
#nullable restore
#line 10 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
         quote.Quote

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n");
#nullable restore
#line 11 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "/Users/gwynethpena/Developer/signalr-stoic-quotes/client/client/Pages/Index.razor"
 
 
 private HubConnection hubConnection;
 private List<IncomingQuote> quotes = new List<IncomingQuote>();

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:7071/api").Build();
        hubConnection.On<IncomingQuote>("incomingQuote", (incomingQuote) =>
            {

                quotes.Add(incomingQuote);
                StateHasChanged();


            }
                         
            );

            await hubConnection.StartAsync();
        
    }

    public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

    public class IncomingQuote {
        public string Author {get; set;}
        public string Quote {get; set;}
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
