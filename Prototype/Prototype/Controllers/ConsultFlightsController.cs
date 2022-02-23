using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Net.Http;
using System.Text.Json;


namespace Prototype.Controllers
{
    using DTOs.Request;
    using DTOs.Response;
    using Infrastructure.common.Exceptions;
    using Infrastructure.Settings;
    using AutoMapper;
    using Entities;
    using Prototype.Extensions;
    using Newtonsoft.Json.Linq;

    //[Route("api/FlightsAPI/v1")]//
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultFlightsController : ControllerBase
    {
        private readonly ILogger<ConsultFlightsController> _logger;
        private readonly IAppSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly IMapper _mapper;

        public ConsultFlightsController(
            ILogger<ConsultFlightsController> logger, 
            IOptions<AppSettings> settings,
            IHttpClientFactory httpClientFactory,
            IMapper mapper
            )
        {
            _logger = logger;
            _settings = settings.Value;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _mapper = mapper;
        }

        [HttpGet("GetRoute")]
        public async Task<ApiResponse<List<Flight>>> GetRoute([FromQuery] ConsultFlightsRoute Value)
        {
            var Result = new ApiResponse<List<Flight>>();
            if (!ModelState.IsValid)
            {
                List<string> ListErrors =
                    ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList();

                throw new GlobalException("Validation error: {0}", String.Join("\\", ListErrors));
            }
            else {
                List<FlightsResponse> SvrResponse = new List<FlightsResponse>();
                var MStream = await ActionGetHttpClient(_settings.ConfigServices._BaseAddress, _settings.ConfigServices._RemoteRoute);

                SvrResponse = await JsonSerializer.DeserializeAsync<List<FlightsResponse>>(
                MStream, _options);

                var query = (from s in SvrResponse
                where s.departureStation == Value.Origin && s.arrivalStation == Value.Destination
                select (s)).ToList();

                //Map
                var FlightObject = _mapper.Map<List<Flight>>(query);

                Result.Data = FlightObject;
                Result.Succeeded = true;
                Result.Message = "Proceso exitoso!";

            }
            return Result;
        }

        /*
        [HttpGet]
        public async Task<List<FlightsRequest>> GetList([FromQuery] ConsultFlightsRoute Value)
        {
            var Result = new List<FlightsRequest>();
            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync(
            _settings.ConfigServices._BaseAddress + _settings.ConfigServices._RemoteRoute,
            HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var Stream = await response.Content.ReadAsStreamAsync();
                Result = await JsonSerializer.DeserializeAsync<List<FlightsRequest>>(Stream,_options);

            }
            return Result;
        }
        */

        private async Task<System.IO.Stream> ActionGetHttpClient(string actionUrl, string paramString)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(actionUrl + paramString);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }
            return null;

        }
    }
}
