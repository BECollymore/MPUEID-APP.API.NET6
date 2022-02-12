using System.ComponentModel.DataAnnotations;

namespace MPUEID_APP.API.Models
{
    public partial class Assignment
    {
        public string Responsible { get; set; } = string.Empty;
        public int Quantity { get; set; } 
        public string QuestionnaireId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool WebMode { get; set; }
        public bool IsAudioRecordingEnabled { get; set; }
        public string Comments { get; set; } = string.Empty;
        
       
    }
}
