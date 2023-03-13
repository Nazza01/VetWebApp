using System;
namespace VetWebApp.Models
{
	public class StateInfoModel
	{
		public StateInfoModel()
		{
			ServerState = new List<string> { "" };
		}
		public List<string> ServerState { get; set; }
	}
}

