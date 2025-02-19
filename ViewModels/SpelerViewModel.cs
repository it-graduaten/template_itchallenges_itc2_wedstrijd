﻿

namespace ITC2Wedstrijd.ViewModels
{
    public partial class SpelerViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Speler> spelers;

        private SpelerRepository _spelerRepository;

        [ObservableProperty]
        private Array geslacht;

        [ObservableProperty]
        public Speler selectedSpeler;
        public SpelerViewModel(SpelerRepository spelerRepository)
        {
            _spelerRepository = spelerRepository;
            RefreshCategoriën();
            Geslacht = typeof(Geslacht).GetEnumValues();
            selectedSpeler = new Speler();
            Title = "Spelers";
        }

        [ObservableProperty]
        public string actieLabel = "Nieuwe speler toevoegen";

        partial void OnSelectedSpelerChanged(Speler value)
        {
            if (value.Id == 0)
            {
                ActieLabel = "Nieuwe speler toevoegen";
            }
            else
            {
                ActieLabel = "Speler wijzigen";
            }
        }


        private void RefreshCategoriën()
        {
            Spelers = new ObservableCollection<Speler>(_spelerRepository.SpelerOphalen());
        }

        [RelayCommand]
        public void Toevoegen()
        {
            var result = _spelerRepository.ToevoegenSpeler(SelectedSpeler);

            if (result)
            {
                RefreshCategoriën();
                SelectedSpeler = new Speler();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van de speler", "OK");
            }
        }


        [RelayCommand]
        public void Wijzigen()
        {
            var result = _spelerRepository.WijzigenSpeler(SelectedSpeler);

            if (result)
            {
                RefreshCategoriën();
                SelectedSpeler = new Speler();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het wijzigen van de speler", "OK");
            }
        }


        [RelayCommand]
        public void Verwijderen()
        {
            var result = _spelerRepository.VerwijderenSpeler(SelectedSpeler.Id);

            if (result)
            {
                RefreshCategoriën();
                SelectedSpeler = new Speler();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van de speler", "OK");
            }
        }

        [RelayCommand]
        public void Deselecteren()
        {
            SelectedSpeler = new Speler();
        }
    }
}