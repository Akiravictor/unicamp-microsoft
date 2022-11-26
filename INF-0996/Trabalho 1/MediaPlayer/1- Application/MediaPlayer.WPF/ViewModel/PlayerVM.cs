using MediaPlayer.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.WPF.ViewModel
{
	public class PlayerVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private string windowTitle = "";

		public string WindowTitle
		{ 
			get { return windowTitle; } 
			set 
			{ 
				windowTitle = value;
				OnPropertyChanged("WindowTitle");
			} 
		}

		private string duration = "";

		public string Duration
		{
			get { return duration; }
			set
			{
				duration = value;
				OnPropertyChanged("Duration");
			}
		}

		public List<Media> Playlist;
	}
}
