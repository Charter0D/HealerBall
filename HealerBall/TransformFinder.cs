using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace HealerBall
{
    public class TransformFinder
    {
        public static List<Transform> Barricades => FindBarricades();
        public static List<Transform> Structures => FindStructures();

        private static List<Transform> FindBarricades()
        {
            List<Transform> res = new List<Transform>();
            for (int k = 0; k < BarricadeManager.BarricadeRegions.GetLength(0); k++)
            {
                for (int l = 0; l < BarricadeManager.BarricadeRegions.GetLength(1); l++)
                {
                    var reg = BarricadeManager.BarricadeRegions[k, l];
                    for (int i = 0; i < reg.drops.Count; i++)
                    {
                        var drop = reg.drops[i];
                        res.Add(drop.model);
                    }
                }
            }
            return res;
        }

        private static List<Transform> FindStructures()
        {
            List<Transform> res = new List<Transform>();
            for (int k = 0; k < StructureManager.regions.GetLength(0); k++)
            {
                for (int l = 0; l < StructureManager.regions.GetLength(1); l++)
                {
                    var reg = StructureManager.regions[k, l];
                    for (int i = 0; i < reg.drops.Count; i++)
                    {
                        var drop = reg.drops[i];
                        res.Add(drop.model);
                    }
                }
            }
            return res;
        }

        public static List<Transform> FindAll()
        {
            var kust = Barricades;
            var suks = Structures;
            foreach (var v in suks)
                kust.Add(v);
            return kust;
        }
    }
}
