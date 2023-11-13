using TodoApp.ViewModels;

namespace TodoApp.Views;

public partial class TodoDetailPage : ContentPage
{
    public TodoDetailPage(TodoDetailPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}