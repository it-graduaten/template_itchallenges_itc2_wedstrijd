

namespace ITC2Wedstrijd.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        public bool IsNotBusy => !isBusy;

        [RelayCommand]
        public static async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        public static async Task GoToClubsAsync()
        {
            await Shell.Current.GoToAsync(nameof(ClubPage));
        }
        [RelayCommand]
        public static async Task GoToCategoriënAsync()
        {
            await Shell.Current.GoToAsync(nameof(CategoriePage));
        }
        [RelayCommand]
        public static async Task GoToSportenAsync()
        {
            await Shell.Current.GoToAsync(nameof(SportPage));
        }
        [RelayCommand]
        public static async Task GoToSpelersAsync()
        {
            await Shell.Current.GoToAsync(nameof(SpelerPage));
        }
        [RelayCommand]
        public static async Task GoToPloegenAsync()
        {
            await Shell.Current.GoToAsync(nameof(PloegPage));
        }
    }
}