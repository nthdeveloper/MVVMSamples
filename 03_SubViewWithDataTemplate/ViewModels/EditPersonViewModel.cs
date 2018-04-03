using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMSamples.Commands;
using MVVMSamples.Models;

namespace MVVMSamples.ViewModels
{
    public class EditPersonViewModel : ViewModelBase
    {
        string m_PersonName;
        string m_PersonSurname;

        public string NameText { get; private set; }
        public string SurnameText { get; private set; }

        public Person Person { get; private set; }
        public string PersonName
        {
            get { return m_PersonName; }
            set
            {
                if (value == m_PersonName)
                    return;

                m_PersonName = value;
                RaisePropertyChanged(nameof(PersonName));
            }
        }
        public string PersonSurname
        {
            get { return m_PersonSurname; }
            set
            {
                if (value == m_PersonSurname)
                    return;

                m_PersonSurname = value;
                RaisePropertyChanged(nameof(PersonSurname));
            }
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public EditPersonViewModel(Person person)
        {
            this.Person = person;

            this.NameText = "Name";
            this.SurnameText = "Surname";

            readPersonValues();

            this.SaveCommand = new RelayCommand<object>(executeSaveCommand, null, "Save");
            this.CancelCommand = new RelayCommand<object>(executeCancelCommand, null, "Cancel");
        }

        private void executeSaveCommand(object arg)
        {
            //Apply changes
            this.Person.Name = m_PersonName;
            this.Person.Surname = m_PersonSurname;
        }

        private void executeCancelCommand(object arg)
        {
            //Reload person values
            readPersonValues();
        }

        private void readPersonValues()
        {
            //Read values from person object
            this.PersonName = this.Person.Name;
            this.PersonSurname = this.Person.Surname;
        }
    }
}
