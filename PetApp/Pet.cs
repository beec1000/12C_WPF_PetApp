using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PetApp
{
    internal class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public Uri ImgS { get; set; }

        public Pet(string name, int age, string color, string imgS)
        {
            Name = name;
            Age = age;
            Color = color;
            ImgS =  new Uri(Path.Combine("IMAGES", imgS), UriKind.Relative);
        }

        public static List<Pet> FromFile(string path)
        {
            List<Pet> pets = new List<Pet>();

            string[] line = File.ReadAllLines(path);

            foreach ( var l in line )
            {
                string[] p = l.Split(';');

                string PetName = p[0];
                int PetAge = int.Parse(p[1]);
                string PetColor = p[2];
                string PetImgS = p[3];

                Pet pet = new Pet(PetName, PetAge, PetColor, PetImgS);
                pets.Add(pet);
            }
            return pets;
        }

        public override string ToString()
        {
            return $"{Name}"; //| {Age} | {Color} {ImgS}";
        }
    }
}
