namespace DownloadDocs.Models
{
    public class Manual
    {
        public string Title { get; set; } = "Lijmdistributiesysteem";

        public string Version { get; set; } = "1.0";

        public DateTime RevisionDate { get; set; } = DateTime.Now;

        public string SerialNumber { get; set; } = "";

        public string Company { get; set; } = "";

        public string Author { get; set; } = "";

        public string Language { get; set; } = "nl-BE";

        public string Year => DateTime.Now.Year.ToString();


        // Machine gegevens
        public int GlueTanks { get; set; } = 4;

        public int DistributionLines { get; set; } = 2;

        public int ApplicationStations { get; set; } = 4;


        // Teksten
        public string Introduction { get; set; } = "";

        public string OperationProcedure { get; set; } = "";

        public string SafetyInstructions { get; set; } = "";

        public string MaintenanceInstructions { get; set; } = "";
    }
}
