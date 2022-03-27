//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "REST Service Clients" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace Demo.Services.Common
{
    public class MaintenanceTemplateServiceClient : HttpServiceClient, IMaintenanceTemplateService
    {
        protected readonly JsonSerializerOptions SerializerOptions;

        public MaintenanceTemplateServiceClient(HttpClient httpClient, IOptionsMonitor<JsonSerializerOptions> options)
            : base(httpClient)
        {
            SerializerOptions = options.CurrentValue;
        }

        /// <inheritdoc/>
        public virtual async Task<Output<MaintenanceTemplate_ReadOutput>> ReadAsync(int _id, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"maintenance-template/{ _id }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<MaintenanceTemplate_ReadOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<MaintenanceTemplate_CreateOutput>> CreateAsync(MaintenanceTemplate_CreateInput _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, $"maintenance-template")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<MaintenanceTemplate_CreateOutput>>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output> UpdateAsync(int _id, MaintenanceTemplate_UpdateInput_Data _data, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Put, $"maintenance-template/{ _id }")
            {
                Content = new StringContent(JsonSerializer.Serialize(_data), Encoding.UTF8, "application/json")
            };
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output> DeleteAsync(int _id, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Delete, $"maintenance-template/{ _id }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output>(content, SerializerOptions);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<Output<ICollection<MaintenanceTemplate_ReadListOutput>>> ReadListAsync(MaintenanceTemplate_ReadListInput_Criteria _criteria, CancellationToken token = default)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, $"maintenance-template?{ ToQueryString(_criteria) }");
            using (var resp = await Http.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead, token))
            {
                var content = await resp.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Output<ICollection<MaintenanceTemplate_ReadListOutput>>>(content, SerializerOptions);
            }
        }
    }
}