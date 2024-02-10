namespace ITC2Wedstrijd
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BaseViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
