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
		    foreach (var npc in Main.npc.Where(n => n.active && n.type == 134))
		    {
			    for (var i = -1; i < 4; i++)
			    {
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