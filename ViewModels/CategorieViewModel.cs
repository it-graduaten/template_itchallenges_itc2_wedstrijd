﻿


using System.Globalization;
using System.Numerics;

namespace ITC2Wedstrijd.ViewModels
{
    public partial class CategorieViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Categorie> categoriën;

        private ICategorieRepository _categorieRepository;

        [ObservableProperty]
        private Array categorieType;

        [ObservableProperty]
        public Categorie selectedCategorie;
        public CategorieViewModel(CategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
            RefreshCategoriën();
            CategorieType = typeof(CategorieType).GetEnumValues();
            selectedCategorie = new Categorie();
            Title = "Categoriën";
        }

        [ObservableProperty]
        public string actieLabel = "Nieuwe categorie toevoegen";

        partial void OnSelectedCategorieChanged(Categorie value)
        {
            if (value.Id == 0)
            {
                ActieLabel = "Nieuwe categorie toevoegen";
            }
            else
            {
                ActieLabel = "Categorie wijzigen";
            }
        }


        private void RefreshCategoriën()
        {
            Categoriën = new ObservableCollection<Categorie>(_categorieRepository.CategorieOphalen());
        }

        [RelayCommand]
        public void Toevoegen()
        {
            var result = _categorieRepository.ToevoegenCategorie(selectedCategorie);

            if (result)
            {
                RefreshCategoriën();
                SelectedCategorie = new Categorie();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het toevoegen van de categorie", "OK");
            }
        }


        [RelayCommand]
        public void Wijzigen()
        {
            var result = _categorieRepository.WijzigenCategorie(selectedCategorie);

            if (result)
            {
                RefreshCategoriën();
                SelectedCategorie = new Categorie();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het wijzigen van de categorie", "OK");
            }
        }


        [RelayCommand]
        public void Verwijderen()
        {
            var result = _categorieRepository.VerwijderenCategorie(SelectedCategorie.Id);

            if (result)
            {
                RefreshCategoriën();
                SelectedCategorie = new Categorie();
            }
            else
            {
                Shell.Current.DisplayAlert("Fout", "Er is een fout opgetreden bij het verwijderen van de categorie", "OK");
            }
        }

        [RelayCommand]
        public void Deselecteren()
        {
            SelectedCategorie = new Categorie();
        }
    }
}