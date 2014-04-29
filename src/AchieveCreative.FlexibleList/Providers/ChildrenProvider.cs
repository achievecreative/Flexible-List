using System.Collections.Generic;
using System.Linq;
using AchieveCreative.FlexibleList.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace AchieveCreative.FlexibleList
{
    public class ChildrenProvider : DatasourceProvider
    {
        public override string Name
        {
            get { return "Children Node Selector"; }
        }

        public override IEnumerable<DatasourceItem> Query(int currentNodeId, string propertyAlias)
        {
            var contentService = ApplicationContext.Current.Services.ContentService;
            var node = contentService.GetById(currentNodeId);
            if (node != null)
            {
                return node.Children().Select(n => new DatasourceItem() { Text = n.Name, Value = n.Id.ToString() });
            }

            return Enumerable.Empty<DatasourceItem>();
        }
    }
}