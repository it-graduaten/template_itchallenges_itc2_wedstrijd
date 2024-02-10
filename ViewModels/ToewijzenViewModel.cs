

namespace ITC2Wedstrijd.ViewModels
{
    [QueryProperty(nameof(Ploeg), "Ploeg")]
    public partial class ToewijzenViewModel : BaseViewModel
    {
        [ObservableProperty]
        Ploeg ploeg;

        [ObservableProperty]
        public ObservableCollection<Speler> beschikbareSpelers;


        [ObservableProperty]
        public ObservableCollection<Speler> spelersInPloeg;

        private SpelerPloegRepository _spelerPloegRepository;

        public Speler ItemBeingDragged;

        public ToewijzenViewModel(SpelerPloegRepository spelerPloegRepository)
        {
            _spelerPloegRepository = spelerPloegRepository;
        }

        partial void OnPloegChanged(Ploeg value)
        {
            Title = "Spelers toewijzen aan " + value.Naam;
            BeschikbareSpelersOphalen();
            SpelersInPloegOphalen();
        }

        [RelayCommand]
        private void DragStarted(Speler speler)
        {
            ItemBeingDragged = speler;
        }

        public void BeschikbareSpelersOphalen()
        {
            BeschikbareSpelers = new ObservableCollection<Speler>(_spelerPloegRepository.BeschikbareSpelersOphalen(Ploeg));
        }
        public void SpelersInPloegOphalen()
        {
            SpelersInPloeg = new ObservableCollection<Speler>(_spelerPloegRepository.SpelersInPloegOphalen(Ploeg));
        }

        [RelayCommand]
        public void SpelerInPloegPlaatsen()
        {
            var result = _spelerPloegRepository.SpelerInPloegPlaatsen(ItemBeingDragged, Ploeg);

            if (result)
            {
                BeschikbareSpelersOphalen();
                SpelersInPloegOphalen();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van de speler aan de ploeg", "OK");
            }
        }

        [RelayCommand]
        public async Task SpelerUitPloegHalen()
        {
            var result = _spelerPloegRepository.SpelerUitPloegHalen(ItemBeingDragged, Ploeg);

            if (result)
            {
                BeschikbareSpelersOphalen();
                SpelersInPloegOphalen();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van de speler uit de ploeg", "OK");
            }
        }
    }
}
