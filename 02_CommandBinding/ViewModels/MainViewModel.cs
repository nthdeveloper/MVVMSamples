using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMSamples.Models;
using MVVMSamples.Utils;
using MVVMSamples.Commands;

namespace MVVMSamples.ViewModels
{
    public class MainViewModel
    {
        public string Title { get; set; }
        public string NameColumnHeader { get; set; }
        public string SurnameColumnHeader { get; set; }
        public string BirthDateColumnHeader { get; set; }

        public ObservableCollection<Person> PersonList { get; private set; }

        public Person SelectedPerson { get; set; }

        public ICommand RemoveCommand { get; private set; }

        public MainViewModel()
        {
            this.Title = "Person Management Application";
            this.NameColumnHeader = "Name";
            this.SurnameColumnHeader = "Surname";
            this.BirthDateColumnHeader = "Date of Birth";
            this.PersonList = new ObservableCollection<Person>();

            this.RemoveCommand = new RelayCommand<object>(executeRemoveCommand, null, "Remove");

            fillTestData();
        }

        private void fillTestData()
        {
            this.PersonList.Add(new Person() { Id = 1, Name = "Name 1", Surname = "Surname 1", BirthDate = new DateTime(1982, 1, 1) });
            this.PersonList.Add(new Person() { Id = 2, Name = "Name 2", Surname = "Surname 2", BirthDate = new DateTime(1983, 1, 1) });
            this.PersonList.Add(new Person() { Id = 3, Name = "Name 3", Surname = "Surname 3", BirthDate = new DateTime(1984, 1, 1) });
            this.PersonList.Add(new Person() { Id = 4, Name = "Name 4", Surname = "Surname 4", BirthDate = new DateTime(1985, 1, 1) });
        }

        private void executeRemoveCommand(object arg)
        {
            if (SelectedPerson == null)
                MessageBoxHelper.Show("Select a person to remove!");
            else
            {
                var _questionResult = MessageBoxHelper.Show("Do you want to remove the selected person?","", System.Windows.MessageBoxButton.YesNo);
                if(_questionResult == System.Windows.MessageBoxResult.Yes)
                {
                    this.PersonList.Remove(this.SelectedPerson);
                }
            }
        }
    }
}
