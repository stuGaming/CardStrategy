using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Tools.MapCreator
{
    class MapJsonGenerator:MonoBehaviour
    {
        public MapButtons[] buttonArray;
        public List<List<MapButtons>> buttons = new List<List<MapButtons>>();

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
