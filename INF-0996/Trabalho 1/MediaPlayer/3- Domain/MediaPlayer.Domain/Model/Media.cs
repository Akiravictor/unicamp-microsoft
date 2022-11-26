using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Domain.Model
{
	public class Media
	{
		public int ListNumber { get; set; }

		public string Title { get; set; }
		public string Author { get; set; }
		public string Album { get; set; }
		public string Genre { get; set; }
		public TimeSpan Duration { get; set; }

		public string FilePath { get; set; }

	}
}
