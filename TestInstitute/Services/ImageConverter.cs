namespace TestInstitute.Services
{
    public static class ImageConverter
    {
        public static string? ToBase64(IFormFile? image)
        {
            if (image is null)
            {
                return null;
            }

            using Stream stream = image.OpenReadStream();
            using MemoryStream ms = new();
            stream.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
