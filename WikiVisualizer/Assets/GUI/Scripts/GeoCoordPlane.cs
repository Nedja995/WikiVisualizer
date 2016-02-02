using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WikiWis
{
    class Vector2<T>
    {
        public Vector2(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
        public T x;
        public T y;
    }

    class GeoCoordPlane
    {
        public static Vector2<float> CoordinatesTo2D(float latitude, float longitude, float planeWidth, float planeHeight)
        {
            latitude += 45f;
            longitude += 45f;

            float wCoef = planeWidth / 180.0f;
            float hCoef = planeHeight / 180.0f;

            float x = wCoef *  latitude;
            float y = hCoef * longitude;

            return new Vector2<float>(x, y);
        }
    }
}
