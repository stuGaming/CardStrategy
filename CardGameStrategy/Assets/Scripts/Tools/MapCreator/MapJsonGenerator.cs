using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Tools.MapCreator
{
    class MapJsonGenerator:MonoBehaviour
    {
        public string outputString;
        public InputField HeightInput;
      
        public int gridHeight
        {
            get
            {
                int x = 0;
                int.TryParse(HeightInput.text,out x);
                return x;
            }
        }
        public InputField WidthInput;
        public int gridwidth
        {
            get
            {
                int x = 0;
                int.TryParse(WidthInput.text, out x);
                return x;
            }
        }



        public MapButtons[] buttonArray;
        public List<List<MapButtons>> buttons = new List<List<MapButtons>>();

        IEnumerator colorCo()
        {
            
            for (int i = 0; i < buttons.Count && i < gridHeight; i++)
            {
                for (int f = 0; f < buttons[0].Count && f < gridwidth; f++)
                {
                    buttons[i][f].button.image.color = Color.cyan;
                }
            }
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < buttons.Count && i < gridHeight; i++)
            {
                for (int f = 0; f < buttons[0].Count && f < gridwidth; f++)
                {
                    buttons[i][f].setColor();
                }
            }
        }

        public void showGridClick()
        {
            StartCoroutine(colorCo());
        }

        public void createJSON()
        {
            outputString = "";
            Map map = new Map();
            map.Width = gridwidth;
            map.Height = gridHeight;
            for (int i = 0; i < buttons.Count && i < gridHeight; i++)
            {
                for (int f = 0; f < buttons[0].Count && f < gridwidth; f++)
                {
                    map.blockTypes.Add(buttons[i][f].type);
                }
            }

            outputString = JsonUtility.ToJson(map);
        }

        void Awake()
        {
            int index = 0;
            for (int i = 0; i < 15; i++)
            {
                List<MapButtons> tempBut = new List<MapButtons>();
                for (int f = 0;f < 15; f++)
                {
                    tempBut.Add(buttonArray[index]);
                    index++;
                }
                buttons.Add(tempBut);
            }
        }

        


    }
}
