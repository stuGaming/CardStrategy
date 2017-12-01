using Assets.Scripts.GameScripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Tools.MapCreator
{
    [Serializable]
    public class Map
    {
        public int Width = 0;
        public int Height = 0;
        public List<BlockType> blockTypes = new List<BlockType>();

    }
}
