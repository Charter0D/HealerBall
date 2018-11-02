using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HealerBall
{
    public class CommandHBall : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "hball";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer p = (UnturnedPlayer)caller;
            var res = new List<Transform>();
            float dist = float.Parse(command[0]);
            res = TransformFinder.FindAll().FindAll(x => Vector3.Distance(p.Position, x.position) <= dist);
            if (res.Count > 0)
            {
                UnturnedChat.Say(caller, Plugin.Instance.Translate("search", res.Count, command[0]));
                foreach (var v in res)
                {
                    BarricadeManager.repair(v, -30000, 1);
                    StructureManager.repair(v, -30000, 1);
                }
                UnturnedChat.Say(caller, Plugin.Instance.Translate("success"));
            }
            else
                UnturnedChat.Say(caller, Plugin.Instance.Translate("not_found"));
        }
    }
}
