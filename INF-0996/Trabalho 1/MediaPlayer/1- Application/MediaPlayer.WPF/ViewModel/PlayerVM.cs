using MediaPlayer.Domain.Model;
using MediaPlayer.Service.Interfaces;
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
		private readonly IMediaControlService _mediaControlService;

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

		private List<Media> playlist;

		public List<Media> Playlist
		{
			get { return playlist; }
			set
			{
				playlist = value;
				OnPropertyChanged("Playlist");
			}
		}

		public PlayerVM()
		{
			Playlist = new List<Media>();
			Playlist.Add(new Media
			{
				Title = "Batatatatata",
				ListNumber = 0
			});
			Playlist.Add(new Media
			{
				Title = "Bananananana",
				ListNumber = 0
			});
		}

		public void LoadPlaylist(List<Media> list)
		{
			Playlist = list;
		}
	}
}
