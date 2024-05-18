﻿using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;

    public class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.OrderByDescending(o => o.Id).ToListAsync(cancellationToken);
            return model.Map();
        }
    }

}
