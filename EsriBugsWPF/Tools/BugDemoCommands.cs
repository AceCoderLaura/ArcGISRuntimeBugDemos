using System.Windows.Input;

namespace EsriBugsWPF.Tools
{
    public static class BugDemoCommands
    {
        public static readonly RoutedUICommand Step = new RoutedUICommand("Steps to the specified bug demo step.", nameof(Step), typeof(BugDemoCommands));
    }
}