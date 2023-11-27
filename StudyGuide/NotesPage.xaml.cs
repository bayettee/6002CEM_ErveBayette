
using Microsoft.Maui.Controls;

namespace StudyGuide
{
    public partial class NotesPage : ContentPage
    {
        Editor notesEditor;

        public NotesPage()
        {
            InitializeComponent();
            notesEditor = new Editor();
            var saveButton = new Button { Text = "Save Notes", HorizontalOptions = LayoutOptions.CenterAndExpand };
            saveButton.Clicked += OnSaveNotesClicked;

            var backButton = new Button { Text = "Back to Tasks", HorizontalOptions = LayoutOptions.CenterAndExpand };
            backButton.Clicked += OnBackToMainClicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Study Notes", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    notesEditor,
                    saveButton,
                    backButton
                }
            };
        }

        private void OnSaveNotesClicked(object sender, EventArgs e)
        {
            string studyNotes = notesEditor.Text;

            // display an alert with the saved notes
            DisplayAlert("Notes Saved", studyNotes, "OK");
        }

        private void OnBackToMainClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
