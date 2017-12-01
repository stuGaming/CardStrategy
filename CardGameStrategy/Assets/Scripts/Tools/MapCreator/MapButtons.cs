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

        private void Awake()
        {
            button = this.GetComponent<Button>();

            button.onClick.AddListener(OnClick);
            button.image.color = Color.gray;
        }

        public BlockType type;

        public void setColor()
        {
            switch (type)
            {
                case BlockType.Normal:
                    button.image.color = Color.gray;
                    break;
                case BlockType.Fire:
                    button.image.color = Color.red;
                    break;
                case BlockType.Water:
                    button.image.color = Color.blue;
                    break;
                case BlockType.Grass:
                    button.image.color = Color.green;
                    break;
            }
        }

        public void OnClick()
        {
            int x = (int)type;
            x++;
            BlockType lastBlock = Enum.GetValues(typeof(BlockType)).Cast<BlockType>().Last();
            if (x > (int)lastBlock)
            {
                x = 0;
            }
             type = (BlockType)x;


            setColor();
        }

    }
}
