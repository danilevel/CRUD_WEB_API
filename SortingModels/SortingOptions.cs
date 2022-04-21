﻿using System.ComponentModel.DataAnnotations;

namespace CRUD_WEB_API.SortingModels
{
    public class SortingOptions
    {
        [EnumDataType(typeof(Sorting))]
        public Sorting SortByTitle { get; set; }

        [EnumDataType(typeof(Sorting))]
        public Sorting SortByDate { get; set; }
    }
}