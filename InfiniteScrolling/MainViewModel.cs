using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq;

namespace InfiniteScrolling
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public MainViewModel ()
		{
			this.Progress = (double)0.0;
		}

		ObservableCollection<Person> _people;
		public ObservableCollection<Person> People {
			get {
				if (_people == null)
					_people = new ObservableCollection<Person> ();

				return _people;
			}
			set {
				_people = value;
				PropertyChanged (this, new PropertyChangedEventArgs ("People"));
			}
		}

		bool isLoading;
		public bool IsLoading {
			get {
				return isLoading;
			}
			set {
				if (isLoading != value) {
					isLoading = value;
					PropertyChanged (this, new PropertyChangedEventArgs ("IsLoading"));
				}
			}
		}

		double progress;
		public double Progress {
			get {
				return progress;
			}
			set {
				if (progress != value) {
					progress = value;
					PropertyChanged (this, new PropertyChangedEventArgs ("Progress"));
				}
			}
		}

		public async Task LoadData (int start, int numberOfRecords)
		{
			this.Progress = 0;
			this.IsLoading = true;

			for (int counter = 0; counter < numberOfRecords; counter++) {
				this.Progress = (double)counter / numberOfRecords;
				People.Add (new Person (start + counter));
				await Task.Delay(TimeSpan.FromMilliseconds(20));
			}

			this.IsLoading = false;
			this.Progress = 0;
		}
	}
}