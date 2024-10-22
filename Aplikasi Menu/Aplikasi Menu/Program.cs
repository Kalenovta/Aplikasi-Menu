using System;

namespace Menu_Pesanan
{
    class Program
    {

        // Daftar menu makanan dan minuman
        static string[] menuMakanan = { "Nasi Goreng", "Nasi Uduk", "Nasi Kucing", "Mie Rebus", "Mie Goreng", "Mie Ayam" };
        static int[] hargaMakanan = { 12000, 9000, 3000, 9000, 9000, 13000 };

        static string[] menuMinuman = { "Teh Botol", "Teh Pucuk", "Susu Jahe", "Kopi Jahe", "Kopi Susu", "Tea Jus" };
        static int[] hargaMinuman = { 5000, 4000, 6000, 3000, 5000, 0 };  // Tea Jus gratis (Rp. 0)

        static void Main(string[] args)
        {
            bool running = true;
            int totalHarga = 0;

            while (running)
            {
                Console.Clear();
                TampilkanMenu();
                Console.Write("\nMasukkan kode menu (misal 1a, 2b, 1c), atau ketik 'q' untuk keluar: ");
                string input = Console.ReadLine().ToLower();

                if (input == "q")
                {
                    running = false;
                    break;
                }

                // Split input berdasarkan koma (untuk memilih beberapa menu sekaligus)
                string[] kodeMenuList = input.Split(',');

                foreach (string kodeMenu in kodeMenuList)
                {
                    string trimmedKodeMenu = kodeMenu.Trim(); // Hapus spasi ekstra
                    if (trimmedKodeMenu.Length == 2)
                    {
                        char kategori = trimmedKodeMenu[0];
                        char pilihan = trimmedKodeMenu[1];

                        if (kategori == '1' && pilihan >= 'a' && pilihan <= 'f')
                        {
                            int indexMenu = pilihan - 'a';  // Menghitung index untuk menu makanan
                            totalHarga += HitungHargaMakanan(indexMenu);
                        }
                        else if (kategori == '2' && pilihan >= 'a' && pilihan <= 'f')
                        {
                            int indexMenu = pilihan - 'a';  // Menghitung index untuk menu minuman
                            totalHarga += HitungHargaMinuman(indexMenu);
                        }
                        else
                        {
                            Console.WriteLine($"Kode menu {trimmedKodeMenu} tidak valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Kode menu {trimmedKodeMenu} tidak valid.");
                    }
                }

                Console.WriteLine($"Total sementara: Rp. {totalHarga}");

                // Validasi apakah ingin melanjutkan atau tidak
                Console.Write("Apakah Ada lagi yang ingin anda pesan? (ketik 'y' untuk ya, 'n' untuk tidak): ");
                string lanjut = Console.ReadLine().ToLower();

                if (lanjut == "n")
                {
                    running = false;
                }
            }

            Console.WriteLine($"\nTotal harga yang harus dibayar: Rp. {totalHarga}");
        }

        // Fungsi untuk menampilkan menu
        // Fungsi untuk menampilkan menu makanan dan minuman berdampingan
        static void TampilkanMenu()
        {
            Console.WriteLine("+" + new string('-', 75) + "+");
            Console.WriteLine("|        MENU MAKANAN        |      MENU MINUMAN       |");
            Console.WriteLine("+" + new string('-', 75) + "+");

            int maxLength = Math.Max(menuMakanan.Length, menuMinuman.Length);

            for (int i = 0; i < maxLength; i++)
            {
                string makanan = i < menuMakanan.Length ? $"1{(char)('a' + i)}. {menuMakanan[i],-20} - Rp. {hargaMakanan[i],5}" : "";
                string minuman = i < menuMinuman.Length ? $"2{(char)('a' + i)}. {menuMinuman[i],-20} - Rp. {hargaMinuman[i],5}" : "";

                Console.WriteLine($"| {makanan,-36} | {minuman,-36} |");
            }

            Console.WriteLine("+" + new string('-', 75) + "+");
        }


        // Fungsi untuk menghitung harga makanan
        static int HitungHargaMakanan(int index)
        {
            if (index >= 0 && index < hargaMakanan.Length)
            {
                Console.Write($"Berapa banyak {menuMakanan[index]} yang dipesan: ");
                int jumlah = int.Parse(Console.ReadLine());
                return hargaMakanan[index] * jumlah;
            }
            return 0;
        }

        // Fungsi untuk menghitung harga minuman
        static int HitungHargaMinuman(int index)
        {
            if (index >= 0 && index < hargaMinuman.Length)
            {
                Console.Write($"Berapa banyak {menuMinuman[index]} yang dipesan: ");
                int jumlah = int.Parse(Console.ReadLine());
                return hargaMinuman[index] * jumlah;
            }
            return 0;
        }
    }
    

}