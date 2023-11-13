using CommunityToolkit.Mvvm.ComponentModel;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    [QueryProperty(nameof(TodoItem), "TodoItem")]
    public partial class TodoDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private TodoItem todoItem;
    }
}
