namespace RUIANDownloader.Models
{

    internal class DataFileList
    {

        internal DataFileList(DirectoryInfo directory)
        {
            this.Directory = directory;
            this.Files = [];
        }


        internal DirectoryInfo Directory { get; set; }


        internal List<DataFile> Files { get; set; }

    }

}
