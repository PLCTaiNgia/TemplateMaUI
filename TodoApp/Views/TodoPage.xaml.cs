using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Views;

public partial class TodoPage : ContentPage
{
    public TodoPage(TodoPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var todoItem = LsvTodoList.SelectedItem as TodoItem;

        await Shell.Current.GoToAsync(nameof(TodoDetailPage), true, new Dictionary<string, object>
        {
            {"TodoItem", todoItem }
        });
    }
}