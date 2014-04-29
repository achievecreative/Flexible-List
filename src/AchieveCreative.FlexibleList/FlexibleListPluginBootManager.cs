using Umbraco.Core;
using Umbraco.Core.ObjectResolution;
using Umbraco.Web;

namespace AchieveCreative.FlexibleList
{
    public class FlexibleListPluginBootManager : ApplicationEventHandler
    {
        protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ResolverBase<DatasourceProviderResolver>.Current = new DatasourceProviderResolver(PluginManager.Current.ResolveTypes<DatasourceProvider>());
        }
    }
}