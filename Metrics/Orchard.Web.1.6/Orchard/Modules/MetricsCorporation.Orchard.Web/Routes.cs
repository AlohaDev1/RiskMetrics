﻿using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace MetricsCorporation.Orchard.Web
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "MetricsCorporation.Orchard.Web",
                        new RouteValueDictionary {
                            {"area", "MetricsCorporation.Orchard.Web"},
                            {"controller", "Administration"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "MetricsCorporation.Orchard.Web"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}