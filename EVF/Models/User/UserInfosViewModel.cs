namespace evf.Models.User
{
    public class UserInfosViewModel
    {
        private int idPersonnel;
        private int idRole;
        private string name;
        private string codeSAP;
        private int? idSociete;
        private string? email;
        private string langue;
        private string dateFormatSelected;
        private string decimalFormatCulture;
        private string saveType;
        private string regexCulture;

        public UserInfosViewModel(int idPersonnel, int idRole, string name, string codeSAP, int? idSociete, string? email, string langue, string dateFormatSelected, string decimalFormatCulture,string saveType)
        {
            this.idPersonnel = idPersonnel;
            this.idRole = idRole;
            this.name = name;
            this.codeSAP = codeSAP;
            this.idSociete = idSociete;
            this.email = email;
            this.langue = langue;
            this.dateFormatSelected = dateFormatSelected;
            this.decimalFormatCulture = decimalFormatCulture;
            this.saveType = saveType;

        }


        public int IdPersonnel { get => idPersonnel; set => idPersonnel = value; }
        public int IdRole { get => idRole; set => idRole = value; }
        public string Name { get => name; set => name = value; }
        public string CodeSAP { get => codeSAP; set => codeSAP = value; }
        public int? IdSociete { get => idSociete; set => idSociete = value; }
        public string? Email { get => email; set => email = value; }
        public string Langue { get => langue; set => langue = value; }
        public string DateFormatSelected { get => dateFormatSelected; set => dateFormatSelected = value; }

        public string RegexCulture { get => GetRegexPattern(decimalFormatCulture); set => regexCulture = value; }
        public string DecimalFormatCulture { get => decimalFormatCulture; set => decimalFormatCulture = value; }
        public string SaveType { get => saveType; set => saveType = value; }

        private string GetRegexPattern(string culture)
        {
            string pattern;

            switch (culture)
            {
                case "fr-FR":
                    pattern = @"^\d{1,3}(?: ?\d{3})*(?:,\d{1,4})?$";
                    break;
                case "es-ES":
                    pattern = @"^\d{1,3}(?:.?\d{3})*(?:,\d{1,4})?$";
                    break;
                case "en-US":
                    pattern = @"^\d{1,3}(?:,?\d{3}){0,4}(?:\.\d{1,4})?$";
                    break;
                case "hi-IN":
                    pattern = @"^(\d{1,2})(,?\d{2})*(,?\d{1,3}){1}(\.\d{1,})?$";
                    break;
                default:
                    pattern = @"^\d{1,3}(?:,?\d{3}){0,4}(?:\.\d{1,4})?$";
                    break;
            }
            return pattern;
        }
    }
}
