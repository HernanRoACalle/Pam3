using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace AppBindingCommands.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string name = string.Empty;
        private string displayMessage = string.Empty;

        public string Name
        {
            get => name;
            set
            {
                if (name == null)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }
        public string DisplayName => $"O nome digitado:{name}";

        public string DisplayMessage {
            get => displayMessage;
            set {
                if (displayMessage == null)
                    return;
                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }
        
        public ICommand ShowMessageCommand { get;}
        public void ShowMessage()
        {
            DateTime data = Preferences.Get("dtAtual", DateTime.MinValue);
            DisplayMessage = $"Boa Noite {name}, Hoje é {data}";
        }
        public UsuarioViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async () => await CountCharacters());
            CleanCommand = new Command(async () => await CleanConfirmation());
        }

        public async Task CountCharacters()
        {
            string nameLenght = String.Format("Seu nome tem {0} letras", name.Length);
            await Application.Current.MainPage.DisplayAlert("Informação", nameLenght, "ok");
        }
        public ICommand CountCommand { get;}

        public async Task CleanConfirmation()
        {
            if (await Application.Current.MainPage.DisplayAlert("confirmacao", "confirma limapeza de dados?", "yes", "no")){
                Name = String.Empty;
                DisplayMessage = String.Empty;
                OnPropertyChanged(Name);
                OnPropertyChanged(DisplayMessage);

                await Application.Current.MainPage.DisplayAlert("Informação", "Limpeza realizada com sucesso", "ok");
            }
        }
        public ICommand CleanCommand{ get;}

    }
}
