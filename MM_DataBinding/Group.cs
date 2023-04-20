using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MM_DataBinding
{
    public class Group : INotifyPropertyChanged
    {
        private string _num;
        private int _year;
        private string _spec;
        private string _department;
        private string _level;

        [DisplayName("Номер группы")]
        public string Num
        {
            get => _num;
            set
            {
                _num = value;
                OnPropertyChanged(nameof(Num));
            }
        }
        [DisplayName("Год поступления")]
        public int Year { 
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }
        [DisplayName("Направление")]
        public string Spec { get => _spec;
            set
            {
                _spec = value;
                OnPropertyChanged(nameof(Spec));
            }
        }
        [DisplayName("Институт")]
        public string Department { get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }
        [DisplayName("Уровень образования")]
        public string Level { get => _level;
            set
            {
                if (value.ToUpper() != "БАКАЛАВРИАТ"
                    && value.ToUpper() != "МАГИСТРАТУРА"
                    && value.ToUpper() != "СПЕЦИАЛИТЕТ"
                   ) throw new Exception("Неверный уровень образования");
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CopyTo(Group grCopy)
        {
            grCopy.Num = Num;
            grCopy.Year = Year;
            grCopy.Spec = Spec;
            grCopy.Department = Department;
            grCopy.Level = Level;
        }
    }
}
