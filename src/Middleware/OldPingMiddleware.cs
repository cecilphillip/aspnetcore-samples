using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class OldPingMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private const string PingMe = "X-PingMe";
        private const string PingBack = "X-PingBack";

        public OldPingMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this._next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var headers = (IDictionary<string, string[]>)env["owin.RequestHeaders"];

            if (headers.Keys.Contains(PingMe))
            {
                var value = headers[PingMe].FirstOrDefault();
                var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];
                responseHeaders[PingBack] = new[] {$"HI {value}"};
                env["owin.ResponseStatusCode"] = 202;

                return;
            }

            await _next(env);
        }
    }
}