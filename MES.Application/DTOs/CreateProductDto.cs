
namespace MES.Application.DTOs
{
   public class CreateProductDto // kontejner podataka
   {
        public string Code { get; set; } = string.Empty; // default vrednost u C#-u
                                                         // — sprečava da property slučajno bude null ako ga niko ne postavi.
        public string Name { get; set; } = string.Empty;
        public double CycleTimeSeconds { get; set; }
   }
    // sa validacijom : Data anotacije na DTO Klasama, ili FluentValidation biblioteka
}
