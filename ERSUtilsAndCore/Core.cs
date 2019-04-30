using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using ERSUtilsAndCore;

namespace ERSUtilsAndCore.Core
{
	class Game
	{

	}

	class Deck
	{
		public Card[] cards = new Card[52];

		public Deck()
		{
			GenerateDeck();
		}

		private void GenerateDeck()
		{
			for (int s = 1; s < 5; s++)
			{
				for (int id = 1; id < 14; id++)
				{

				}
			}
		}
	}

	class Hand
	{
		public List<Card> cards = new List<Card>();
	}
	enum Suit
	{
		clubs = 1, diamonds = 2, hearts, spades
	}

	class Card
	{
		public Suit suit;
		public int ID; //1 = ace, 11 = jack, 12 = queen, 13 = king

		/// <summary>
		/// Card Constructor
		/// </summary>
		/// <param name="suit">The suit of a card</param>
		/// <param name="ID">1 = ace, 11 = jack, 12 = queen, 13 = king</param>
		public Card(Suit suit, int ID)
		{
			this.suit = suit;
			this.ID = ID;
		}
		
		public override string ToString()
		{
			string output = ID >= 2 && ID <= 10 ? "_" : ""; //if it is a number card start it with an _
			if (ID >= 2 && ID <= 10)
			{
				output += ID.ToString() + "_of_";
			}
			else
			{
				switch (ID)
				{
					case 1:
						output += "ace_of_";
						break;
					case 11:
						output += "jack_of_";
						break;
					case 12:
						output += "queen_of_";
						break;
					case 13:
						output += "king_of_";
						break;
				}
			}
			output += suit.ToString();
			return output + (ID >= 1 && ID <= 10 ? "" : "2");
		}
		public Bitmap GetCardImage()
		{
			UnmanagedMemoryStream ms = new ResourceManager(ToString(), Assembly.GetExecutingAssembly()).GetStream(ToString());
			Bitmap output = (Bitmap)Image.FromStream(ms);
			return output;
		}
	}
}
