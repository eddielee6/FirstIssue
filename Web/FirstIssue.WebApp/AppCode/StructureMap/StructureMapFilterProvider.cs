using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace FirstIssue.WebApp.AppCode.StructureMap
{
    public class StructureMapFilterProvider : FilterAttributeFilterProvider
    {
        public IContainer Container;

        public StructureMapFilterProvider(IContainer container)
        {
            Container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                Container.BuildUp(filter.Instance);
            }

            return filters;
        }
    }
}