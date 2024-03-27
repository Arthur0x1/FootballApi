namespace FootballApi.ViewModels
{
	public class PlayerVm
	{
        public int Id { get; set; }
        public int ShirtNo { get; set; }
        public string Name { get; set; } = null!;
        public PositionVm Position { get; set; } = null!;
        public int Appearances { get; set; }
        public int Goals { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
    }

	public class PlayerPostVm
	{
		public int ShirtNo { get; set; }
		public string Name { get; set; } = null!;
		public PositionVm Position { get; set; } = null!;
		public int Appearances { get; set; }
		public int Goals { get; set; }
		public float PositionX { get; set; }
		public float PositionY { get; set; }
	}
}
