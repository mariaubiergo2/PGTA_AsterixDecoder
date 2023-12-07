﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace AsterixDecoder
{
    public class RotatableMarker : GMapMarker
    {
        private Bitmap rotatedBitmap;
        private string text;
        private readonly Bitmap originalBitmap;

        public RotatableMarker(PointLatLng position, Bitmap originalBitmap, float rotationAngle, string text)
            : base(position)
        {
            this.text = text;
            this.rotatedBitmap = RotateImage(originalBitmap, rotationAngle);
            this.originalBitmap = originalBitmap;
        }

        public override void OnRender(Graphics g)
        {
            g.DrawImage(rotatedBitmap, LocalPosition.X, LocalPosition.Y, rotatedBitmap.Width, rotatedBitmap.Height);
        }

        private Bitmap RotateImage(Bitmap original, float angle)
        {
            Bitmap rotated = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(rotated))
            {
                g.TranslateTransform(original.Width / 2, original.Height / 2); // Set the rotation point at the center of the image
                g.RotateTransform(angle); // Rotate the image by the specified angle
                g.TranslateTransform(-original.Width / 2, -original.Height / 2); // Reset the translation
                g.DrawImage(original, new Point(0, 0)); // Draw the rotated image

            }

            return rotated;
        }

        public void rotate(float angle)
        {
            // Create a copy of the original bitmap before applying the rotation
            Bitmap rotated = RotateImage(this.originalBitmap, angle);

            // Update the rotated bitmap
            //rotatedBitmap.Dispose(); // Dispose the existing rotated bitmap
            rotatedBitmap = rotated; // Assign the new rotated bitmap
        }
    }

}
