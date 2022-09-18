using System;

namespace Harboard_Back.Domain.Entities
{
    [Serializable]
    public class Conteiner
    {
        public int? id { get; set; }
        public string cliente { get; set; }
        public string numeroconteiner { get; set; }
        public string tipo { get; set; }
        public string status { get; set; }
        public string categoria { get; set; }

    }
}