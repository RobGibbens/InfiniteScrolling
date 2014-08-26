using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace InfiniteScrolling
{
	public partial class MainPage : ContentPage
	{
		readonly MainViewModel _viewModel;

		int _start = 0;
		const int _numberOfRecords = 100;

		public MainPage ()
		{
			InitializeComponent ();

			_viewModel = new MainViewModel ();
			this.BindingContext = _viewModel;

			this.loadData.Clicked += async (sender, e) => {
				await LoadData ();
			};

			this.mainList.ItemAppearing += async (sender, e) => {
				var person = (Person)e.Item;

				System.Diagnostics.Debug.WriteLine (person.Name);

				if (!_viewModel.IsLoading) {

					if (person.Name == _viewModel.People.Last ().Name) {
						await LoadData ();
					}
				}
			};
		}

		async Task LoadData ()
		{
			await _viewModel.LoadData (_start, _numberOfRecords);
			_start = _start + _numberOfRecords;
		}
	}
}

