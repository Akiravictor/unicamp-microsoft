using MediaPlayer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Service.Interfaces
{
	public interface IMediaControlService
	{
		void LoadFiles(string[] files);

		bool IsPlaylistEmpty();

		Media? GetFirstPlaylistItem();

		List<Media> GetPlaylist();

		void ResetPlaylistIndex();

		Media? GetNextItem(bool isRandom);

		Media? GetPreviousItem(bool isRandom);

		Media GetMediaDetails(string filePath);

	}
}
