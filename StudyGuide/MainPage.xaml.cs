using System;
using System.Collections.ObjectModel;

namespace StudyGuide
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public ObservableCollection<string> StudyItems { get; set; } = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            StudyItems.Add("Study Task 1");
            StudyItems.Add("Study Task 2");
            // Add more initial study tasks later
        }

        

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            // Get the new task from the Entry
            string newTask = NewTaskEntry.Text;

            // Add the new task to the ObservableCollection
            StudyItems.Add(newTask);

            // Clear the Entry for the next task
            NewTaskEntry.Text = "";
        }
    }
}


