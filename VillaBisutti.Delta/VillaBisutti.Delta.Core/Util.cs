using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace VillaBisutti.Delta
{
	public static class Util
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute DescAttribute =
				field.GetCustomAttribute<DescriptionAttribute>();
			if (DescAttribute != null)
				return DescAttribute.Description;
			DisplayAttribute DisplayAttribute =
				field.GetCustomAttribute<DisplayAttribute>();
			if (DisplayAttribute != null)
				return DisplayAttribute.Name;
			return value.ToString();
		}
        internal static T Get<T>(string name)
        {
            string config = ConfigurationManager.AppSettings[name];
            T value = default(T);
            if (!String.IsNullOrEmpty(config))
            {
                value = (T)Convert.ChangeType(config, typeof(T));
                return value;
            }
            return value;
        }

        internal static List<T> GetList<T>(string name, char separator = ',')
        {
            string config = ConfigurationManager.AppSettings[name];
            List<T> value = new List<T>();
            if (!String.IsNullOrEmpty(config))
            {
                value = config.Split(separator).Cast<T>().ToList();
                return value;
            }
            return value;
        }

        /*TODO: Imagem
         * Redimencionar a imagem
         * Colocar a mensagem dentro da imagem: Imagem meramente ilustrativa
         * ver de qual evento se trata
         * criar a pasta para o evento da imagem(se ja tiver, só coloca na pasta)
         * colocar o nome da imagem de acordo com a data e hora (yyyymmdd HH:mm:ss) dentro da pasta
         * */
        public static String HandleFile(string path)
        {
            
            //Open the file
            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    Image image = Image.FromStream(fileStream);
                    System.Drawing.Bitmap imageResized = ResizeImage(image);
                    imageResized.Save(path);
                }
            }
            return "Ravena";
        }
        /// <summary>
        /// Redimenciona a imagem original
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static Bitmap ResizeImage(Image image)
        {
            //TODO: colocar essas chaves no WebConfig
            //TODO: pegar tamanho da imagem e só redimencioar se o tamanho estiver maior que o padrão
            int width = Util.Get<int>("largura");
            int height = Util.Get<int>("altura");
            var destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
                //graphics.DrawRectangle(new Pen(Color.White,(float)image.Width),);
                graphics.DrawString(Util.Get<string>("texto-imagens"), new Font(FontFamily.GenericSansSerif, 20, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Transparent, 0, 0);
            }
            return destImage;

        }

		private static Dictionary<int, string> locaisCerimonia;
		public static Dictionary<int, string> LocalCerimonia
		{
			get
			{
				if (locaisCerimonia == null)
				{
					locaisCerimonia = new Dictionary<int, string>();
					foreach (Delta.Core.Model.LocalCerimonia item in Enum.GetValues(typeof(Delta.Core.Model.LocalCerimonia)).Cast<Delta.Core.Model.LocalCerimonia>())
                        locaisCerimonia[(int)item] = item.GetDescription();
				}
				return locaisCerimonia;
			}
		}
		private static Dictionary<int, string> tiposAcesso;
		public static Dictionary<int, string> TiposAcesso
		{
			get
			{
				if(tiposAcesso == null)
				{
					tiposAcesso = new Dictionary<int, string>();
					foreach (Delta.Core.Model.TipoAcesso item in Enum.GetValues(typeof(Delta.Core.Model.TipoAcesso)).Cast<Delta.Core.Model.TipoAcesso>())
						tiposAcesso[(int)item] = item.GetDescription();
				}
				return tiposAcesso;
			}
		}
		private static Dictionary<int, string> tiposEvento;
		public static Dictionary<int, string> TiposEvento
		{
			get
			{
				if (tiposEvento == null)
				{
					tiposEvento = new Dictionary<int, string>();
					foreach (Delta.Core.Model.TipoEvento item in Enum.GetValues(typeof(Delta.Core.Model.TipoEvento)).Cast<Delta.Core.Model.TipoEvento>())
                        tiposEvento[(int)item] = item.GetDescription();
                }
				return tiposEvento;
			}
		}
		private static Dictionary<int, string> tiposServico;
		public static Dictionary<int, string> TiposServico
		{
			get
			{
				if (tiposServico == null)
				{
					tiposServico = new Dictionary<int, string>();
					foreach (Delta.Core.Model.TipoAcesso item in Enum.GetValues(typeof(Delta.Core.Model.TipoServico)).Cast<Delta.Core.Model.TipoServico>())
						tiposServico[(int)item] = item.GetDescription();
				}
				return tiposServico;
			}
		}
	}
}
