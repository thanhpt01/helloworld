using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication2
{
    class MyViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public MyViewModel()
        {
            Persons = new ObservableCollection<Person>
        {
            new Person{Name="Eros"},
            new Person{Name="Tethys"},
            new Person{Name="Atlas"},
            new Person{Name="Apollo"},
            new Person{Name="Hades"},
        };

            DeleteCommand = new RelayCommand<Person>(
                (p) => p != null, // CanExecute()
                (p) => Persons.Remove(p) // Execute()
                );
            AddCommand = new RelayCommand<string>(
                (s) => true, // CanExecute()
                (s) => Persons.Add(new Person { Name = s }) // Execute()
                );
        }
    }

    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
