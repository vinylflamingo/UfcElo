﻿using Microsoft.Owin;
using Owin;
using System.Web.Http.Controllers;

[assembly: OwinStartupAttribute(typeof(UfcElo.Web.Startup))]
namespace UfcElo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
