using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AchieveCreative.FlexibleList.Models;

namespace AchieveCreative.FlexibleList
{
    public abstract class DatasourceProvider
    {
        public abstract string Name { get; }

        public virtual IEnumerable<DatasourceItem> Query(int currentNodeId, string propertyAlias)
        {
            return Enumerable.Empty<DatasourceItem>();
        }
    }
}