using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HealerBall
{
    public class Plugin : RocketPlugin
    {
        public static Plugin Instance { get; set; }

        protected override void Load()
        {
            Instance = this;
        }

        protected override void Unload()
        {
            
        }

        public bool Heal(Transform transform, ushort amout)
        {
            Interactable2SalvageBarricade bar = transform.GetComponent<Interactable2SalvageBarricade>();
            Interactable2SalvageStructure strc = transform.GetComponent<Interactable2SalvageStructure>();
            if (bar != null)
            {
                BarricadeManager.tryGetInfo(bar.root, out byte x, out byte y, out ushort plant, out ushort index, out BarricadeRegion region);
                region.barricades[index].barricade.askRepair(amout);
                return true;
            }
            else if (strc != null)
            {
                StructureManager.tryGetInfo(strc.transform, out byte x, out byte y, out ushort index, out StructureRegion region);
                region.structures[index].structure.askRepair(amout);
                return true;
            }
            return false;
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"search", "{0} objects found in {1}m. Healing everything..." },
            {"not_found", "Couldnt find any objects in {0}m." },
            {"success", "Healing is finished." },
        };
    }
}
