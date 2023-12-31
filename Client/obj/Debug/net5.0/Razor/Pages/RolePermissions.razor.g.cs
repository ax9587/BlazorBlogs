#pragma checksum "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d1ae2e15e9d961950e3f9083cadf4f76cfa31c0"
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
#line 3 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
using BlazorBlog.Client.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
using BlazorBlog.Shared.Dtos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
using BlazorBlog.Shared.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/rolepermissions/{Id}")]
    public partial class RolePermissions : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
 if (permissions == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Loading...</em></p>");
#nullable restore
#line 10 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "h3");
            __builder.AddContent(2, "Manage Permissionss for Role: ");
#nullable restore
#line 13 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
__builder.AddContent(3, model.RoleName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.EditForm>(5);
            __builder.AddAttribute(6, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#nullable restore
#line 14 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
                      model

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::Microsoft.AspNetCore.Components.Forms.EditContext>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 14 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
                                            SaveRolePermission

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(8, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(9, "table");
                __builder2.AddAttribute(10, "class", "table");
                __builder2.AddMarkupContent(11, "<thead><tr><th>Permission</th>\r\n                <th>Status</th></tr></thead>\r\n        ");
                __builder2.OpenElement(12, "tbody");
#nullable restore
#line 23 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
             foreach (var item in model.RolePermissions)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(13, "tr");
                __builder2.OpenElement(14, "td");
#nullable restore
#line 26 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
__builder2.AddContent(15, item.PermissionName);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(16, "\r\n                    ");
                __builder2.OpenElement(17, "td");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputCheckbox>(18);
                __builder2.AddAttribute(19, "id", "IsSelected");
                __builder2.AddAttribute(20, "class", "form-check");
                __builder2.AddAttribute(21, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Boolean>(
#nullable restore
#line 27 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
                                                                   item.Selected

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.Boolean>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => item.Selected = __value, item.Selected))));
                __builder2.AddAttribute(23, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.Boolean>>>(() => item.Selected));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 29 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
            }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n        ");
                __builder2.AddMarkupContent(25, "<button type=\"submit\" class=\"btn btn-primary\">Save</button>");
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 34 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Users\Alex\Desktop\2023\Blazor\Client\Pages\RolePermissions.razor"
       
    private List<Permission> permissions;
    private List<RolePermissionDto> rolepermissions;
    private RoleInfoDto role;
    private ManageRolePermissionsViewModel model;

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        permissions = await UserRolesService.GetPermissions();
        rolepermissions = await UserRolesService.GetRolePermissions(int.Parse(Id));
        role = await UserRolesService.GetRoleInfo(int.Parse(Id));

        var viewModel = new List<RolePermissionsViewModel>();
        foreach (var permission in permissions)
        {
            var rolePermissionsViewModel = new RolePermissionsViewModel
                {
                    PermissionId = permission.Id,
                    PermissionName = permission.Name
                };
            if (rolepermissions.Exists(x => x.PermissionId == permission.Id))
            {
                rolePermissionsViewModel.Selected = true;
            }
            else
            {
                rolePermissionsViewModel.Selected = false;
            }
            viewModel.Add(rolePermissionsViewModel);
        }
        model = new ManageRolePermissionsViewModel()
            {
                RoleId = int.Parse(Id),
                RoleName = role.Name,
                RolePermissions = viewModel
            };
    }
    async Task SaveRolePermission()
    {
        UpdateRolePermissionDto rolepermissions = new UpdateRolePermissionDto();
        rolepermissions.RoleId = model.RoleId;
        var rolepermissionlist = new List<RolePermissionDto>();
        foreach (var permission in model.RolePermissions)
        {
            if (permission.Selected)
            {
                var rolepermission = new RolePermissionDto
                {
                        RoleId = model.RoleId,
                        PermissionId=permission.PermissionId
                };
                rolepermissionlist.Add(rolepermission);
            }
        }
        rolepermissions.RolePermissions = rolepermissionlist;

        var response = await UserRolesService.UpdateRolePermissions(rolepermissions);

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorBlog.Client.Service.IUserRolesService UserRolesService { get; set; }
    }
}
#pragma warning restore 1591
