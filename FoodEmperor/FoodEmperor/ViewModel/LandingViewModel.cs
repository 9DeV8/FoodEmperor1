using System;
using FoodEmperor.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FoodEmperor.Views;

namespace FoodEmperor.ViewModel
{
    class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            pizzas = GetPizzas();
        }


        public ObservableCollection<pizza> pizzas { get; set; }

        public ObservableCollection<pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                pizzas = value;
                OnPropertyChanged();
            }
        }

        private pizza selectedPizza;

        public pizza SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayPizza);

        private void DisplayPizza()
        {
            if (selectedPizza != null)
            {
                var viewModel = new DetailsViewModel { SelectedPizza = selectedPizza, Pizzas = pizzas, Position = pizzas.IndexOf(selectedPizza) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<pizza> GetPizzas()
        {
            return new ObservableCollection<pizza>
            {
                new pizza{ Name = "MARGERITA", Price = 12.99f, Image = "pizza_1.JPG", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new pizza { Name = "CAPRICIOSA", Price = 19.99f, Image = "pizza_2.JPG", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new pizza { Name = "HAWAJSKA", Price = 17.29f, Image = "pizza_3.JGP", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new pizza { Name = "KEBAB", Price = 15.99f, Image = "pizza_4.JPG", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new pizza { Name = "MIĘSNA", Price = 11.99f, Image = "meat.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new pizza { Name = "BBQ", Price = 13.99f, Image = "bbq.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}
            };
        }
    }
}
