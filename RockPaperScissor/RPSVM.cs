using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RockPaperScissor
{
    class RPSVM : INotifyPropertyChanged
	{
		const int unsel = 0;
		const int rock = 1;
		const int paper = 2;
		const int scissor = 3;

		int usrSel=unsel;
		int compSel=unsel;
		bool vis = false;
		bool enable = true;
        bool buttonreplay = false;
		string src;
		string msg="Play the Game";

		public bool Vis
		{
			get{ return vis ; }
			set{ vis = value; OnPropertyChanged(); }
		}

		public bool Enable
		{
			get { return enable; }
			set { enable = value; OnPropertyChanged(); }
		}

        public bool EnableButtonReplay
        {
            get { return buttonreplay; }
            set { buttonreplay = value; OnPropertyChanged(); }
        }
        public string Src
		{
			get { return src; }
			set { src = value; OnPropertyChanged(); }
		}

		public string Msg
		{
			get { return msg; }
			set { msg = value; OnPropertyChanged(); }
		}

		public void ComputerMakesSelection()
		{
			Random rnd = new Random();
			compSel = rnd.Next(rock, scissor+1);
			if (compSel == rock)
				Src = "Rock.bmp";
			else if (compSel == paper)
				Src = "Paper.bmp";
			else if (compSel == scissor)
				Src = "Scissors.bmp";
		}

		public void GamePlay(int selection)
		{
			Enable = false;
            EnableButtonReplay = true;
			usrSel = selection;
			Vis = true;
			string UserWin = "You Win: ";
			string ComputerWin = "You Lose: ";
			if (usrSel == compSel)
				Msg = "Match Drawn.";
			else
			{
				if(usrSel==rock)
				{
					if(compSel==paper)
					{
						Msg = ComputerWin + " Paper Covers Rock.";
					}

					else if(compSel==scissor)
					{
						Msg = UserWin + " Rock Smashes Scissors.";
					}
				}
				else if(usrSel==paper)
				{
					if(compSel==rock)
					{
						Msg = UserWin + " Paper Covers Rock.";
					}

					else if(compSel==scissor)
					{
						Msg = ComputerWin + " Scissors Cuts Paper.";
					}
				}
				else if(usrSel==scissor)
				{
					if(compSel==rock)
					{
						Msg = ComputerWin + " Rock Smashes Scissors.";
					}

					else if(compSel==paper)
					{
						Msg = UserWin + " Scissors Cuts Paper.";
					}
				}
			}
		}

		public void Replay()
		{
			Enable = true;
            EnableButtonReplay = false;
			usrSel = unsel;
			compSel = unsel;
			Vis = false;
			Src = "No Selection";
			Msg = "";
			ComputerMakesSelection();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] String propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
