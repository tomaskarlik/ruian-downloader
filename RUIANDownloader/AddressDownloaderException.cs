namespace RUIANDownloader
{

    public class AddressDownloaderException : Exception
    {

        public string Operation { get; set; }


        public AddressDownloaderException(
            string operation,
            string? message = null,
            Exception? innerException = null
        ) : base(message, innerException)
        {
            this.Operation = operation;
        }
    }

}
