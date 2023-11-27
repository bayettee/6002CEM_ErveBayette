
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace StudyGuide
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public ObservableCollection<StudyTask> StudyItems { get; set; } = new ObservableCollection<StudyTask>();

        public MainPage()
        {
            InitializeComponent();
            StudyItems.Add(new StudyTask { TaskName = "Study Task 1", Priority = "High" });
            StudyItems.Add(new StudyTask { TaskName = "Study Task 2", Priority = "Medium" });
            BindingContext = this; // Set BindingContext to the instance of MainPage
        }

      

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            string newTask = NewTaskEntry.Text;
            DateTime dueDate = DueDatePicker.Date;
            string priority = PriorityPicker.SelectedItem as string;

            StudyItems.Add(new StudyTask { TaskName = newTask, DueDate = dueDate, Priority = priority });

            NewTaskEntry.Text = "";
            DueDatePicker.Date = DateTime.Now; // Reset DatePicker
            PriorityPicker.SelectedIndex = -1; // Reset PriorityPicker

            OnPropertyChanged(nameof(StudyItems)); // Refresh the ListView
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var task = (StudyTask)button.BindingContext;

            StudyItems.Remove(task);
            OnPropertyChanged(nameof(StudyItems)); // Refresh the ListView
        }

        private void OnOpenNotesClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotesPage());
        }

        private void OnSortTasksClicked(object sender, EventArgs e)
        {
            // Sort tasks by priority
            StudyItems = new ObservableCollection<StudyTask>(StudyItems.OrderBy(task => task.Priority));
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

        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }

        public StudyTask()
        {
            
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
