using JewelCollector.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCollector.Jewels
{
	public abstract class Jewel
	{
        /// <summary>
        /// Stores the X position of a <typeparamref name="Jewel" /> in the Grid.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Stores the Y position of a <typeparamref name="Jewel" /> in the Grid.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Stores the Value of a <typeparamref name="Jewel" />.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Stores the Symbol of a <typeparamref name="Jewel" />.
        /// </summary>
        public string Symbol { get; private set; } = "";

		public EnumColor Color { get; private set; }

		/// <summary>
		/// Constructor for <typeparamref name="Jewel" />.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="value"></param>
		/// <param name="color"></param>
		public Jewel(int x, int y, int value, EnumColor color)
		{
			X = x;
			Y = y;
			Value = value;
			Color = color;

			switch (color)
			{
				case EnumColor.Red:
					Symbol = Symbols.RedJewel;
					break;

				case EnumColor.Blue:
					Symbol = Symbols.BlueJewel;
					break;

				case EnumColor.Green:
					Symbol = Symbols.GreenJewel;
					break;
			}
		}

	}
}
