using System;
using MonkeyArms;
using WhitePaperBible.Core.Models;
using WhitePaperBible.Core.Invokers;
using WhitePaperBible.Core.Views;
using System.Linq;

namespace WhitePaperBible.Core.Mediators
{
	public class SearchPapersMediator : Mediator
	{
		[Inject]
		public AppModel AppModel;

		[Inject]
		public PapersReceivedInvoker PapersReceived;

		[Inject]
		public GetPapersInvoker GetPapers;

		[Inject]
		public RefreshPapersInvoker RefreshPapers;

		[Inject]
		public LoggedInInvoker LoggedIn;

		[Inject]
		public StorageLoadedInvoker StorageLoaded;

		[Inject]
		public LoginRequiredInvoker LoginRequired;

		ISearchPapersView Target;

		public SearchPapersMediator (ISearchPapersView view) : base (view)
		{
			this.Target = view;
		}

		public override void Register ()
		{
//			InvokerMap.Add (Target.Filter, HandleFilter);
//			InvokerMap.Add (Target.OnPaperSelected, HandlerPaperSelected);
//			InvokerMap.Add (Target.AddPaper, OnAddPaper);
			InvokerMap.Add (PapersReceived, (object sender, EventArgs e) => SetPapers ());
			InvokerMap.Add (RefreshPapers, (object sender, EventArgs e) => SetPapers());
			InvokerMap.Add (StorageLoaded, (object sender, EventArgs e) => SetPapers());

//			InvokerMap.Add (LoginRequired, OnLoginRequired);
//			InvokerMap.Add (LoggedIn, OnLoggedIn);

//			Target.SearchPlaceHolderText = "Search Papers";

			SetPapers ();

		}

//		void HandleFilter (object sender, EventArgs e)
//		{
//			if (AppModel.Papers != null) {
//				Target.SetPapers (AppModel.FilterPapers (Target.SearchQuery));
//			}
//		}
//
//		void HandlerPaperSelected (object sender, EventArgs e)
//		{
//			AppModel.CurrentPaper = Target.SelectedPaper;
//		}

		public void SetPapers ()
		{
			if (AppModel.Papers != null) {
				Target.SetPapers (AppModel.Papers);
				if (AppModel.FirstLoad) {
					GetPapers.Invoke ();
					AppModel.FirstLoad = false;
				}
			} else {
				GetPapers.Invoke ();
			}
		}

//		void OnAddPaper (object sender, EventArgs e)
//		{
//			// maybe nothing doing here, all in the view?
//			if (AppModel.IsLoggedIn) {
//				AppModel.CurrentPaper = new Paper ();
//				Target.AddPaperEditView ();
//			}else{
//				LoginRequired.Invoke ();
//			}
//		}
//
//		void OnLoginRequired (object sender, EventArgs e)
//		{
//			Target.PromptForLogin ();
//		}
//
//		void OnLoggedIn (object sender, EventArgs e)
//		{
//			Target.DismissLoginPrompt ();
//		}
	}
}