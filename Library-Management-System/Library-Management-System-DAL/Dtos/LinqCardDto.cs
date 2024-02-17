using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_DAL.Dtos
{
    public class LinqCardDto
    {
        public int Deger1 { get; set; } // Kitap sayısı
        public int Deger2 { get; set; } // Üye sayısı
        public decimal Deger3 { get; set; } // Toplam ceza miktarı
        public int Deger4 { get; set; } // Durumu false olan kitap sayısı
        public int Deger5 { get; set; } // Kategori sayısı
        public string Deger8 { get; set; } // En çok kitabı olan yazar
        public string Deger9 { get; set; } // En çok kitabı yayınlayan yayınevi
        public int Deger11 { get; set; } // İletişim sayısı
    }
}
