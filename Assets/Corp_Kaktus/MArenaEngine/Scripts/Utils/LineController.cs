using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    /// <summary>
    /// control all lines in game
    /// </summary>
    public static class LineController
    {
        private static readonly List<LineDrawer> Drawers = new ();

        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            var lineDrawer = new LineDrawer();
            lineDrawer.DrawLineInGameView(start, end, color);
            Drawers.Add(lineDrawer);
        }

        public static void Clear() => Drawers.Clear();
    }
}