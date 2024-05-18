﻿using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories;

internal static class CategoryMapper
{
    public static CategoryDto Map(this Category? category)
    {
        if (category == null) return null;

        return new CategoryDto()
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,
            Childs = category.Childs.MapChildren()
        };
    }
    public static List<CategoryDto> Map(this List<Category> categories)
    {
        var CategoryDtoList = new List<CategoryDto>();

        categories.ForEach(i =>
            {
                CategoryDtoList.Add(new CategoryDto()
                {
                    Id = i.Id,
                    Title = i.Title,
                    Slug = i.Slug,
                    SeoData = i.SeoData,
                    CreationDate = i.CreationDate,
                    Childs = i.Childs.MapChildren()
                });
            }
        );
        return CategoryDtoList;
    }

    public static List<ChildCategoryDto> MapChildren(this List<Category> children)
    {
        var model = new List<ChildCategoryDto>();
        //if (children == null)
        //{
        //    return model;
        //}
        children.ForEach(c =>
        {
            model.Add(new ChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,
                Childs = c.Childs.MapSecondaryChildren()
            });
        });
        return model;
    }






    private static List<SecondaryChildCategoryDto> MapSecondaryChildren(this List<Category> children)
    {
        var model = new List<SecondaryChildCategoryDto>();
        //if (children == null)
        //{
        //    return model;
        //}
        children.ForEach(c =>
        {
            model.Add(new SecondaryChildCategoryDto()
            {
                Title = c.Title,
                Slug = c.Slug,
                Id = c.Id,
                SeoData = c.SeoData,
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId,

            });
        });
        return model;
    }
}

