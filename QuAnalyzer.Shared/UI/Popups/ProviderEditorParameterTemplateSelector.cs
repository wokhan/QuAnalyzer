using Wokhan.Data.Providers.Bases;

namespace QuAnalyzer.UI.Pages;

public class ProviderEditorParameterTemplateSelector : DataTemplateSelector
{
    public DataTemplate DefaultTemplate { get; set; }
    public DataTemplate FileTemplate { get; set; }
    public DataTemplate ListTemplate { get; set; }
    public DataTemplate BooleanTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item)
    {
        var definition = item as DataProviderMemberDefinition;
        if (definition.IsFile)
        {
            return FileTemplate;
        }

        if (definition.MemberType == typeof(bool))
        {
            return BooleanTemplate;
        }

        if (definition.HasValuesGetter)
        {
            return ListTemplate;
        }

        return DefaultTemplate;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        return SelectTemplateCore(item);
    }
}