using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace ServiceDeskSVC.CORSPolicy
{
    //Code Developed by: Matt Mazzola (@mdmb54) - http://www.shillier.com/archive/2014/04/04/cors-domain-wildcarding-for-sharepoint-2013-apps.aspx
    //Modified by: Eric Markson

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SharePointAppDomainCorsPolicy : Attribute, ICorsPolicyProvider
    {
        private static readonly List<string> AcceptableDomainPatterns = new List<string>
        {
            @"app([-\w]+)(\.[\w]+)?\.northernsafety-spapps\.com"
        };


        public async Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken token)
        {
            var corsRequestContext = request.GetCorsRequestContext();
            var originRequested = corsRequestContext.Origin;

            if (await IsOriginAcceptable(originRequested))
            {
                // Grant CORS request
                var policy = new CorsPolicy
                {
                    AllowAnyHeader = true,
                    AllowAnyMethod = true
                };
                policy.Origins.Add(originRequested);
                return policy;
            }
            return null;
        }

        private async Task<Boolean> IsOriginAcceptable(string origin)
        {
            return AcceptableDomainPatterns.Select(pattern => new Regex(pattern, RegexOptions.IgnoreCase)).Any(regex => regex.IsMatch(origin));
        }
    }
}