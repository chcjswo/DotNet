using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolPicCrawler.Image
{
    public class ImageService
    {
        private static readonly ImageService _imageService;

        /// <summary>
        /// static 초기화
        /// </summary>
        static ImageService()
        {
            _imageService = new ImageService();
        }

        public static ImageService getInstance
        {
            get
            {
                return _imageService;
            }
        }

        private ImageService() { }
    }
}
