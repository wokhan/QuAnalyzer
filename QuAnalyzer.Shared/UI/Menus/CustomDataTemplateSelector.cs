using Wokhan.Data.Providers.Contracts;

namespace QuAnalyzer.UI.Menus;

public class CustomDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate RepositoryTemplate { get; set; }
    public DataTemplate HeaderTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item)
    {
        if (item is IDataProvider)
        {
            return this.HeaderTemplate;
        }

        return RepositoryTemplate;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        return SelectTemplateCore(item);
    }
}