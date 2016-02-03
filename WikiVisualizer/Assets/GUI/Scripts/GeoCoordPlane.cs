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
        /// <param name="longitude">Converted to X coordinate</param>
        /// <param name="latitude">Converted to Y coordinate</param>
        /// <param name="planeWidth">Map plane width</param>
        /// <param name="planeHeight">Map plane height</param>
        /// <param name="centerLongitude">Map center latitude</param>
        /// <param name="centerLatitude">Map center longitude<</param>
        /// <param name="zoom">Map zoom</param>
        /// <returns></returns>
        public static Vector2 CoordinatesTo2D(float longitude, float latitude, 
                                                float planeWidth, float planeHeight,
                                                float centerLongitude = 0f, float centerLatitude = 0f,
                                                int zoom = 1)
        {
            /* center offset  */
            longitude -= centerLongitude;
            latitude -= centerLatitude;

            /* max lon and lat depend on zoom */
            float longitudeVisible = 360f; //at zoom = 1
            float latitudeVisible = 180f;   //
            for(int i = 1;i < zoom; i++) {
                longitudeVisible /= 2f;
                latitudeVisible /= 2f;
            }

            /* calculate coeficient */
            float wCoef = planeWidth / longitudeVisible;
            float hCoef = planeHeight / latitudeVisible;

            /* coordinate conversion */
            float x = wCoef *  latitude;
            float y = hCoef * longitude;

            return new Vector2(x, y);
        }
    }
}
