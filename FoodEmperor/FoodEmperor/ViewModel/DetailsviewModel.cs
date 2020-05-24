using FoodEmperor.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodEmperor.ViewModel
{
    class DetailsViewModel : BaseViewModel
    {


        ObservableCollection<pizza> pizzas;
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

        private int position;
        public int Position
        {
            get
            {
                if (position != pizzas.IndexOf(selectedPizza))
                    return pizzas.IndexOf(selectedPizza);

                return position;
            }
            set
            {
                position = value;
                selectedPizza = pizzas[position];

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedPizza));
            }
        }

        public ICommand ChangePositionCommand => new Command(ChangePosition);

        private void ChangePosition(object obj)
        {
            string direction = (string)obj;

            if (direction == "L")
            {
                if (position == 0)
                {
                    Position = pizzas.Count - 1;
                    return;
                }

                Position -= 1;
            }
            else if (direction == "R")
            {
                if (position == pizzas.Count - 1)
                {
                    Position = 0;
                    return;
                }

                Position += 1;
            }

        }
    }
}
