using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Collections;
using System.IO;
using Sbn.Controls.Imaging.ImagingObject;

// Sbn.Libs.Imaging.
namespace Sbn.Controls.Imaging
{
    /// <summary>
    /// Encapsulation of an image in the Filmstrip control.
    /// </summary>
    public class BaseImage2 : ImageDocument, IComparer
    {
        private bool ThumbnailCallback()
        {
            // Nothing to do here.
            return false;
        }

        bool _EditedImage = false;

        public bool EditedImage
        {
            get { return _EditedImage; }
            set { _EditedImage = value; }
        }


        #region Member variables

        private int _counter;
        private Image image;
        private Image _imageFullView;
        private Image _ThumbnailImage;
        private String path;

        #endregion Member variables

        #region Properties


        /// The Image ID.
        /// Cannot be -1.
        /// </summary>
        /// <exception cref="System.SystemException.ArgumentOutOfRangeException">System.SystemException.ArgumentOutOfRangeException - 
        /// when trying to set the image id to be -1</exception>
        public int Counter
        {
            get { return _counter; }
            set
            {
                //if (FilmstripControl.NO_SELECTION_ID == value)
                //{
                //    //  throw new ArgumentOutOfRangeException();
                //}
                _counter = value;
                //if (this.OrderInDocument <= 0)
                //{
                //    this.OrderInDocument = value;
                //}
            }
        }

        /// <summary>
        /// The image itself.
        /// </summary>
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
            }
        }

        /// <summary>
        /// The image itself.
        /// </summary>
        public Image ImageFullViewLayer
        {
            get { return _imageFullView; }
            set
            {
                _imageFullView = value;
            }
        }


        public Image ThumbnailImage
        {
            get { return _ThumbnailImage; }
            set
            {

                _ThumbnailImage = value;
            }
        }

        /// <summary>
        /// The path of the image.
        /// </summary>
        public String Path
        {
            get { return path; }
            set { path = value; }
        }


        private Guid guid;

        public Guid Guid
        {
            get { return guid; }
        }

        #endregion Properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseImage2()
        {
            this.Counter = -1;// FilmstripControl.NO_SELECTION_ID;
            guid = Guid.NewGuid();
            //  System.IO.MemoryStream ms = null;


            //if (image == null && Stream != null)
            //{
            //    ms = new System.IO.MemoryStream(this.Stream);
            //    this.Image = System.Drawing.Image.FromStream(ms);
            //    ms.Dispose();
            //}


            //if (this.ThumbnailImage == null && this.ThumbnailStream != null)
            //{
            //    ms = new System.IO.MemoryStream(this.ThumbnailStream);
            //    this.ThumbnailImage = System.Drawing.Image.FromStream(ms);
            //    ms.Dispose();
            //}

            //if (this.Image == null)
            //{
            //  //  this.Image = this.DefulteImage;
            //}


            this.Image = null;
            this.Title = String.Empty;
        }


        

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="imageValue">The image itself</param>
        /// <param name="descriptionValue">The image description</param>
        public BaseImage2(string xmlHTFImage)
        {


            try
            {

                this.Counter = -1;// FilmstripControl.NO_SELECTION_ID;
                guid = Guid.NewGuid();
                ImageDocument img = new ImageDocument();
                //img.set_XML(xmlHTFImage);
                //img.InitializeObject(null);


                this.layers = img.layers;
                this.ID = img.ID;
                this.Stream = img.Stream;
                this.Title = img.Title;
                this.OrderInDocument = img.OrderInDocument;
                Description = Path;
             
            }
            catch
            {

            }

        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="imageValue">The image itself</param>
        /// <param name="descriptionValue">The image description</param>
        public BaseImage2(ImageDocument img)
        {


            try
            {

                this.Counter = -1;// FilmstripControl.NO_SELECTION_ID;
                guid = Guid.NewGuid();
                this.layers = img.layers;
                this.ID = img.ID;
                this.Stream = img.Stream;
                this.Title = img.Title;
                this.OrderInDocument = img.OrderInDocument;
                Description = Path;


            }
            catch
            {

            }

        }



        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="imageValue">The image itself</param>
        /// <param name="descriptionValue">The image description</param>
        public BaseImage2(Image imageValue, String descriptionValue, String pathValue)
        {
            _counter = -1;// FilmstripControl.NO_SELECTION_ID;
            //  this.Image = imageValue;
            Title = descriptionValue;
            Path = pathValue;
            guid = Guid.NewGuid();
            Description = Path;
            if ((Stream == null || Stream.Length < 10 ) && imageValue != null)
            {
                //imageValue.Save(@"D:\ui.tif");
                var ms = new MemoryStream();
                imageValue.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                byte[] bin = ms.GetBuffer();
                Stream = bin;
                ms.Close();
                ms.Dispose();
            }

        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="idValue">The image ID - cannot be -1</param>
        /// <param name="imageValue">The image itself</param>
        /// <param name="descriptionValue">The image description</param>
        /// <exception cref="System.SystemException.ArgumentOutOfRangeException">System.SystemException.ArgumentOutOfRangeException - if the image id is -1</exception>
        public BaseImage2(int idValue, Image imageValue, String descriptionValue, String pathValue)
        {
            //if (FilmstripControl.NO_SELECTION_ID == idValue)
            //{
            //    throw new ArgumentOutOfRangeException();
            //}
            this.Counter = idValue;
            guid = Guid.NewGuid();
            // this.Image = imageValue;
            this.Title = descriptionValue;
            this.Path = pathValue;
            Description = Path;
            if (pathValue != null && pathValue != "")   //Added by rm
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(pathValue);
                byte[] bin = new byte[sr.BaseStream.Length];
                sr.BaseStream.Read(bin, 0, (int)sr.BaseStream.Length);
                this.Stream = bin;
            }
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            if (x is BaseImage2 && y is BaseImage2)
            {
                if (((BaseImage2)(x)).OrderInDocument == ((BaseImage2)(y)).OrderInDocument)
                {
                    return 0;
                }

                if (((BaseImage2)(x)).OrderInDocument > ((BaseImage2)(y)).OrderInDocument)
                {
                    return 1;
                }

                if (((BaseImage2)(x)).OrderInDocument < ((BaseImage2)(y)).OrderInDocument)
                {
                    return -1;
                }


            }
            return 0;
        }


        public override bool Equals(object obj)
        {
            if (ID > 0 && ((BaseImage2)obj).ID > 0)
            {
                if (ID == ((BaseImage2)obj).ID)
                    return true;
                else
                    return false;
            }
            else
            {

                return ReferenceEquals(this, obj);

                if (OrderInDocument == ((BaseImage2)obj).OrderInDocument)
                    return true;
                else
                    return false;
            }

            return object.ReferenceEquals(this, obj);

            return base.Equals(obj);
        }

        #endregion
    }
}
