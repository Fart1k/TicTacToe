using CommunityToolkit.Mvvm.Input;
using TicTacToe.Models;

namespace TicTacToe.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}