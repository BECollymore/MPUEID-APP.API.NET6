using System.ComponentModel.DataAnnotations;

namespace MPUEID_APP.API.Models
{
    public partial class AssignmentModel
    { 
        public string Responsible { get; set; } = string.Empty;
        public int Quantity { get; set; }
        // public string QuestionnaireId { get; set; } = string.Empty;
        public IdentifyData identifyData { get; set; }   
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool WebMode { get; set; } = false;
        public bool IsAudioRecordingEnabled { get; set; } = false; 
        public string Comments { get; set; } = string.Empty;
        
       
    }
}
