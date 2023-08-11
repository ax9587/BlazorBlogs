#pragma checksum "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f076eaf999f18d0aaad28b1289a73a70ca2f65b"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorBlog.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using BlazorBlog.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using BlazorBlog.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Alex\Desktop\2023\Blazor\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
using BlazorBlog.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
using BlazorBlog.Shared.Dtos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/users")]
    public partial class Users : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>User List</h1>");
#nullable restore
#line 9 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
 if (users == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 12 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table");
            __builder.AddMarkupContent(4, "<thead><tr><th>Email</th>\r\n                <th>Action</th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 23 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
             foreach (var user in users)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
#nullable restore
#line 26 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
__builder.AddContent(8, user.Email);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n                    ");
            __builder.OpenElement(10, "td");
            __builder.OpenElement(11, "a");
            __builder.AddAttribute(12, "href", "/userroles/" + (
#nullable restore
#line 28 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
                                             user.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "class", "btn btn-primary");
            __builder.AddContent(14, "Manage Roles");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                        ");
            __builder.OpenElement(16, "a");
            __builder.AddAttribute(17, "href", "/usercategories/" + (
#nullable restore
#line 29 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
                                                  user.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "class", "btn btn-warning");
            __builder.AddContent(19, "Manage Categories");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 32 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 35 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\Users.razor"
       
    private List<UserListItemDto> users;

    protected override async Task OnInitializedAsync()
    {
        users = await UserRolesService.GetUsers();
        //users = await Http.GetFromJsonAsync<UserListItemDto[]>("/api/userlist/users");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorBlog.Client.Service.IUserRolesService UserRolesService { get; set; }
    }
}
#pragma warning restore 1591
