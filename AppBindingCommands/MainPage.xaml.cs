namespace AppBindingCommands
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void lblInformacoess_Clicked(object sender, EventArgs e)
        {
            string informacoes = string.Empty;

            if (Preferences.ContainsKey("AcaoInicial"))
                informacoes += Preferences.Get("AcaoInicial", String.Empty);

            if (Preferences.ContainsKey("AcaoStart"))
                informacoes += Preferences.Get("AcaoStart", String.Empty);

            if (Preferences.ContainsKey("AcaoSleep"))
                informacoes += Preferences.Get("AcaoSleep", String.Empty);

            if (Preferences.ContainsKey("AcaoResume"))
                informacoes += Preferences.Get("AcaoResume", String.Empty);

            lblInformacoes.Text = informacoes;
        }
    }
}
