using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AchieveCreative.FlexibleList.Models;
using Umbraco.Core.Logging;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace AchieveCreative.FlexibleList.Controllers
{
    [PluginController("FlexibleList")]
    public class DatasourceController : UmbracoAuthorizedJsonController
    {
        [HttpGet]
        public IEnumerable<DatasourceItem> Query(int currentNodeId, string propertyAlias, string providerName)
        {
            var provider = DatasourceProviderResolver.Current.Providers.FirstOrDefault(p => p.Name == providerName);
            if (provider == null)
            {
                LogHelper.Warn<DatasourceController>("Datasource provider not found.");

                return Enumerable.Empty<DatasourceItem>();
            }

            return provider.Query(currentNodeId, propertyAlias);
        }
    }
}