using TicTacToe.Models;
using TicTacToe.PageModels;

namespace TicTacToe.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}