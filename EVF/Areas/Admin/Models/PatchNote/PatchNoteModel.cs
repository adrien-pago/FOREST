namespace evf.Areas.Admin.Models.PatchNote
{
    public class PatchNoteModel
    {
        private string numeroVersion;
        private string version;
        private string titre;
        private string explication;
        private DateOnly datePublication;
        private int numeroCorrectif;

        public string NumeroVersion { get => numeroVersion; set => numeroVersion = value; }
        public string Version { get => version; set => version = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Explication { get => explication; set => explication = value; }
        public DateOnly DatePublication { get => datePublication; set => datePublication = value; }
        public int NumeroCorrectif { get => numeroCorrectif; set => numeroCorrectif = value; }
    }
}
