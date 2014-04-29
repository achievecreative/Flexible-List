using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.ObjectResolution;

namespace AchieveCreative.FlexibleList
{
    public sealed class DatasourceProviderResolver : ManyObjectsResolverBase<DatasourceProviderResolver, DatasourceProvider>
    {
        internal DatasourceProviderResolver(IEnumerable<Type> providers)
            : base(providers)
        {

        }

        public IEnumerable<DatasourceProvider> Providers
        {
            get { return Values; }
        } 
    }
}