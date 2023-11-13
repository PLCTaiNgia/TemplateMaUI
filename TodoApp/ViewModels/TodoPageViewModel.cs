using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public partial class TodoPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<TodoItem> todoList;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private bool status;

        [ObservableProperty]
        private bool thumbnailUrl;

        public TodoPageViewModel()
        {
            TodoList = new ObservableCollection<TodoItem>
            {
                new TodoItem { Id=1, Name="Quét nhà", Status=true , ThumbnailUrl="https://img.websosanh.vn/v10/users/review/images/g1gylldkryzdu/visaongaytetdaikyviecquetnhahotrac2.jpg?compress=85"},
                new TodoItem { Id=2, Name="Rửa bát", Status=false , ThumbnailUrl="https://www.cleanipedia.com/images/5iwkm8ckyw6v/4sLYN6oqoBXaAMiPyEWbMk/a0cc1bd0ffdd4716e3eaa88cbfa44cfd/Y2FjaC1ydWEtY2hlbi1zYWNoLmpwZw/990w-660h/c%C3%A1ch-r%E1%BB%ADa-ch%C3%A9n-s%E1%BA%A1ch.jpg" },
                new TodoItem { Id=3, Name="Học MAUI", Status=false , ThumbnailUrl="https://lh4.googleusercontent.com/--xwpKTZtBA8/UTgOQ3Dg27I/AAAAAAAAARk/1RxL1l9bOE8/s500/hoctap9.jpg?w=900" },
            };
        }

    }
}
