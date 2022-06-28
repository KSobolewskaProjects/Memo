using System;
using System.Drawing;
using System.Windows.Forms;

namespace Memo
{
    class Kontrolki
    {
        public PictureBox stworzPictureBox(int KS_60227_polozenieX, int KS_60227_polozenieY, int KS_60227_numerKafelka) 
        {
            PictureBox KS_60227_pictureBox = new PictureBox
            {
                Location = new Point(KS_60227_polozenieX, KS_60227_polozenieY),
                Width = 100,
                Height = 100,
                Name = "pictureBox" + Convert.ToString(KS_60227_numerKafelka),
                Enabled = false,
                Tag = null,
            };
            return KS_60227_pictureBox;
        
        }
    }
}
