using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WikiWis
{

    class GeoCoordPlane
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude">Converted to Y coordinate</param>
        /// <param name="longitude">Converted to X coordinate</param>
        /// <param name="planeWidth">Map plane width</param>
        /// <param name="planeHeight">Map plane height</param>
        /// <returns></returns>
        public static Vector2 CoordinatesTo2D(float latitude, float longitude, float planeWidth, float planeHeight)
        {
            //latitude = 45f;
            //longitude = 45f;
            //planeWidth = 800f;
            //planeHeight = 500f;

            //latitude += 45f;
            //longitude += 45f;
            //int x = (int)((planeWidth / 360.0) * (180 + latitude));
            //int y = (int)((planeHeight / 180.0) * (90 - longitude));
            float wCoef = planeWidth / 360.0f;
            float hCoef = planeHeight / 180.0f;

            float x = wCoef *  latitude;
            float y = hCoef * longitude;
            //x += planeWidth / 2;
           // y += planeHeight / 2;
            return new Vector2(x, y);
        }
    }
}
