using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSamples.Models
{
    public class Person : INotifyPropertyChanged
    {
        string m_Name;
        string m_Surname;
        DateTime m_BirthDate;

        public int Id { get; set; }
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (value == m_Name)
                    return;

                m_Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return m_Surname; }
            set
            {
                if (value == m_Surname)
                    return;

                m_Surname = value;
                RaisePropertyChanged(nameof(Surname));
            }
        }

        public DateTime BirthDate
        {
            get { return m_BirthDate; }
            set
            {
                if (value == m_BirthDate)
                    return;

                m_BirthDate = value;
                RaisePropertyChanged(nameof(BirthDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var _ev = PropertyChanged;
            if (_ev != null)
                _ev(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
