using IntelOrca.TTQ.Core;
using IntelOrca.TTQ.Metro.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class PlayQuizPage : Page
	{
		public PlayQuizPage()
		{
			this.InitializeComponent();

			var viewModel = this.DataContext as PlayQuizPageViewModel;
			viewModel.QuizName = "Hello";
			viewModel.Rounds = Enumerable.Range(0, 3).Skip(1).ToArray();
			viewModel.Tracks = Enumerable.Range(0, 11).Skip(1).ToArray();
			viewModel.CurrentRoundName = "Round name";
			viewModel.HasCloseAnswer = true;
			viewModel.HasSong = true;
		}
	}
}
