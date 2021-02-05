namespace CSV_to_JSON
{
	internal class SwitchArgs : ISwitchArgs 
	{
		private string[] args;
		public string TargetFilePath { get; }

		public SwitchArgs(string[] args)
		{
			TargetFilePath = args.Length > 0 ? args[0] : "";
		}
	}
}