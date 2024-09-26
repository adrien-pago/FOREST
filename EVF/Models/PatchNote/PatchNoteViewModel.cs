namespace evf.Models.PatchNote;
using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.EVF;

    public class PatchNoteViewModel
    {
        private string numeroVersion;

        public string NumeroVersion { get => numeroVersion; set => numeroVersion = value; }
        public List<PatchNote> PatchNotesList { get; set; }
    }

