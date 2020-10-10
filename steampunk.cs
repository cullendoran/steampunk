using Terraria;
using Terraria.ModLoader;

namespace steampunk
{
	public class Steampunk : Mod
	{
		public override void Load()
		{
			// Will show up in client.log under the ExampleMod name
			Logger.InfoFormat("{0} steampunk logging", Name);
			// In older tModLoader versions we used: ErrorLogger.Log("blabla");
			// Replace that with above

			// All code below runs only if we're not loading on a server
			if (!Main.dedServ)
			{
				// Register a new music box
			}
		}
	}
}