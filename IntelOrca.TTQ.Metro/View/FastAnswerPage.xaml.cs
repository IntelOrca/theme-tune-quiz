using IntelOrca.TTQ.Core;
using IntelOrca.TTQ.Metro.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace IntelOrca.TTQ.Metro.View
{
	public sealed partial class FastAnswerPage : Page
	{
		private readonly Queue<Track> _playlist = new Queue<Track>();
		private Track _currentTrack;

		private Stopwatch _sessionTime = new Stopwatch();
		private Stopwatch _questionTime = new Stopwatch();
		private Stopwatch _answerTime = new Stopwatch();

		private int _numQuestions;
		private int _correctAnswers;
		private int _wrongAnswers;
		private int _dunnoAnswers;

		private long _correctTicks;
		private long _wrongTicks;
		private long _dunnoTicks;

		private bool _finished;

		public App CurrentApp { get { return (App)App.Current; } }
		public FastAnswerViewModel ViewModel { get { return (FastAnswerViewModel)DataContext; } }

		public FastAnswerPage()
		{
			this.InitializeComponent();

			ViewModel.SelectedCategories = CurrentApp.TrackRepository
				.Select(x => x.Category)
				.Distinct()
				.Select(x => new FastAnswerViewModel.CategorySelectionItem(false, x))
				.ToArray();

			CategorySelectionPanel.Visibility = Visibility.Visible;
			PlayPanel.Visibility = Visibility.Collapsed;
		}

		private void OnBackButtonClick(object sender, RoutedEventArgs e)
		{
			Frame.GoBack();
		}

		private void OnForwardButtonClick(object sender, RoutedEventArgs e)
		{
			CategorySelectionPanel.Visibility = Visibility.Collapsed;
			PlayPanel.Visibility = Visibility.Visible;

			// Create playlist
			var random = new Random();
			var trackOrder = CurrentApp.TrackRepository.OrderBy(x => random.Next());

			_playlist.Clear();
			foreach (Track track in trackOrder)
				_playlist.Enqueue(track);

			// Start the session
			_sessionTime.Start();
			NextTrack();
		}

		private void OnIKnowItButtonClick(object sender, RoutedEventArgs e)
		{
			if (AnswerTextBox.Visibility == Visibility.Visible) {
				_answerTime.Stop();

				if (IsValidAnswer(AnswerTextBox.Text)) {
					if (_currentTrack.Title.Equals(AnswerTextBox.Text, StringComparison.OrdinalIgnoreCase)) {
						_correctAnswers++;
						_correctTicks += _questionTime.ElapsedTicks;
						OutcomeLabel.Text = "CORRECT!";
					} else {
						_wrongAnswers++;
						_wrongTicks += _questionTime.ElapsedTicks;
						OutcomeLabel.Text = "WRONG!";
					}

					ShowAnswer();
				} else {
					// MessageBox.Show("Your answer does not exist!");
				}
			} else {
				_questionTime.Stop();

				// PopulateAnswerList();

				AnswerTextBox.Visibility = Visibility.Visible;
				// btnReplay.Enabled = false;
				TrackPlayer.Pause();

				AnswerTextBox.Focus(FocusState.Programmatic);

				_answerTime.Start();
			}
		}

		private void OnDunnoButtonClick(object sender, RoutedEventArgs e)
		{
			_dunnoAnswers++;
			_questionTime.Stop();
			_dunnoTicks += _questionTime.ElapsedTicks;
			OutcomeLabel.Text = "DIDN'T KNOW";

			ShowAnswer();
		}

		private void OnNextButtonClick(object sender, RoutedEventArgs e)
		{
			NextTrack();
		}

		private async void OnFinishButtonClick(object sender, RoutedEventArgs e)
		{
			var message = new MessageDialog("Are you sure you want to finish?", "Finish");
			await message.ShowAsync();

			Finish();
		}

		private async void NextTrack()
		{
			if (_playlist.Count > 0) {
				// Dequeue a track
				_currentTrack = _playlist.Dequeue();

				// Increment times played on database
				_currentTrack.TimesPlayed++;
				await CurrentApp.SaveTrackRepository();
			} else {
				Finish();
			}

			TrackPlayer.Track = _currentTrack;

			AnswerTextBox.Visibility = Visibility.Collapsed;
			AnswerTextBox.Text = String.Empty;

			TrackTitleLabel.Text = String.Empty;
			SongTitleLabel.Text = String.Empty;
			CategoryTitleLabel.Text = String.Format("Category: {0}", _currentTrack.Category);

			OutcomeLabel.Visibility = Visibility.Collapsed;

			IKnowItButton.Visibility = Visibility.Visible;
			DunnoButton.Visibility = Visibility.Visible;
			NextButton.Visibility = Visibility.Collapsed;
			FinishButton.Visibility = Visibility.Collapsed;

			TrackPlayer.AllowSeek = false;
			TrackPlayer.PlayFromStart();

			IKnowItButton.Focus(FocusState.Programmatic);

			_numQuestions++;
			_questionTime.Start();
		}

		private void ShowAnswer()
		{
			TrackTitleLabel.Text = _currentTrack.IsTheme ?
				String.Format("Theme of {0}", _currentTrack.Title) :
				String.Format("Tune from {0}", _currentTrack.Title);

			if (_currentTrack.HasSong)
				SongTitleLabel.Text = _currentTrack.Song;

			// btnReplay.Enabled = true;

			OutcomeLabel.Visibility = Visibility.Visible;

			IKnowItButton.Visibility = Visibility.Collapsed;
			DunnoButton.Visibility = Visibility.Collapsed;
			NextButton.Visibility = Visibility.Visible;
			FinishButton.Visibility = Visibility.Visible;

			AnswerTextBox.Visibility = Visibility.Collapsed;

			TrackPlayer.AllowSeek = true;
			TrackPlayer.Play();
		}

		private void Finish()
		{
			_finished = true;

			_sessionTime.Stop();

			long averageCorrect = 0;
			long averageWrong = 0;
			long averageDunno = 0;

			if (_correctAnswers != 0)
				averageCorrect = _correctTicks / _correctAnswers;

			if (_wrongAnswers != 0)
				averageWrong = _wrongTicks / _wrongAnswers;

			if (_dunnoAnswers != 0)
				averageDunno = _dunnoTicks / _dunnoAnswers;

			// PercentageLabel.Text = String.Format("You scored {0}%", Math.Ceiling(((float)mCorrectAnswers / (float)mNoQuestions) * 100));
			// CorrectLabel.Text = String.Format("Correct: {0} / {1}", mCorrectAnswers, mNoQuestions);
			// WrongLabel.Text = String.Format("Wrong: {0} / {1}", mWrongAnswers, mNoQuestions);
			// DunnoLabel.Text = String.Format("Dunno: {0} / {1}", mDunnoAnswers, mNoQuestions);

			// SessionTimeLabel.Text = String.Format("Session Time: {0}", GetTimeFormat(mSessionTime.ElapsedTicks));
			// CorrectAverageTimeLabel.Text = String.Format("Average Time for Correct: {0}", GetTimeFormat(averageCorrect));
			// WrongAverageTimeLabel.Text = String.Format("Average Time for Wrong: {0}", GetTimeFormat(averageWrong));
			// DunnoAverageTimeLabel.Text = String.Format("Average Time for Dunno: {0}", GetTimeFormat(averageDunno));

			// pnlQuestions.Visible = false;
			// pnlConclusion.Visible = true;

			TrackPlayer.Stop();
			// ttqPlayer.Close();
		}

		private bool IsValidAnswer(string answer)
		{
			return false;
		}

		private static string GetTimeFormat(long ticks)
		{
			TimeSpan ts = new TimeSpan(ticks);
			return String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
		}
	}
}
