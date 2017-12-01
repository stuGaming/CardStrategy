using Assets.Scripts.GameScripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tools.MapCreator
{
    class MapButtons:MonoBehaviour
    {
        public Button button;

        public BlockType type;
        public void OnClick()
        {
            int x = (int)type;
            x++;
            try
            {
                type = (BlockType)x;

            }
            catch
            {
                x = 0;
                type = (BlockType)x;
            }
            switch (type)
            {
                case BlockType.Normal:
                    break;
                case BlockType.Fire:
                    break;
                case BlockType.Water:
                    break;
                case BlockType.Grass:
                    break;
            }
        }

    }
}
