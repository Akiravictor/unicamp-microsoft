using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaPlayer.Domain.Model;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using MediaPlayer.Service.Interfaces;
using System.IO;

namespace MediaPlayer.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IMediaControlService _mediaControlService;

		private string lenght = "00:00:00";
		private string musicName = "";

		private bool mediaPlayerIsPlaying = false;
		private bool userIsDraggingSlider = false;
		public bool Repeat = false;
		public bool Random = false;

		public MainWindow(IMediaControlService mediaControlService)
		{
			_mediaControlService = mediaControlService ?? throw new ArgumentNullException(nameof(mediaControlService));

			InitializeComponent();


			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();

			Repeat = false;
			Random = false;

			mePlayer.MediaEnded += MePlayer_MediaEnded;

		}

		private void MePlayer_MediaEnded(object sender, RoutedEventArgs e)
		{
			if (Repeat)
			{
				mePlayer.Position = TimeSpan.Zero;
			}
			else
			{
				var media = _mediaControlService.GetNextItem(Random) ?? throw new ArgumentNullException(nameof(_mediaControlService.GetNextItem));

				mePlayer.Source = new Uri(media.FilePath);
			}

		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
			{
				sliProgress.Minimum = 0;
				sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
				sliProgress.Value = mePlayer.Position.TotalSeconds;
			}
		}

		private void OpenFile(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Media Files (*.mp3; *.mpg; *.mpeg; *.mp4; *.mkv; *.avi)|*.mp3; *.mpg;*.mpeg;*.mp4;*.mkv;*.avi|All files (*.*)|*.*";
			fileDialog.Multiselect = true;

			if (fileDialog.ShowDialog() == true)
			{
				_mediaControlService.LoadFiles(fileDialog.FileNames);
				playlistItems.ItemsSource = _mediaControlService.GetPlaylist();
				playlistItems.Items.Refresh();
			}

			if (mediaPlayerIsPlaying)
			{
				mePlayer.Stop();
				mediaPlayerIsPlaying = false;

			}

		}

		private void OpenPlaylist(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "INF0997 Playlist File (*.plst)|*.plst";

			if(fileDialog.ShowDialog() == true)
			{
				var playlist = File.ReadAllText(fileDialog.FileName);
				_mediaControlService.LoadPlaylist(playlist);

				playlistItems.ItemsSource = _mediaControlService.GetPlaylist();
				playlistItems.Items.Refresh();
			}

			if (mediaPlayerIsPlaying)
			{
				mePlayer.Stop();
				mediaPlayerIsPlaying = false;

			}
		}

		private void SavePlaylist(object sender, RoutedEventArgs e)
		{
			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.Filter = "INF0997 Playlist File (*.plst)|*.plst";

			if(fileDialog.ShowDialog() == true)
			{
				var playlist = _mediaControlService.SavePlaylist();
				File.WriteAllText(fileDialog.FileName, playlist);
			}
		}

		private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (mePlayer != null) && !_mediaControlService.IsPlaylistEmpty();
		}

		private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			if (!mediaPlayerIsPlaying)
			{
				var media = _mediaControlService.GetFirstPlaylistItem() ?? throw new ArgumentNullException();
				mePlayer.Source = new Uri(media.FilePath);
				lenght = $"{media.Duration.Hours.ToString("00")}:{media.Duration.Minutes.ToString("00")}:{media.Duration.Seconds.ToString("00")}";
			}

			mePlayer.Play();
			mediaPlayerIsPlaying = true;
		}

		private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = mediaPlayerIsPlaying;
		}

		private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			mePlayer.Pause();
		}

		private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = mediaPlayerIsPlaying;
		}

		private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			mePlayer.Stop();
			mediaPlayerIsPlaying = false;
			_mediaControlService.ResetPlaylistIndex();
		}

		private void Has_NextTrack(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NextTrack(object sender, ExecutedRoutedEventArgs e)
		{
			var media = _mediaControlService.GetNextItem(Random) ?? throw new ArgumentNullException();
			mePlayer.Source = new Uri(media.FilePath);
			lenght = $"{media.Duration.Hours.ToString("00")}:{media.Duration.Minutes.ToString("00")}:{media.Duration.Seconds.ToString("00")}";
		}

		private void Has_PreviousTrack(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void PreviousTrack(object sender, ExecutedRoutedEventArgs e)
		{
			var media = _mediaControlService.GetPreviousItem(Random) ?? throw new ArgumentNullException();
			mePlayer.Source = new Uri(media.FilePath);
			lenght = $"{media.Duration.Hours.ToString("00")}:{media.Duration.Minutes.ToString("00")}:{media.Duration.Seconds.ToString("00")}";
		}

		private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
		{
			userIsDraggingSlider = true;
		}

		private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			userIsDraggingSlider = false;
			mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
		}

		private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			lblProgressStatus.Text = $"{TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss")} / {lenght}";
		}

		private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
		}

		private void ToggleRepeat(object sender, RoutedEventArgs e)
		{
			Repeat = !Repeat;
		}

		private void ToggleRandom(object sender, RoutedEventArgs e)
		{
			Random = !Random;
		}

		private void media_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			_ = sender ?? throw new ArgumentNullException(nameof(sender));

			var items = sender as ListBox;
			var selectedItem = items!.SelectedItems[0] as Media;

			_mediaControlService.GoToSelectedMedia(selectedItem);

			mePlayer.Source = new Uri(selectedItem.FilePath);

			lenght = $"{selectedItem.Duration.Hours.ToString("00")}:{selectedItem.Duration.Minutes.ToString("00")}:{selectedItem.Duration.Seconds.ToString("00")}";
			


		}
	}
}
