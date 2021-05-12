using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.Svg.Skia;

namespace SvgMarkupExtension
{
    public class SvgImageExtension : MarkupExtension
    {
        public SvgImageExtension(string name) => Name = name;

        public string Name { get; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var uri = (IUriContext)serviceProvider.GetService(typeof(IUriContext))!;
            var loader = AvaloniaLocator.Current.GetService<IAssetLoader>();
            var stream = loader.Open(new Uri(Name, UriKind.Relative), uri.BaseUri);
            var source = new SvgSource();
            source.Load(stream);
            return new SvgImage { Source = source };
        }
    }
}
