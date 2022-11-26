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
			else if (Random)
			{

			}
			else
			{
				var media = _mediaControlService.GetNextItem() ?? throw new ArgumentNullException(nameof(_mediaControlService.GetMediaDetails));

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

			}
		}

		private void SavePlaylist(object sender, RoutedEventArgs e)
		{
			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.Filter = "INF0997 Playlist File (*.plst)|*.plst";

			if(fileDialog.ShowDialog() == true)
			{
				File.WriteAllText(fileDialog.FileName, "");
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
		}

		private void Has_PreviousTrack(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void PreviousTrack(object sender, ExecutedRoutedEventArgs e)
		{
			var media = _mediaControlService.GetPreviousItem(Random) ?? throw new ArgumentNullException();
			mePlayer.Source = new Uri(media.FilePath);
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
			lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
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
	}
}
