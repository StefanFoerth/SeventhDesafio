
namespace PanelManagement
{
    public class PanelEvent
    {
        private string centralCode;
        private string date;
        private string header;
        private string accountCode;
        private string code;
        private string description;
        private string partitionCode;
        private string zoneCode;
        private string userCode;
        private string checksum;

        public string Date { get => date; set => date = value; }
        public string Header { get => header; set => header = value; }
        public string AccountCode { get => accountCode; set => accountCode = value; }
        public string Code { get => code; set => code = value; }
        public string PartitionCode { get => partitionCode; set => partitionCode = value; }
        public string ZoneCode { get => zoneCode; set => zoneCode = value; }
        public string UserCode { get => userCode; set => userCode = value; }
        public string Checksum { get => checksum; set => checksum = value; }
        public string CentralCode { get => centralCode; set => centralCode = value; }
        public string Description { get => description; set => description = value; }
    }

    public class AlarmPanel
    {
        private string header;
        private string code;
        private string endCommand;

        public string Header { get => header; set => header = value; }
        public string Code { get => code; set => code = value; }
        public string EndCommand { get => endCommand; set => endCommand = value; }
    }
}