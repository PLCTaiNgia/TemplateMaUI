using TodoApp.Views;

namespace TodoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoPage), typeof(TodoPage));
            Routing.RegisterRoute(nameof(TodoDetailPage), typeof(TodoDetailPage));
        }
    }
}