using System;
using System.Linq;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace Destroyer
{
	[ApiVersion(1, 17)]
    public class Destroyer : TerrariaPlugin
    {
	    public override string Author
	    {
		    get { return "White"; }
	    }

	    public override string Name
	    {
		    get { return "Destroyer"; }
	    }

	    public override Version Version
	    {
		    get { return new Version(1, 0); }
	    }

	    public Destroyer(Main game) : base(game)
	    {
	    }

	    public override void Initialize()
	    {
		    ServerApi.Hooks.GameUpdate.Register(this, OnGameUpdate);
	    }

	    private void OnGameUpdate(EventArgs args)
	    {
			//destroyer
		    foreach (var npc in Main.npc.Where(n => n.active && n.type == 134))
			{
				if (npc.position.X / 16f > Main.maxTilesX || npc.position.X / 16f < 0)
				{
					continue;
				}

			    for (var i = -1; i < 4; i++)
			    {
				    if ((npc.position.Y/16f) + i > Main.maxTilesY || (npc.position.Y) + i < 0)
				    {
					    continue;
				    }

				    if (Main.tile[(int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i].active())
				    {
					    WorldGen.KillTile((int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i);
					    TSPlayer.All.SendTileSquare((int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i);
				    }
			    }
		    }

			//prime
		    foreach (var npc in Main.npc.Where(n => n.active && n.type < 132 && n.type > 126))
			{
				if (npc.position.X / 16f > Main.maxTilesX || npc.position.X / 16f < 0)
				{
					continue;
				}

				if (npc.type == 127)
				{
					for (var i = -4; i < 4; i++)
					{
						if ((npc.position.Y / 16f) + i > Main.maxTilesY || (npc.position.Y) + i < 0)
						{
							continue;
						}

						if (Main.tile[(int)(npc.position.X / 16f), (int)(npc.position.Y / 16f) + i].active())
						{
							WorldGen.KillTile((int)(npc.position.X / 16f), (int)(npc.position.Y / 16f) + i);
							TSPlayer.All.SendTileSquare((int)(npc.position.X / 16f), (int)(npc.position.Y / 16f) + i);
						}
					}
				}
				else
				{
					for (var i = -1; i < 4; i++)
					{
						if ((npc.position.Y/16f) + i > Main.maxTilesY || (npc.position.Y) + i < 0)
						{
							continue;
						}

						if (Main.tile[(int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i].active())
						{
							WorldGen.KillTile((int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i);
							TSPlayer.All.SendTileSquare((int) (npc.position.X/16f), (int) (npc.position.Y/16f) + i);
						}
					}
				}
			}
	    }
    }
}