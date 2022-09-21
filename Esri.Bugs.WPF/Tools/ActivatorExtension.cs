using System;
using System.Collections;
using System.Windows.Markup;

namespace Esri.Bugs.WPF.Tools
{
    /// <summary>
    /// This is a <see cref="MarkupExtension" /> that can construct any public class for use in XAML.
    /// </summary>
    /// <remarks>Use wisely.</remarks>
    [ContentProperty(nameof(Args))]
    // ReSharper disable once UnusedMember.Global
    public class ActivatorExtension : MarkupExtension
    {
        public ActivatorExtension(Type t, object[] args)
        {
            Type = t;
            Args = new ArrayList(args);
        }

        public ActivatorExtension()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => Activator.CreateInstance(Type, Args.ToArray());

        // ReSharper disable once MemberCanBePrivate.Global
        public Type Type { get; set; }

        // ReSharper disable once MemberCanBePrivate.Global
        public ArrayList Args { get; set; } = new ArrayList();
    }
}