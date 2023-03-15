using System.Drawing;

namespace VetWebApp.Models
{
    public class AnimalDataModel
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public Image Picture { get; set; }
    }
}
