using IntelOrca.TTQ.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace IntelOrca.TTQ.Metro.View
{
	public sealed partial class TrackPlayerControl : UserControl, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Dependency properties

		public static readonly DependencyProperty TrackProperty =
			DependencyProperty.Register(
				"Track",
				typeof(Track),
				typeof(TrackPlayerControl),
				new PropertyMetadata(null, new PropertyChangedCallback(OnTrackChangedCallback))
			);

		private static void OnTrackChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			TrackPlayerControl instance = sender as TrackPlayerControl;
			if (instance != null)
				instance.OnTrackChanged();
		}

		public Track Track
		{
			get { return (Track)GetValue(TrackProperty); }
			set { SetValue(TrackProperty, value); }
		}

		#endregion

		private readonly MediaElement _mediaElement = new MediaElement();

		public TrackPlayerControl()
		{
			InitializeComponent();

			_mediaElement.AutoPlay = false;
			_mediaElement.MediaOpened += (s, e) => {
				int a = 4;
			};
		}

		private async void OnTrackChanged()
		{
			if (Track == null) {
				_mediaElement.Source = null;
			} else {
				StorageFolder musicPath = KnownFolders.MusicLibrary;
				StorageFile file = await musicPath.GetFileAsync("ttq\\" + Track.Filename);
				_mediaElement.SetSource(await file.OpenReadAsync(), "audio/mp3");
			}

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs("Track"));
		}

		private void PlayButtonOnClick(object sender, RoutedEventArgs e)
		{
			if (Track == null)
				return;

			if (_mediaElement.CurrentState != MediaElementState.Playing)
				_mediaElement.Play();
			else {
				_mediaElement.Position = TimeSpan.FromSeconds(0);
			}
		}

		private void PauseButtonOnClick(object sender, RoutedEventArgs e)
		{
			if (Track == null)
				return;

			if (_mediaElement.CurrentState == MediaElementState.Playing)
				_mediaElement.Pause();
			else
				_mediaElement.Play();
		}

		private void NextButtonOnClick(object sender, RoutedEventArgs e)
		{

		}
	}
}
