
using System;
using System.Collections.ObjectModel;
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

        public StudyTask()
        {
            // You can add any additional initialization logic here
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
