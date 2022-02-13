using Microsoft.AspNetCore.Mvc;
using MPUEID_APP.API.Models;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MPUEID_APP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly ConnectAPI _connectaApi;
        private SurveySolutionsApi _client;
        private readonly ILogger<AssignmentsController> _logger;
        private readonly ApiSettings _apiSettings;
        public AssignmentsController(ConnectAPI connectaApi,
            ILogger<AssignmentsController> logger,
            ApiSettings apiSettings)
        {
            _connectaApi = connectaApi; 
            _logger = logger; 
            _apiSettings = apiSettings;

            try
            {
                //connect to API using credentials from ApiSettings
                _client = _connectaApi.Connect();
            }
            catch (Exception ex)
            {
                _logger.LogError($"The following Error was found accessing Survey Solutions API: {ex.Message}");
                throw;
            }
        }
        // POST api/<AssignmentsController>
        /// <summary>
        /// Create Survey Solutions Assignments
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public async Task PostAsync([FromBody] AssignmentModel assignment)
        {
            SurveySolutionsClient.Models.QuestionnaireIdentity questionnaireIdentity =
                new SurveySolutionsClient.Models.QuestionnaireIdentity(Guid.Parse(_apiSettings.QuestionnaireId), _apiSettings.Version);

            var creationResult = await _client.Assignments.CreateAsync(new CreateAssignmentRequest
            {
                QuestionnaireId = questionnaireIdentity,
                Quantity = assignment.Quantity,
                Responsible = assignment.Responsible,
                Email= assignment.Email,
                Password= assignment.Password,
                WebMode = assignment.WebMode, 
                IsAudioRecordingEnabled = assignment.IsAudioRecordingEnabled,
                Comments = assignment.Comments, 
                IdentifyingData = new List<AssignmentIdentifyingDataItem>
                {
                    
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //Address
                        Answer = assignment.IdentifyingData.Address,
                        Variable = "ADDRESS"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //DIRECTIONS
                        Answer = assignment.IdentifyingData.Directions,
                        Variable = "DIRECTIONS"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //POLE
                        Answer = assignment.IdentifyingData.Pole,
                        Variable = "POLE"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //APPLICANT
                        Answer = assignment.IdentifyingData.Applicant,
                        Variable = "APPLICANT"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //APPLICANT_TEL
                        Answer = assignment.IdentifyingData.ApplicantTel,
                        Variable = "APPLICANT_TEL"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //WIREMAN_TEL
                        Answer = assignment.IdentifyingData.WiremanTel,
                        Variable = "WIREMAN_TEL"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //ALTERNATE_TEL
                        Answer = assignment.IdentifyingData.AlternateTel,
                        Variable = "ALTERNATE_TEL"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //APPLICATION_NO
                        Answer = assignment.IdentifyingData.ApplicationNo,
                        Variable = "APPLICATION_NO"
                    },
                    new AssignmentIdentifyingDataItem // text question
                    {
                        //WIREMAN
                        Answer = assignment.IdentifyingData.Wireman,
                        Variable = "WIREMAN"
                    },
                    new AssignmentIdentifyingDataItem // numeric question
                    {
                        //INSPECTION_TYPE
                        Answer = assignment.IdentifyingData.InspectionType.ToString(),
                        Variable = "INSPECTION_TYPE"
                    },
                   /* new AssignmentIdentifyingDataItem // list question
                    {
                        Answer = JsonSerializer.Serialize(new []{ "one", "two", "three" }),
                        Variable = "listR1"
                    },
                    new AssignmentIdentifyingDataItem // gps question
                    {
                        Variable = "gps",
                        Answer = "48.7630568$30.1807397"
                    },
                    new AssignmentIdentifyingDataItem // multiple choice question
                    {
                        Variable = "ms16",
                        Answer =  JsonSerializer.Serialize(new []{ "-2", "3" }),
                    },
                    new AssignmentIdentifyingDataItem // question in roster
                    {
                        Answer = "test answer inside roster",
                        Identity = new Identity(Guid.Parse("7cc0482b99db1f48a4aff9e04fbd2f71"), new RosterVector(-2))
                    }, 
                    new AssignmentIdentifyingDataItem // yes no question
                    {
                        Variable = "yn1",
                        Answer = JsonSerializer.Serialize(new [] { "20 -> yes", "30 -> no" })
                    } */
                }
            });



        }

        
    }
}
