using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Welcome.Extensions;
using Welcome.Models;

namespace Welcome.Infrastructure
{
    public static class SessionVariables
    {
        public static Greeter GetGreeter(IServiceProvider serviceProvider)
        {
            var accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var greeter = accessor.HttpContext.Session.Get<Greeter>("greeting");
            if (greeter == null)
            {
                greeter = new Greeter {
                    MorningMessage = "Good Morning",
                    EveningMessage = "Good Evening"
                };
                accessor.HttpContext.Session.Set<Greeter>("greeting", greeter);
            }
            return greeter;
        }
    }
}