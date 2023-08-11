1.Add EF - 
  dotnet tool install dotnet-ef
  Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.Design
  Microsoft.EntityFrameworkCore.Sqlite
  ConnectionString
  dotnet ef migrations add Initial
  dotnet ef database update
  https://sqlitebrowser.org/
2. Add auth
  -1. Implemente  AuthenticationStateProvider  which is publish/subscriptioned with StateChange affect the subscribed <AuthorizeView> <Authorized> controls.
      builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
      builder.Services.AddAuthorizationCore();
      builder.Services.AddBlazoredLocalStorage();
      Imports.razotr
        @using Microsoft.AspNetCore.Components.Authorization
        @using Microsoft.AspNetCore.Authorization
        @using Blazored.LocalStorage

      Add Login page
   -2. Client:
            Packages:
                     Microsoft.AspNetCore.Components.Authorization
                     Blazored.LocalStorage   (4.0.0)


      Shared:
            BlazorBlog.Shared.UserLoginDto

      Server:
           AuthController

3. Auth use db
  -1. Swashbuckle.AspNetCore Not Now
  -2. Add Model -> User; dotnet ef migrations add Add-User-Table ; dotnet ef database update;
  -3. Add MailKit -Settings: MailServerStrings; 
  -4. Create Ethereal Account to create a test account will get test user name and password
4. Generate JWt Token
   Microsoft.IdentityModel.Tokens
   System.IdentityModel.Tokens.Jwt
   builder.Services.AddHttpContextAccessor();
5. Add Jwt Authentication to API methods
    Microsoft.AspNetCore.Authentication.JwtBearer
    --Append Bearer to Http header
       _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
    --api method [Authorized()]
    --builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
6.UnderIn

  user
  role
  user-role
  user-claims
  role-claims
  createdBy:@if ((AuthorizationService.AuthorizeAsync(User, Permissions.Products.Create)).Result.Succeeded)
              context.User.HasClaim(claim =>
                         (claim.Type == "permissions" &&
                          (claim.Value == "create:term" ||
                           claim.Value == "update:term") &&
                          claim.Issuer == $"https://{Configuration["Auth0:Domain"]}/"

  user
  rourse
  permission
  user-resource-[permission]

  resource-user table
  user->Roles
  Roles->Permissions
  user->Categorys
  user->Category->Role->Permission
  User->doc->Category-Role->Permission
  protected override Task<Bool> PermissionCheckAsync(User iser,
                                                   Permission permission,
                                                   Document resource)
  1. Superuser2. Documeny.CreatedBY user 3.User->doc->Category-Role->Permission
  https://learn.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?view=aspnetcore-6.0
  https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/complex-data-model?view=aspnetcore-6.0&tabs=visual-studio

  https://github.com/mwkldeveloper/Asp.Net.Identity.SQLite
  https://auth0.com/blog/permission-based-security-aspnet-webapi/

  .NET 6 Blazor 🔥 Authentication & Role-Based Authorization (using JWT & AuthenticationStateProvider) https://youtu.be/Yh16E2u2pio
@page "/counter"
@attribute [Authorize(Roles = "Iron Man")]

<AuthorizeView Roles="Iron Man">
    <Authorized>
        <span>You're authorized as @context.User.Identity.Name</span>
    </Authorized>
    <NotAuthorized>
        <span>You're not authorized, buddy.</span>
    </NotAuthorized>
</AuthorizeView>

If you want the authorization service in every view, place the @inject directive into the _ViewImports.cshtml file of the Views directory. For more information, see Dependency injection into views.

Icons:
https://icon-sets.iconify.design/oi/people/
    
