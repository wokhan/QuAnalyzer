using System.Xaml;
using System.Diagnostics.Contracts;

namespace System.Windows.Markup
{
	[ContentProperty("Path")]
	public class Bind : MarkupExtension
	{
		public Bind()
		{
		}

		public Bind(string path)
		{
			Path = path;
		}

		[ConstructorArgument("path")]
		public string Path { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			Contract.Requires(serviceProvider != null);
			Contract.Requires(Path != null);

			var r = serviceProvider.GetService(typeof(IXamlNameResolver)) as IXamlNameResolver;
			if (r == null)
			{
				throw new InvalidOperationException("serviceProvider does not implement IXamlNameResolver");
			}

			var ret = r.Resolve(Path);
			if (ret == null)
			{
				ret = r.GetFixupToken(new string[] { Path }, true);
			}

			return ret;
		}
	}
}