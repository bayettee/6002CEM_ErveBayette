
using Microsoft.Maui.Controls;
using System;
using System.Text;

namespace StudyGuide
{
    public partial class NotesPage : ContentPage
    {
        Editor notesEditor;
        StringBuilder savedNotes = new StringBuilder();

        public NotesPage()
        {
            InitializeComponent();
            notesEditor = new Editor();
            var saveButton = new Button { Text = "Save Notes", HorizontalOptions = LayoutOptions.CenterAndExpand };
            saveButton.Clicked += OnSaveNotesClicked;

            var viewButton = new Button { Text = "View Notes", HorizontalOptions = LayoutOptions.CenterAndExpand };
            viewButton.Clicked += OnViewNotesClicked;

            var backButton = new Button { Text = "Back to Tasks", HorizontalOptions = LayoutOptions.CenterAndExpand };
            backButton.Clicked += OnBackToMainClicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Study Notes", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    notesEditor,
                    saveButton,
                    viewButton,
                    backButton
                }
            };
        }

        private void OnSaveNotesClicked(object sender, EventArgs e)
        {
            string studyNotes = notesEditor.Text;

            // append the saved notes
            savedNotes.AppendLine(studyNotes);

            // display an alert with the saved notes
            DisplayAlert("Notes Saved", studyNotes, "OK");

            // clear the editor for new notes
            notesEditor.Text = "";
        }

        private void OnViewNotesClicked(object sender, EventArgs e)
        {
            // display an alert with all saved notes
            DisplayAlert("All Notes", savedNotes.ToString(), "OK");
        }

        private void OnBackToMainClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
