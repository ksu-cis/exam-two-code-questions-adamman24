using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : INotifyPropertyChanged, IOrderItem
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public FruitFilling fruit;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit
        {
            get => fruit;
            set
            {
                fruit = value;
                NotifyOfPropertyChange("Fruit");
            }
        }

        public bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream 
        {
            get
            {
                return withIceCream;
            }
            set
            {
                withIceCream = value;
                NotifyOfPropertyChange("withIceCream");
            }
        } 

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        /// <summary>
        /// if property changes it will update here
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyOfPropertyChange(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }
    }
}
