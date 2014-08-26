namespace InfiniteScrolling
{
	public class Person
	{
		public Person ()
		{
		}

		public Person (int index)
		{
			this.Name = index.ToString ();	
		}

		public string Name { get; set; }
	}
}