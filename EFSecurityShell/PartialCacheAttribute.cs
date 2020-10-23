using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace TeamComeback_V2
{
    public class PartialCacheAttribute: OutputCacheAttribute
    {
        public PartialCacheAttribute(string cacheProfileName)
        {
            OutputCacheSettingsSection outputCacheSettingsSection =
            (OutputCacheSettingsSection)WebConfigurationManager.GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile outputCacheProfile = outputCacheSettingsSection.OutputCacheProfiles["1MinuteCache"];
            Duration = outputCacheProfile.Duration;
            VaryByParam = outputCacheProfile.VaryByParam;
        }
    }
}