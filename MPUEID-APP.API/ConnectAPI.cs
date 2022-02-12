using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SurveySolutionsClient;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;


namespace MPUEID_APP.API
{
	public class ConnectAPI
	{
		private readonly ApiSettings _apiSettings;
		

		public ConnectAPI(ApiSettings apiSettings)
		{
			_apiSettings = apiSettings;
		}
		public SurveySolutionsApi Connect()
        {
			// API user login and password. If you need to execute action
			// from the name of interviewer, supervisor or headquarters its possible to provide those also
			Credentials creds = new Credentials(_apiSettings.ApiUser, _apiSettings.Password);

			// Url of the Survey Solutions 
			string surveySolutionsUrl = _apiSettings.URL;
			string workspace = _apiSettings.Workspace;

            try
            {
				var surveySolutionsApiConfiguration = new SurveySolutionsApiConfiguration(creds, surveySolutionsUrl,
				workspace // If API user is created within workspace provide its name here
			);
			    var client = new SurveySolutionsApi(new HttpClient(), surveySolutionsApiConfiguration);
				return client;

            }
            catch (Exception ex)
            {
				throw new Exception(ex.Message);
				
            }
			

			

		}
	}
}

