﻿using System.ComponentModel.DataAnnotations;

namespace BaiTap2Api.Dtos
{
    public class UpsertCategoryDTO
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string PictureUrl { get; set; }
    }
}
