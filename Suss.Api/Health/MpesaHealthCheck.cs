using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Suss.Api.Health
{
    public class MpesaHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://random-data-api.com/api/v2/banks");
            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy();
            }
            else
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
