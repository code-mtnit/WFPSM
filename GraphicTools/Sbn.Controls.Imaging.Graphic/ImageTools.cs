using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Sbn.Controls.Imaging.Graphic
{
	public class ImageTools
	{
		public Collection<Image> getMultiTifImages(Image myImg)
		{
			FrameDimension dimension = new FrameDimension(myImg.FrameDimensionsList[0]);
			int frameCount = myImg.GetFrameCount(dimension);
			Collection<Image> collection = new Collection<Image>();
			Encoder compression = Encoder.Compression;
			ImageCodecInfo imageCodecInfo = null;
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			for (int i = 0; i < imageDecoders.Length; i++)
			{
				if (imageDecoders[i].MimeType.Equals("image/tiff"))
				{
					imageCodecInfo = imageDecoders[i];
					break;
				}
			}
			for (int j = 0; j < frameCount; j++)
			{
				myImg.SelectActiveFrame(FrameDimension.Page, j);
				EncoderParameters encoderParameters = new EncoderParameters(1);
				encoderParameters.Param[0] = new EncoderParameter(compression, 2L);
				ImageCodecInfo encoder = imageCodecInfo;
				MemoryStream stream = new MemoryStream();
				myImg.Save(stream, encoder, encoderParameters);
				Bitmap item = new Bitmap(stream);
				collection.Add(item);
			}
			return collection;
		}

		private bool ThumbnailCallback()
		{
			return false;
		}

		public Image GetImage(byte[] stream)
		{
			Image result;
			try
			{
				result = Image.FromStream(new MemoryStream(stream));
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public byte[] GetStreamImage(Image img, ImageFormat format)
		{
			byte[] result;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					img.Save(memoryStream, format);
					byte[] buffer = memoryStream.GetBuffer();
					memoryStream.Dispose();
					result = buffer;
				}
			}
			catch (Exception var_2_36)
			{
				throw;
			}
			return result;
		}

		public Image ScaleImage(Image image, int width, int height, double scaleRatio)
		{
			Image result = null;
			try
			{
				if (width != image.Width || height != image.Height)
				{
					double num = 1.0;
					double num2 = 1.0;
					if (image.Width > 0)
					{
						num = (double)width / (double)image.Width;
					}
					if (image.Height > 0)
					{
						num2 = (double)height / (double)image.Height;
					}
					if (num < num2)
					{
						try
						{
							result = image.GetThumbnailImage((int)((double)image.Width * num), (int)((double)image.Height * num), new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
						}
						catch
						{
							try
							{
								Bitmap bitmap = new Bitmap(image);
								result = bitmap.GetThumbnailImage((int)((double)image.Width * num), (int)((double)image.Height * num), new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
								bitmap.Dispose();
							}
							catch
							{
							}
						}
					}
					else
					{
						try
						{
							result = image.GetThumbnailImage((int)((double)image.Width * num2), (int)((double)image.Height * num2), new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
						}
						catch
						{
							try
							{
								Bitmap bitmap = new Bitmap(image);
								result = bitmap.GetThumbnailImage((int)((double)image.Width * num2), (int)((double)image.Height * num2), new Image.GetThumbnailImageAbort(this.ThumbnailCallback), IntPtr.Zero);
								bitmap.Dispose();
							}
							catch
							{
							}
						}
					}
				}
				else
				{
					result = image;
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		public Bitmap ConvertToBitonal(Bitmap original)
		{
			Bitmap bitmap = null;
			Bitmap result;
			if (original == null)
			{
				result = null;
			}
			else
			{
				if (original.PixelFormat != PixelFormat.Format32bppArgb)
				{
					bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);
					bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.DrawImageUnscaled(original, 0, 0);
					}
				}
				else
				{
					bitmap = original;
				}
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				int num = bitmapData.Stride * bitmapData.Height;
				byte[] array = new byte[num];
				Marshal.Copy(bitmapData.Scan0, array, 0, num);
				bitmap.UnlockBits(bitmapData);
				Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format1bppIndexed);
				BitmapData bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed);
				num = bitmapData2.Stride * bitmapData2.Height;
				byte[] array2 = new byte[num];
				int height = bitmap.Height;
				int width = bitmap.Width;
				int num2 = 500;
				for (int i = 0; i < height; i++)
				{
					int num3 = i * bitmapData.Stride;
					int num4 = i * bitmapData2.Stride;
					byte b = 0;
					int num5 = 128;
					for (int j = 0; j < width; j++)
					{
						int num6 = (int)(array[num3 + 1] + array[num3 + 2] + array[num3 + 3]);
						if (num6 > num2)
						{
							b += (byte)num5;
						}
						if (num5 == 1)
						{
							array2[num4] = b;
							num4++;
							b = 0;
							num5 = 128;
						}
						else
						{
							num5 >>= 1;
						}
						num3 += 4;
					}
					if (num5 != 128)
					{
						array2[num4] = b;
					}
				}
				Marshal.Copy(array2, 0, bitmapData2.Scan0, num);
				bitmap2.UnlockBits(bitmapData2);
				result = bitmap2;
			}
			return result;
		}

		private ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			ImageCodecInfo[] array = imageDecoders;
			ImageCodecInfo result;
			for (int i = 0; i < array.Length; i++)
			{
				ImageCodecInfo imageCodecInfo = array[i];
				if (imageCodecInfo.FormatID == format.Guid)
				{
					result = imageCodecInfo;
					return result;
				}
			}
			result = null;
			return result;
		}

		public ImageCodecInfo getCodecForstring(string type)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			ImageCodecInfo result;
			for (int i = 0; i < imageEncoders.Length; i++)
			{
				string value = type.ToString();
				if (imageEncoders[i].FormatDescription.Equals(value))
				{
					result = imageEncoders[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		public void saveImageExistingMultiplePage(Image[] bmp, Image origionalFile, string type, int PageNumber, string location)
		{
			try
			{
				ImageCodecInfo codecForstring = this.getCodecForstring(type);
				EncoderParameters encoderParameters = new EncoderParameters(2);
				Encoder saveFlag = Encoder.SaveFlag;
				Encoder compression = Encoder.Compression;
				origionalFile.SelectActiveFrame(FrameDimension.Page, 0);
				Bitmap bitmap = new Bitmap(origionalFile);
				bitmap = this.ConvertToBitonal(bitmap);
				EncoderParameter encoderParameter = new EncoderParameter(saveFlag, 18L);
				EncoderParameter encoderParameter2 = new EncoderParameter(compression, 4L);
				encoderParameters.Param[0] = encoderParameter2;
				encoderParameters.Param[1] = encoderParameter;
				bitmap.Save(location, codecForstring, encoderParameters);
				for (int i = 1; i < PageNumber; i++)
				{
					encoderParameter = new EncoderParameter(saveFlag, 23L);
					encoderParameter2 = new EncoderParameter(compression, 4L);
					encoderParameters.Param[0] = encoderParameter2;
					encoderParameters.Param[1] = encoderParameter;
					origionalFile.SelectActiveFrame(FrameDimension.Page, i);
					Bitmap bitmap2 = new Bitmap(origionalFile);
					bitmap2 = this.ConvertToBitonal(bitmap2);
					bitmap.SaveAdd(bitmap2, encoderParameters);
				}
				for (int i = 0; i < bmp.Length; i++)
				{
					encoderParameter = new EncoderParameter(saveFlag, 23L);
					encoderParameter2 = new EncoderParameter(compression, 4L);
					encoderParameters.Param[0] = encoderParameter2;
					encoderParameters.Param[1] = encoderParameter;
					bmp[i] = this.ConvertToBitonal((Bitmap)bmp[i]);
					bitmap.SaveAdd(bmp[i], encoderParameters);
				}
				encoderParameter = new EncoderParameter(saveFlag, 20L);
				encoderParameters.Param[0] = encoderParameter;
				bitmap.SaveAdd(encoderParameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void saveImageExistingSinglePage(Image[] bmp, Image origionalFile, string type, string location)
		{
			try
			{
				ImageCodecInfo codecForstring = this.getCodecForstring(type);
				EncoderParameters encoderParameters = new EncoderParameters(2);
				Encoder saveFlag = Encoder.SaveFlag;
				Encoder compression = Encoder.Compression;
				EncoderParameter encoderParameter = new EncoderParameter(saveFlag, 18L);
				EncoderParameter encoderParameter2 = new EncoderParameter(compression, 4L);
				encoderParameters.Param[0] = encoderParameter2;
				encoderParameters.Param[1] = encoderParameter;
				origionalFile = this.ConvertToBitonal((Bitmap)origionalFile);
				origionalFile.Save(location, codecForstring, encoderParameters);
				for (int i = 0; i < bmp.Length; i++)
				{
					encoderParameter = new EncoderParameter(saveFlag, 23L);
					encoderParameter2 = new EncoderParameter(compression, 4L);
					encoderParameters.Param[0] = encoderParameter2;
					encoderParameters.Param[1] = encoderParameter;
					origionalFile.SaveAdd(bmp[i], encoderParameters);
				}
				encoderParameter = new EncoderParameter(saveFlag, 20L);
				encoderParameters.Param[0] = encoderParameter;
				origionalFile.SaveAdd(encoderParameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool saveMultipage(Image[] bmp, string location, string type, bool convertToGrayScale)
		{
			bool result;
			if (bmp != null)
			{
				try
				{
					ImageCodecInfo codecForstring = this.getCodecForstring(type);
					if (convertToGrayScale)
					{
						for (int i = 0; i < bmp.Length; i++)
						{
							if (bmp[i] == null)
							{
								break;
							}
							bmp[i] = this.ConvertToBitonal((Bitmap)bmp[i]);
						}
					}
					if (bmp.Length == 1)
					{
						File.Delete(location);
						EncoderParameters encoderParameters = new EncoderParameters(1);
						Encoder compression = Encoder.Compression;
						EncoderParameter encoderParameter = new EncoderParameter(compression, 4L);
						encoderParameters.Param[0] = encoderParameter;
						bmp[0].Save(location, codecForstring, encoderParameters);
						result = true;
						return result;
					}
					if (bmp.Length > 1)
					{
						EncoderParameters encoderParameters2 = new EncoderParameters(2);
						Encoder saveFlag = Encoder.SaveFlag;
						Encoder compression2 = Encoder.Compression;
						try
						{
						}
						catch (Exception)
						{
						}
						EncoderParameter encoderParameter2 = new EncoderParameter(saveFlag, 18L);
						EncoderParameter encoderParameter3 = new EncoderParameter(compression2, 4L);
						encoderParameters2.Param[0] = encoderParameter3;
						encoderParameters2.Param[1] = encoderParameter2;
						File.Delete(location);
						bmp[0].Save(location, codecForstring, encoderParameters2);
						for (int i = 1; i < bmp.Length; i++)
						{
							if (bmp[i] == null)
							{
								break;
							}
							encoderParameter2 = new EncoderParameter(saveFlag, 23L);
							encoderParameter3 = new EncoderParameter(compression2, 4L);
							encoderParameters2.Param[0] = encoderParameter3;
							encoderParameters2.Param[1] = encoderParameter2;
							bmp[0].SaveAdd(bmp[i], encoderParameters2);
						}
						encoderParameter2 = new EncoderParameter(saveFlag, 20L);
						encoderParameters2.Param[0] = encoderParameter2;
						bmp[0].SaveAdd(encoderParameters2);
						result = true;
						return result;
					}
					result = false;
					return result;
				}
				catch (Exception var_10_1AB)
				{
					result = false;
					return result;
				}
			}
			result = false;
			return result;
		}

		public MemoryStream saveMultipage(Image[] bmp, string type)
		{
			MemoryStream result;
			if (bmp != null)
			{
				try
				{
					MemoryStream memoryStream = new MemoryStream();
					ImageCodecInfo codecForstring = this.getCodecForstring(type);
					for (int i = 0; i < bmp.Length; i++)
					{
						if (bmp[i] == null)
						{
							break;
						}
						bmp[i] = this.ConvertToBitonal((Bitmap)bmp[i]);
					}
					if (bmp.Length == 1)
					{
						EncoderParameters encoderParameters = new EncoderParameters(1);
						Encoder compression = Encoder.Compression;
						EncoderParameter encoderParameter = new EncoderParameter(compression, 4L);
						encoderParameters.Param[0] = encoderParameter;
						bmp[0].Save(memoryStream, codecForstring, encoderParameters);
						result = memoryStream;
						return result;
					}
					if (bmp.Length > 1)
					{
						EncoderParameters encoderParameters2 = new EncoderParameters(2);
						Encoder saveFlag = Encoder.SaveFlag;
						Encoder compression2 = Encoder.Compression;
						EncoderParameter encoderParameter2 = new EncoderParameter(saveFlag, 18L);
						EncoderParameter encoderParameter3 = new EncoderParameter(compression2, 4L);
						encoderParameters2.Param[0] = encoderParameter3;
						encoderParameters2.Param[1] = encoderParameter2;
						bmp[0].Save(memoryStream, codecForstring, encoderParameters2);
						for (int i = 1; i < bmp.Length; i++)
						{
							if (bmp[i] == null)
							{
								break;
							}
							encoderParameter2 = new EncoderParameter(saveFlag, 23L);
							encoderParameter3 = new EncoderParameter(compression2, 4L);
							encoderParameters2.Param[0] = encoderParameter3;
							encoderParameters2.Param[1] = encoderParameter2;
							bmp[0].SaveAdd(bmp[i], encoderParameters2);
						}
						encoderParameter2 = new EncoderParameter(saveFlag, 20L);
						encoderParameters2.Param[0] = encoderParameter2;
						bmp[0].SaveAdd(encoderParameters2);
						result = memoryStream;
						return result;
					}
					result = null;
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message + "  Error in saving as multipage ");
				}
			}
			result = null;
			return result;
		}
	}
}
