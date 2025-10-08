using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Comments.DTOs;
using StockApi.Domain.Entities;

namespace StockApi.Application.Features.Stocks.DTOs
{
    public class StockDto : IMapFrom<Stock>
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}