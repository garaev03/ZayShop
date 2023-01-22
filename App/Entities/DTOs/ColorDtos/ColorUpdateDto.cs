﻿namespace Zay.Entities.DTOs.ColorDtos
{
    public class ColorUpdateDto
    {
        public ColorGetDto getDto { get; set; }
        public ColorPostDto postDto { get; set; }
        public ColorUpdateDto()
        {
            getDto = new();
            postDto = new();
        }
    }
}
