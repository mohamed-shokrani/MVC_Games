namespace MVC_Games.Attributes;
   public static class AllowedExtensionsAttribute
{
    public static string AllowedExtensions = ".jpg,.png.,jpeg";
    public static int MaxFileSizeInMB = 1;
    public static int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
}

 