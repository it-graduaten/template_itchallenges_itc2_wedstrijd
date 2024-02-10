
namespace ITC2Wedstrijd.ViewModels
{
    public partial class SportViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Sport> sporten;

        private ISportRepository _sportRepository;

        [ObservableProperty]
        public Sport selectedSport;
        public SportViewModel(SportRepository sportRepository)
        {
            _sportRepository = sportRepository;
            RefreshSporten();
            SelectedSport = new Sport();
            Title = "Sporten";
        }

        [ObservableProperty]
        public string actieLabel = "Nieuwe sport toevoegen";

        partial void OnSelectedSportChanged(Sport value)
        {
            if (value.SportId == 0)
            {
                ActieLabel = "Nieuwe sport toevoegen";
            }
            else
            {
                ActieLabel = "Sport wijzigen";
            }
        }


        private void RefreshSporten()
        {
            Sporten = new ObservableCollection<Sport>(_sportRepository.SportOphalen());
        }

        [RelayCommand]
        public void Toevoegen()
        {
            var result = _sportRepository.ToevoegenSport(SelectedSport);

            if (result)
            {
                RefreshSporten();
                SelectedSport = new Sport();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van de sport", "OK");
            }
        }


        [RelayCommand]
        public void Wijzigen()
        {
            var result = _sportRepository.WijzigenSport(selectedSport);

            if (result)
            {
                RefreshSporten();
                SelectedSport = new Sport();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het wijzigen van de sport", "OK");
            }
        }


        [RelayCommand]
        public void Verwijderen()
        {
            var result = _sportRepository.VerwijderenSport(SelectedSport.SportId);

            if (result)
            {
                RefreshSporten();
                SelectedSport = new Sport();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van de sport", "OK");
            }
        }

        [RelayCommand]
        public void Deselecteren()
        {
            SelectedSport = new Sport();
        }
    }
}