using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNet.Identity;
using TrainerWebApi.Services;

namespace TrainerWebApi.Filters.Action
{
    public class BasicAuthenticationFilter : ActionFilterAttribute
    {
        private readonly IAuthenticationService _authenticationService;

        public BasicAuthenticationFilter(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string authenticationHeader = actionContext.Request.Headers.Authorization.Parameter;
            var creds = ExtractUserNameAndPassword(authenticationHeader);

            if (_authenticationService.Authenticate(creds[0], creds[1]) == PasswordVerificationResult.Failed)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, "Incorrect password or username");
            }
        }

        private string[] ExtractUserNameAndPassword(string authorizationParameter)
        {
            byte[] credentialBytes;

            try
            {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return null;
            }

            Encoding encoding = Encoding.ASCII;
            encoding = (Encoding)encoding.Clone();
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            string decodedCredentials;

            try
            {
                decodedCredentials = encoding.GetString(credentialBytes);
            }
            catch (DecoderFallbackException)
            {
                return null;
            }

            if (String.IsNullOrEmpty(decodedCredentials))
            {
                return null;
            }

            int colonIndex = decodedCredentials.IndexOf(':');

            if (colonIndex == -1)
            {
                return null;
            }

            string userName = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);

            return new[] {userName, password};
        }
    }
}