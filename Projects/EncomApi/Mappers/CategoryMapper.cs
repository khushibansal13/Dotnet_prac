using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Dtos.Category;
using EncomApi.Models;

namespace EncomApi.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Name = category.Name
            };
        }
    }
}
//dont need this beacuse i want array of strings instead of list of objects for categoryList