using System.ComponentModel.DataAnnotations;

namespace SampleRESTAPI.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0,10)]
        public int Credits { get; set; }
    }
}
