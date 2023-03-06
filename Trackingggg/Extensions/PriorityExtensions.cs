using Trackingggg.Models;

namespace Trackingggg.Extensions
{
    public static class PriorityExtensions
    {
        // dictionary that will map the priority below to css classes -> uses bootstrap classes to visually show the priority
        static readonly Dictionary<Priority, string> _priorityCssClasses = new() {
            [Priority.High] = "badge bg-danger",
            [Priority.Medium] = "badge bg-warning text-dark",
            [Priority.Low] = "badge bg-success"
        };
        // this ToCssClass method will look at the priority in the css class and return the corresponding css classes
        public static string ToCssClass(this Priority priority) =>
            _priorityCssClasses[priority];
        
    }
}
