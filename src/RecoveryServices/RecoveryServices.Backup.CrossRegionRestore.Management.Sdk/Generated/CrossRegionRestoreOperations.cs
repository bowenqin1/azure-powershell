// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// CrossRegionRestoreOperations operations.
    /// </summary>
    internal partial class CrossRegionRestoreOperations : IServiceOperations<RecoveryServicesBackupClient>, ICrossRegionRestoreOperations
    {
        /// <summary>
        /// Initializes a new instance of the CrossRegionRestoreOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal CrossRegionRestoreOperations(RecoveryServicesBackupClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the RecoveryServicesBackupClient
        /// </summary>
        public RecoveryServicesBackupClient Client { get; private set; }

        /// <summary>
        /// Restores the specified backed up data in a different region as compared to
        /// where the data is backed up.
        /// </summary>
        /// <param name='azureRegion'>
        /// Azure region to hit Api
        /// </param>
        /// <param name='crossRegionRestoreAccessDetails'>
        /// Access details for cross region restore
        /// </param>
        /// <param name='restoreRequest'>
        /// Request object for triggering restore
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> TriggerWithHttpMessagesAsync(string azureRegion, CrrAccessToken crossRegionRestoreAccessDetails = default(CrrAccessToken), RestoreRequest restoreRequest = default(RestoreRequest), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Send request
            AzureOperationResponse _response = await BeginTriggerWithHttpMessagesAsync(azureRegion, crossRegionRestoreAccessDetails, restoreRequest, customHeaders, cancellationToken).ConfigureAwait(false);
            return await Client.GetPostOrDeleteOperationResultAsync(_response, customHeaders, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Restores the specified backed up data in a different region as compared to
        /// where the data is backed up.
        /// </summary>
        /// <param name='azureRegion'>
        /// Azure region to hit Api
        /// </param>
        /// <param name='crossRegionRestoreAccessDetails'>
        /// Access details for cross region restore
        /// </param>
        /// <param name='restoreRequest'>
        /// Request object for triggering restore
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="NewErrorResponseException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse> BeginTriggerWithHttpMessagesAsync(string azureRegion, CrrAccessToken crossRegionRestoreAccessDetails = default(CrrAccessToken), RestoreRequest restoreRequest = default(RestoreRequest), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            if (azureRegion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "azureRegion");
            }
            if (Client.SubscriptionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SubscriptionId");
            }
            CrossRegionRestoreRequest parameters = new CrossRegionRestoreRequest();
            if (crossRegionRestoreAccessDetails != null || restoreRequest != null)
            {
                parameters.CrossRegionRestoreAccessDetails = crossRegionRestoreAccessDetails;
                parameters.RestoreRequest = restoreRequest;
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("azureRegion", azureRegion);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "BeginTrigger", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/providers/Microsoft.RecoveryServices/locations/{azureRegion}/backupCrossRegionRestore").ToString();
            _url = _url.Replace("{azureRegion}", System.Uri.EscapeDataString(azureRegion));
            _url = _url.Replace("{subscriptionId}", System.Uri.EscapeDataString(Client.SubscriptionId));
            List<string> _queryParameters = new List<string>();
            if (Client.ApiVersion != null)
            {
                _queryParameters.Add(string.Format("api-version={0}", System.Uri.EscapeDataString(Client.ApiVersion)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Client.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);
            }


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if(parameters != null)
            {
                _requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(parameters, Client.SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, System.Text.Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 202)
            {
                var ex = new NewErrorResponseException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    NewErrorResponse _errorBody =  Rest.Serialization.SafeJsonConvert.DeserializeObject<NewErrorResponse>(_responseContent, Client.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new AzureOperationResponse();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            if (_httpResponse.Headers.Contains("x-ms-request-id"))
            {
                _result.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}
