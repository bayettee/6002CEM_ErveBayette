
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace StudyGuide
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<StudyTask> StudyItems { get; set; } = new ObservableCollection<StudyTask>();

        public MainPage()
        {
            InitializeComponent();
            StudyItems.Add(new StudyTask { TaskName = "Study Task 1" });
            StudyItems.Add(new StudyTask { TaskName = "Study Task 2" });
            BindingContext = this; // Set BindingContext to the instance of MainPage
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            string newTask = NewTaskEntry.Text;
            DateTime dueDate = DueDatePicker.Date;

            StudyItems.Add(new StudyTask { TaskName = newTask, DueDate = dueDate });

            NewTaskEntry.Text = "";
            DueDatePicker.Date = DateTime.Now; // Reset DatePicker

            OnPropertyChanged(nameof(StudyItems)); // Refresh the ListView
        }
    }

    public class StudyTask : System.ComponentModel.INotifyPropertyChanged
    {
        private string taskName;
        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        public ICommand DeleteCommand { get; set; }

        public StudyTask()
        {
            DeleteCommand = new Command(OnDelete);
        }

        private void OnDelete()
        {
            // Access the StudyItems collection from the MainPage class
            var mainPage = (MainPage)App.Current.MainPage;
            mainPage.StudyItems.Remove(this);
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
