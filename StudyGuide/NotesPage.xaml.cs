
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

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Study Notes", HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand },
                    notesEditor,
                    saveButton
                }
            };
        }

        private void OnSaveNotesClicked(object sender, EventArgs e)
        {
            string studyNotes = notesEditor.Text;

            // an alert with the saved notes
            DisplayAlert("Notes Saved", studyNotes, "OK");
        }
    }
}
