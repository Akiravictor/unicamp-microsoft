using MediaPlayer.Domain.Model;
using MediaPlayer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaPlayer.Service.Services
{
	public class MediaControlService : IMediaControlService
	{
		private List<Media> _playlist;
		private List<Media> _randomPlaylist;
		private static int currentIndex = 0;
		private static int randomIndex = 0;

		public MediaControlService()
		{
			_playlist = new List<Media>();
			_randomPlaylist = new List<Media>();
		}

		public void LoadFiles(string[] files)
		{
			int count = 1;
			_playlist.Clear();
			_randomPlaylist.Clear();

			foreach(var file in files)
			{
				using var tagFile = TagLib.File.Create(file);

				_playlist.Add(new Media
				{
					ListNumber = count,
					Title = tagFile.Tag.Title,
					Album = tagFile.Tag.Album,
					Author = tagFile.Tag.FirstPerformer,
					Genre = tagFile.Tag.FirstGenre,
					Duration = tagFile.Properties.Duration,
					FilePath = file.ToString()
				});

				count++;
			}

			Random r = new Random();
			_randomPlaylist = _playlist.OrderBy(a => r.Next()).ToList();
		}

		public bool IsPlaylistEmpty()
		{
			return !_playlist.Any();
		}

		public Media? GetFirstPlaylistItem()
		{
			if (_playlist.Any())
			{
				var first = _playlist[currentIndex];
				randomIndex = _randomPlaylist.IndexOf(first);

				return first;
			}

			return null;
		}

		public List<Media> GetPlaylist()
		{
			return _playlist;
		}

		public void ResetPlaylistIndex()
		{
			currentIndex = 0;
		}

		public Media? GetNextItem(bool isRandom)
		{
			Media next;

			if (isRandom)
			{
				randomIndex++;

				if(randomIndex >= _randomPlaylist.Count)
				{
					randomIndex = 0;
				}

				next = _randomPlaylist[randomIndex];
				currentIndex = _playlist.IndexOf(next);
			}
			else
			{
				currentIndex++;

				if(currentIndex >= _playlist.Count)
				{
					currentIndex = 0;
				}

				next = _playlist[currentIndex];
				randomIndex = _randomPlaylist.IndexOf(next);
			}

			return next;
		}

		public Media? GetPreviousItem(bool isRandom)
		{
			Media previous;

			if (isRandom)
			{
				randomIndex--;

				if(randomIndex < 0)
				{
					randomIndex = _randomPlaylist.Count - 1;
				}

				previous = _randomPlaylist[randomIndex];
				currentIndex = _playlist.IndexOf(previous);
			}
			else
			{
				currentIndex--;

				if(currentIndex < 0)
				{
					currentIndex = _playlist.Count - 1;
				}

				previous = _playlist[currentIndex];
				randomIndex = _randomPlaylist.IndexOf(previous);

			}

			return previous;
		}

		public void GoToSelectedMedia(Media item)
		{
			currentIndex = _playlist.IndexOf(item);
			randomIndex = _randomPlaylist.IndexOf(item);
		}

		public Media GetMediaDetails(string filePath)
		{
			return new Media();
		}

		public string SavePlaylist()
		{
			return JsonSerializer.Serialize(_playlist);
		}

		public void LoadPlaylist(string json)
		{
			_ = _playlist ?? throw new InvalidOperationException("Error on loading playlist.");
			_ = string.IsNullOrEmpty(json) ? throw new ArgumentNullException(nameof(json)) : "";

			_playlist = JsonSerializer.Deserialize<List<Media>>(json);

			Random r = new Random();
			_randomPlaylist = _playlist.OrderBy(a => r.Next()).ToList();


		}
	}
}
