using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace AchieveCreative.FlexibleList.Controllers
{
    [PluginController("FlexibleList")]
    public class ListProdiverController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<string> GetAll()
        {
            return DatasourceProviderResolver.Current.Providers.Select(p => p.Name);
        }
    }
}