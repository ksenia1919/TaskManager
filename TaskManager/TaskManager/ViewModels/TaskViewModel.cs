using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private ObservableCollection<string> _sortCategories;
        public ObservableCollection<string> SortCategories
        {
            get { return _sortCategories; }
            set
            {
                _sortCategories = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                SortTasksByCategory(_selectedCategory);
            }
        }

        private bool _isCategorySelected;
        public bool IsCategorySelected
        {
            get { return _isCategorySelected; }
            set
            {
                _isCategorySelected = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
            SortCategories = new ObservableCollection<string>
            {
                "Все",
                "Названию",
                "Приоритету",
                "Дате",
                "Категории"
            };
            Categories = new ObservableCollection<string>
            {
                "Дом",
                "Работа",
                "Личное"
                // Добавьте другие категории по необходимости 
            };
        }

        // Методы для добавления, удаления, редактирования задач и загрузки/сохранения данных 

        public void SearchTasks(string searchText)
        {
            // Реализуйте логику поиска задач в Tasks по тексту searchText
            // Обновите Tasks, чтобы отобразить результаты поиска в DataGrid
        }


        private void SortTasks(string sortCategory)
        {
            switch (sortCategory)
            {
                case "Названию":
                    Tasks = new ObservableCollection<Task>(Tasks.OrderBy(t => t.Name));
                    break;
                case "Приоритету":
                    Tasks = new ObservableCollection<Task>(Tasks.OrderBy(t => t.Priority).ThenBy(t => t.IsCompleted));
                    break;
                case "Дате":
                    Tasks = new ObservableCollection<Task>(Tasks.OrderBy(t => t.DueDate));
                    break;
                case "Категории":
                    IsCategorySelected = true;
                    break;
                default:
                    Tasks = new ObservableCollection<Task>(Tasks);
                    break;
            }
        }

        private void SortTasksByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                Tasks = new ObservableCollection<Task>(Tasks);
                return;
            }

            Tasks = new ObservableCollection<Task>(Tasks.Where(t => t.Category == category).OrderBy(t => t.Name));
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
