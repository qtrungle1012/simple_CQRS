using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockApi.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace StockApi.Infrastructure.Service
{
    public class TokenCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TokenCleanupService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromHours(24);

        public TokenCleanupService(
            IServiceProvider serviceProvider,
            ILogger<TokenCleanupService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Token Cleanup Service khởi động");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Bắt đầu xóa refresh tokens hết hạn...");

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var refreshTokenRepository = scope.ServiceProvider
                            .GetRequiredService<IRefreshTokenRepository>();

                        await refreshTokenRepository.DeleteExpiredTokensAsync();
                    }

                    _logger.LogInformation("Xóa tokens hết hạn thành công");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Lỗi khi xóa tokens hết hạn");
                }

                // Chờ 24 giờ rồi chạy lần tiếp
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}