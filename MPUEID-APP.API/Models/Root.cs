namespace MPUEID_APP.API.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class IdentifyingData
    {
        public string Variable { get; set; }
        public string Answer { get; set; }
    }

    public class Root
    {
        public string Responsible { get; set; }
        public int Quantity { get; set; }
        public string QuestionnaireId { get; set; }
        public List<IdentifyingData> IdentifyingData { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool WebMode { get; set; }
        public bool IsAudioRecordingEnabled { get; set; }
        public string Comments { get; set; }
        public List<string> ProtectedVariables { get; set; }
    }
}
