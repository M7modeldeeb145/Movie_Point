namespace Movie_Point.ViewModel
{
	public class ActorViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Bio { get; set; }
		public string? ProfilePicture { get; set; }
		public string? News { get; set; }
	}
}
