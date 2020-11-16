﻿using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace GranulationAnalysis.PrismHelper
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Children.Add(element);
                        }
                    }
                    else if (e.Action == NotifyCollectionChangedAction.Remove)
                    {
                        foreach (FrameworkElement element in e.OldItems)
                        {
                            regionTarget.Children.Remove(element);
                        }
                    }
                };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
