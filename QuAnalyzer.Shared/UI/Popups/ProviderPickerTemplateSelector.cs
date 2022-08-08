using QuAnalyzer.Core.Helpers;

namespace QuAnalyzer.UI.Pages;

public class ProviderPickerTemplateSelector : DataTemplateSelector
{
    public DataTemplate NugetPackageTemplate { get; set; }
    public DataTemplate DataProviderTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item)
    {
        if (item is NugetPackage)
        {
            return NugetPackageTemplate;
        }

        return DataProviderTemplate;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        return SelectTemplateCore(item);
    }
}