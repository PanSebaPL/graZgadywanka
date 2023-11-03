namespace graZgadywanka
{
    public partial class MainPage : ContentPage
    {
        int Value = 250;
        int Steps = 0;
        int ToGuess;
        int CompGuess; int CompPrevGuess;
        int CompGuessAmount = 1;
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
                LblHumanRange.Text ="Zakres 0-"+Value.ToString();
                Random rnd = new Random();
                ToGuess = rnd.Next(1, Value);
                SemanticScreenReader.Announce(LblHumanRange.Text);
                BtnHumanConfirm.IsVisible = true;
                BtnHumanRestart.IsVisible = false;
                LblHumanOutput.Text = "";
                LblHumanCounter.Text = "0";
                Steps = 0;
                SemanticScreenReader.Announce(LblHumanOutput.Text);
                Guesser.Text = "Zgaduje człowiek";
                SemanticScreenReader.Announce(Guesser.Text);
            }
            if(RdbComp.IsChecked)
            {
                LblComputerCounter.Text = "Ilosc krokow: " + CompGuessAmount.ToString();
                CompGuess = Value / 2;
                CompPrevGuess = Value;
                MenuStart.IsVisible =false;
                GameComputerGuesser.IsVisible = true;
                LblComputerOutput.Text = "Liczba podana przez komputer:" + CompGuess;
                SemanticScreenReader.Announce(LblComputerOutput.Text);
                Guesser.Text = "Zgaduje komputer";
                SemanticScreenReader.Announce(Guesser.Text);
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
            EntHumanRange.Text = "";
            MenuStart.IsVisible = true;
            GameHumanGuesser.IsVisible = false;
            BtnHumanRestart.IsVisible = false;
            GameComputerGuesser.IsVisible = false;
            BtnComputerRestart.IsVisible = false;
            Guesser.Text = "Kto zgaduje?";
            CompGuessAmount = 1;
            SemanticScreenReader.Announce(Guesser.Text);
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
            if (RdbCompBig.IsChecked)
            {
                //CompGuess = (Value - CompGuess) / 2;
                CompPrevGuess = CompGuess;
                CompGuess = CompGuess / 2;
                CompGuessAmount++;
                LblComputerCounter.Text = "Ilosc krokow: " + CompGuessAmount.ToString();
                RdbCompSmall.IsChecked = false;
                RdbCompBig.IsChecked = false;
                RdbCompEqual.IsChecked = false;
                LblComputerOutput.Text = "Liczba podana przez komputer:" + CompGuess;
            }
            if (RdbCompEqual.IsChecked)
            {
                LblComputerOutput.Text = "Koniec Gry!";
                BtnCompConfirm.IsVisible = false;
                RdbCompSmall.IsChecked = false;
                RdbCompBig.IsChecked = false;
                RdbCompEqual.IsChecked = false;
                BtnComputerRestart.IsVisible = true;
                SemanticScreenReader.Announce(LblComputerOutput.Text);
            }
            if (RdbCompSmall.IsChecked)
            {
                //CompGuess = (Value + CompGuess) / 2;
                CompGuess = (CompPrevGuess + CompGuess) / 2;
                CompGuessAmount++;
                LblComputerCounter.Text = "Ilosc krokow: " + CompGuessAmount.ToString();
                RdbCompSmall.IsChecked = false;
                RdbCompBig.IsChecked = false;
                RdbCompEqual.IsChecked = false;
                LblComputerOutput.Text = "Liczba podana przez komputer:" + CompGuess;
            }
        }
        //100 200
        //50 100
        //75 50


    }
}