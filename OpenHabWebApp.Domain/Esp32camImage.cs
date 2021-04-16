using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace OpenHabWebApp.Domain
{
    public class Esp32camImage
    {
        private IFormFile _imageFormFile;

        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [NotMapped]
        public IFormFile ImageFormFile
        {   get
            {
                return _imageFormFile;
            }
            set
            {
                _imageFormFile = value;
                if (value != null)
                {
                    using var memoryStream = new MemoryStream();
                    value.CopyTo(memoryStream);
                    ImageData = memoryStream.ToArray();
                }

            }
        }
        public byte[] ImageData { get; set; }
        public string Name { get; set; }
    }
}
