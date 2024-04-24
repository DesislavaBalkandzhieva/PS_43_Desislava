using Welcome.ViewModel;

namespace Welcome.View
{
    internal class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine($"Welcome:\n User: {_viewModel.Name}\n Role: {_viewModel.Role}");
        }

        public void DisplayError(string error)
        {
            throw new Exception(error);
        }

    }
}
