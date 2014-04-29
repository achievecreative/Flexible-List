using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using AchieveCreative.FlexibleList.Models;
using Umbraco.Core.Logging;

namespace AchieveCreative.FlexibleList
{
    public class MemberGroupProvider : DatasourceProvider
    {
        public override string Name
        {
            get { return "Member Group Selector"; }
        }

        public override IEnumerable<DatasourceItem> Query(int currentNodeId, string propertyAlias)
        {
            try
            {
                return Roles.GetAllRoles().Select(umbraco.cms.businesslogic.member.MemberGroup.GetByName)
                    .Select(m => new DatasourceItem() { Text = m.Text, Value = m.Id.ToString() });
            }
            catch (Exception e)
            {
                LogHelper.Error(typeof(MemberGroupProvider), e.Message, e);
            }

            return base.Query(currentNodeId, propertyAlias);
        }
    }
}