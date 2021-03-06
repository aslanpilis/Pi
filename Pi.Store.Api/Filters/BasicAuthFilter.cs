﻿
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Store.Api.Filters
{
    public class BasicAuthFilter : Attribute, IAuthorizationFilter
    {
    private readonly string _realm;

    public BasicAuthFilter(string realm)
    {
        _realm = realm;
        if (string.IsNullOrWhiteSpace(_realm))
        {
            throw new ArgumentNullException(nameof(realm), @"Please provide a non-empty realm value.");
        }
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var credentials = Encoding.UTF8
                                        .GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                        .Split(':', 2);
                    if (credentials.Length == 2)
                    {
                        if (IsAuthorized(context, credentials[0], credentials[1]))
                        {
                            return;
                        }
                    }
                }
            }

            ReturnUnauthorizedResult(context);
        }
        catch (FormatException)
        {
            ReturnUnauthorizedResult(context);
        }
    }

    public bool IsAuthorized(AuthorizationFilterContext context, string username, string password)
    {
            // redis implementation for apikey
            return true;
    }

    private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
    {
        // Return 401 and a basic authentication challenge (causes browser to show login dialog)
        context.HttpContext.Response.Headers["WWW-Authenticate"] = $"Basic realm=\"{_realm}\"";
        context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
    }
}


}
