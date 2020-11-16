using System;

namespace GranulationAnalysis.Core.Prism
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependentViewAttribute : Attribute
    {
        public Type Type { get; set; }
        public string TargetRegionName { get; set; }

        public DependentViewAttribute(Type viewType, string targetRegionName)
        {

            if (targetRegionName is null)
                throw new ArgumentNullException(nameof(targetRegionName));

            Type = viewType ?? throw new ArgumentNullException(nameof(viewType));

            TargetRegionName = targetRegionName;
        }
    }
}
