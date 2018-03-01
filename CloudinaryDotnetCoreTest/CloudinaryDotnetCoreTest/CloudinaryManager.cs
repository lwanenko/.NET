using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CloudinaryDotnetCoreTest
{
    public static class CloudinaryManager
    {
        #region VAR
        private static Account account = new Account(
                         "tandtapp",
                         "959336366472599",
                         "goS8W-C-4tOCvfe8ixl8pGSgirY");

        private static Cloudinary cloudinary = new Cloudinary(account);
        #endregion

        #region UPLOAD

        /// <summary>
        /// Завантажує фотографію на Cloudinary 
        /// </summary>
        /// <param name="stream"> Фото</param>
        /// <returns></returns>
        public static async Task<string> UploadPhoto(Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("test", stream ),
                Transformation = new Transformation().Crop("limit").Width(800).Height(800).FetchFormat("png"),
               
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Завантажує фотографію на Cloudinary 
        /// </summary>
        /// <param name="stream"> Фото </param>
        /// <returns></returns>
        public static async Task<string> UploadAvatar(Stream stream)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("test", stream),
                    Transformation = new Transformation().Gravity("face").Width(200).Height(200).Crop("thumb").Radius("max"),

                };
                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                return uploadResult.Uri.AbsoluteUri;
            }
        }
        
        #endregion
    }
}
