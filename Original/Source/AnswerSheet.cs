////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.IO;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	class AnswerSheet
	{
		private Quiz mQuiz;
		private string mHTML;
		private bool mShowAnswers;

		public AnswerSheet(Quiz quiz)
		{
			mQuiz = quiz;
		}

		private string GenerateRound(int index)
		{
			Round round = mQuiz.Rounds[index];

			string sz_tracks = "";
			//Load the round html template
			string sz_round = LoadRoundTemplate();

			for (int t = 0; t < round.Tracks.Count; t++) {
				Track track = round.Tracks[t];

				//Load the track html template
				string sz_track = LoadTrackTemplate();

				//Write the track number
				sz_track = sz_track.Replace("{TRACK_NUMBER}", Convert.ToString(t + 1));

				//Write the title and score if in answer mode
				if (mShowAnswers) {
					if (track.HasCloseAnswer) {
						sz_track = sz_track.Replace("{TITLE}",
							String.Format("{0}<br /><span class=\"no_htitle\">Close Answer:</span> {1}",
							track.Title, track.CloseAnswer));
					} else {
						sz_track = sz_track.Replace("{TITLE}", track.Title);
					}
					sz_track = sz_track.Replace("{TRACK_SCORE}", track.PointsAvailable.ToString());
				} else {
					sz_track = sz_track.Replace("{TITLE}", "&nbsp;");
					sz_track = sz_track.Replace("{TRACK_SCORE}", "&nbsp;");
				}

				//Write the song if in answer mode (N/A if no song)
				if (!track.HasSong) {
					sz_track = sz_track.Replace("{SONG_NAME}", "N/A");
				} else {
					if (mShowAnswers)
						sz_track = sz_track.Replace("{SONG_NAME}", track.Song);
					else
						sz_track = sz_track.Replace("{SONG_NAME}", "&nbsp;");
				}

				//Add the generated track html to the main tracks html
				sz_tracks += sz_track;
			}

			//Write the round number, name and number of tracks
			sz_round = sz_round.Replace("{ROUND_NUMBER}", Convert.ToString(index + 1));
			sz_round = sz_round.Replace("{ROUND_NAME}", round.Name);
			sz_round = sz_round.Replace("{TRACKS}", sz_tracks);

			//Write the round total centred if in answer mode otherwise a slash right aligned
			if (mShowAnswers)
				sz_round = sz_round.Replace("{ROUND_TOTAL}", String.Format("<div align=\"center\">{0}</div>", round.GetMaximumScore()));
			else
				sz_round = sz_round.Replace("{ROUND_TOTAL}", String.Format("/{0}", round.GetMaximumScore()));

			//Return the round html
			return sz_round;
		}

		private void GenerateRounds()
		{
			string sz_rounds = "";

			//Generate html for each round and add it to sz_rounds
			for (int i = 0; i < mQuiz.Rounds.Count; i++)
				sz_rounds += GenerateRound(i);

			//Write all the round html
			mHTML = mHTML.Replace("{ROUNDS}", sz_rounds);
		}

		private string LoadQuizTemplate()
		{
			return File.ReadAllText(SheetPath + "quiz.htm");
		}

		private string LoadRoundTemplate()
		{
			return File.ReadAllText(SheetPath + "round.htm");
		}

		private string LoadTrackTemplate()
		{
			return File.ReadAllText(SheetPath + "track.htm");
		}

		private void ReplaceVariables()
		{
			//Write 'answer sheet' if in answer mode otherwise 'team name:'
			//Write the quiz total centred if in answer mode otherwise a slash right aligned
			if (mShowAnswers) {
				mHTML = mHTML.Replace("{TEAM_NAME}", "Answer Sheet");
				mHTML = mHTML.Replace("{QUIZ_TOTAL}", String.Format("<div align=\"center\">{0}</div>", mQuiz.GetMaximumScore()));
			} else {
				mHTML = mHTML.Replace("{TEAM_NAME}", "Team Name:");
				mHTML = mHTML.Replace("{QUIZ_TOTAL}", String.Format("/{0}", mQuiz.GetMaximumScore()));
			}

			//Write the quiz name and when the quiz was created and printed
			mHTML = mHTML.Replace("{QUIZ_NAME}", mQuiz.Name);
			mHTML = mHTML.Replace("{TTQ_CREATED}", mQuiz.DateCreated.ToString());
			mHTML = mHTML.Replace("{PRINTED}", DateTime.Now.ToString());
		}

		public void GenerateHTML(string filename)
		{
			GenerateHTML(filename, false);
		}

		public void GenerateHTML(string filename, bool showAnswers)
		{
			mShowAnswers = showAnswers;
			mHTML = LoadQuizTemplate();
			GenerateRounds();
			ReplaceVariables();
			File.WriteAllText(filename, mHTML);
		}

		public string SheetPath
		{
			get
			{
				return Application.StartupPath + "\\Sheet\\";
			}
		}
	}
}