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
		private readonly DispatcherTimer _updateTimer = new DispatcherTimer();

		public TrackPlayerControl()
		{
			InitializeComponent();

			// Override play mode items
			foreach (var item in Enum.GetValues(typeof(PlayMode)))
				OverridePlayModeComboBox.Items.Add(FriendlyNameAttribute.GetFriendlyNameOrTypeName(item));
			OverridePlayModeComboBox.SelectedIndex = 0;

			_mediaElement.AutoPlay = false;

			_updateTimer.Interval = TimeSpan.FromMilliseconds(100);
			_updateTimer.Tick += OnUpdateTimerTick;
			_updateTimer.Start();
		}

		private void OnUpdateTimerTick(object sender, object e)
		{
			UpdateTimeLabels();
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

			UpdateTimeLabels();

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

		private void UpdateTimeLabels()
		{
			if (Track == null) {
				// Track bar
				TrackBarProgress.Visibility = Visibility.Collapsed;
				TrackBarThumb.Visibility = Visibility.Collapsed;

				// Labels
				CurrentTimeLabel.Text = String.Empty;
				TrackDurationLabel.Text = String.Empty;
			} else {
				double currentTimeSeconds = _mediaElement.Position.TotalSeconds;
				double totalTimeSeconds = _mediaElement.NaturalDuration.TimeSpan.TotalSeconds;

				if (totalTimeSeconds != 0.0) {
					// Track bar
					TrackBarProgress.Visibility = Visibility.Visible;
					TrackBarProgress.Width = currentTimeSeconds / totalTimeSeconds * TrackBarContainer.ActualWidth;
					TrackBarThumb.Visibility = Visibility.Visible;
					TrackBarThumb.Margin = new Thickness(TrackBarProgress.Width - 10, 0, 0, 0);

					// Labels
					CurrentTimeLabel.Text = currentTimeSeconds.ToString("0.00");
					TrackDurationLabel.Text = totalTimeSeconds.ToString("0.00");
				}
			}
		}
	}
}
