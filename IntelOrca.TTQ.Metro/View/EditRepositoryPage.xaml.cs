using IntelOrca.TTQ.Core;
using IntelOrca.TTQ.Metro.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IntelOrca.TTQ.Metro.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class EditRepositoryPage : Page
	{
		public App CurrentApp { get { return (App)App.Current; } }
		public EditRepositoryViewModel ViewModel { get { return (EditRepositoryViewModel)DataContext; } }

		private int _lastSearchedTrackIndex = -1;

		public EditRepositoryPage()
		{
			this.InitializeComponent();

			ViewModel.Tracks = CurrentApp.TrackRepository
				.OrderBy(x => x.Title)
				.ToArray();
		}

		private void OnSearchBoxQuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
		{
			Search(args.QueryText);
		}

		private async void Search(string query)
		{
			Track track = FindNextTrack(query);
			if (track == null) {
				var message = new MessageDialog(String.Format("The search query '{0}' was not found.", query), "Track search");
				await message.ShowAsync();
			} else {
				TrackListView.ScrollIntoView(track, ScrollIntoViewAlignment.Leading);
			}
		}

		private Track FindNextTrack(string query)
		{
			// Find tracks after last searched track
			for (int i = _lastSearchedTrackIndex + 1; i < ViewModel.Tracks.Count; i++) {
				Track track = ViewModel.Tracks[i];
				if (track.Title.ToLower().Contains(query)) {
					_lastSearchedTrackIndex = i;
					return track;
				}
			}

			// Find tracks from beginning of list to last search track
			for (int i = 0; i <= _lastSearchedTrackIndex; i++) {
				Track track = ViewModel.Tracks[i];
				if (track.Title.ToLower().Contains(query)) {
					_lastSearchedTrackIndex = i;
					return track;
				}
			}

			// No track exists
			_lastSearchedTrackIndex = -1;
			return null;
		}
	}
}
