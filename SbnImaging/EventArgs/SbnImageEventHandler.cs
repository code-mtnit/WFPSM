using Sbn.Controls.Imaging.EventArgsFolder;
using Sbn.Controls.Imaging.ImagingObject;


namespace Sbn.Controls.Imaging
{
    public delegate void FilmStripBeforRemoveImageEventHandler(object sender, ImageEventArgs e, ref bool checkRemove);
    public delegate void FilmStripBeforSelectImageEventHandler(object sender, ref ImageDocument selectedImage);
}