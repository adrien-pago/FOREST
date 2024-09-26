using EVF.DAL.DataConnection.EVF;
using EVF.DAL.Entity.EVF;
using Microsoft.AspNetCore.Identity;

namespace evf.Utils
{
    public class DisplayPatchNote : IDisplayPatchNote
    {

        private List<PatchNote> patchNotesList;
        public List<PatchNote> PatchNotesList { get => patchNotesList; set => patchNotesList = value; }

        public DisplayPatchNote(EVFContext context)
        {

            patchNotesList = context.PatchNotes.ToList();

        }
    }
}
