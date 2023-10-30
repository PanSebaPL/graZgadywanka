namespace graZgadywanka
{
    public partial class MainPage : ContentPage
    {
        int Value = 500;
        int Steps = 0;
        int ToGuess;
        public MainPage()
        {
            InitializeComponent();
            
        }
        
        private void OnSldRangeChanged(object sender, EventArgs e)
        {
            Value = (int)SldRange.Value;
            SldValueLbl.Text="Zakres 0-"+Value.ToString();
        }
        private void GameStartClick(object sender, EventArgs e)
        {
            if (RdbHumn.IsChecked)
            {
                MenuStart.IsVisible = false;
                GameHumanGuesser.IsVisible = true;
                LblHumanRange.Text += Value.ToString();
                Random rnd = new Random();
                ToGuess = rnd.Next(1, Value);
                SemanticScreenReader.Announce(LblHumanRange.Text);
                BtnHumanConfirm.IsVisible = true;
                BtnHumanRestart.IsVisible = false;
                LblHumanOutput.Text = "";
                LblHumanCounter.Text = "0";
                Steps = 0;
                SemanticScreenReader.Announce(LblHumanOutput.Text);
            }
            if(RdbComp.IsChecked)
            {
                MenuStart.IsVisible =false;
                GameComputerGuesser.IsVisible = true;

            }
        }
        private void OnHumanConfirmClicked(object sender, EventArgs e)
        {
            int Guess;
            if (EntHumanRange==null||int.TryParse(EntHumanRange.Text, out Guess)==false)
            {
                LblHumanOutput.Text = "Podano zła wartosc";
            }
            else
            {
                Steps++; LblHumanCounter.Text = "Kroki: "+Steps.ToString();
                LblHumanOutput.Text = "Twoja liczba to: " + Guess.ToString() + ", ";
                if (Guess < ToGuess)
                    LblHumanOutput.Text += "Za mala";

                if (Guess > ToGuess)
                    LblHumanOutput.Text += "Za duza";
                if (Guess == ToGuess)
                {
                    LblHumanOutput.Text += "ZGADLES!";
                    BtnHumanConfirm.IsVisible = false;
                    BtnHumanRestart.IsVisible = true;
                }
                 
            }
            SemanticScreenReader.Announce(LblHumanCounter.Text);
            SemanticScreenReader.Announce(LblHumanOutput.Text);
        }
        private void HumanRestart(object sender, EventArgs e)
        {
            MenuStart.IsVisible = true;
            GameHumanGuesser.IsVisible = false;
            BtnHumanRestart.IsVisible = false;
        }
        private void OnCompSelect(object sender, EventArgs e)
        {
            if(RdbCompSmall.IsChecked||RdbCompBig.IsChecked||RdbCompEqual.IsChecked)
            {
                BtnCompConfirm.IsVisible = true;
            }
            else
            {
                BtnCompConfirm.IsVisible = false;
            }
        }
        private void OnCompConfirm(object sender, EventArgs e)
        {

        }


    }
}