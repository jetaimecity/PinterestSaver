using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

public class Saver
    {
        public Saver() { }

        public void SaveImage(string imageURL, string filename, ImageFormat format)
        {

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageURL);
            Bitmap bitmap;
            bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();

            return;
        }
    }
