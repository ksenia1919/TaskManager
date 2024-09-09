using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
        }

        // Методы для добавления, удаления, редактирования задач и загрузки/сохранения данных 
        // (реализуйте их в соответствии с функциональными требованиями)

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
