using System;
using System.Collections.Generic;

namespace FundamentalProgramming
{
    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
    class Program
    {
        public static List<Product> items = new List<Product>();

        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan!");
                Console.WriteLine(e.Message + "\n");

                BackToMenu();
            }
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.WriteLine("||============ SISTEM GUDANG TOKO XYZ ============||");
            Console.WriteLine("||================================================||");
            Console.WriteLine("||            1. Lihat data barang                ||");
            Console.WriteLine("||            2. Insert data barang               ||");
            Console.WriteLine("||            3. Hapus data barang                ||");
            Console.WriteLine("||            4. Lihat total harga barang         ||");
            Console.WriteLine("====================================================\n");
            Console.Write("Pilihan anda: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ShowItems();
                    break;
                case 2:
                    AddItem();
                    break;
                case 3:
                    DeleteItem();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=== TOTAL HARGA BARANG ===\n");

                    ShowList();
                    Console.Write("\nMasukkan no barang: ");
                    int no = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"\nHarga {items[no - 1].stock} {items[no - 1].name} adalah : Rp. {TotalValue(items[no - 1].price, items[no - 1].stock)} ");
                    BackToMenu();
                    break;
                default:
                    Menu();
                    break;
            }

        }

        public static void ShowItems()
        {
            Console.Clear();
            Console.WriteLine("=== DAFTAR BARANG DI GUDANG ===\n");

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].price}");
                }

                BackToMenu();
            }
            else
            {
                Console.WriteLine("\nBelum ada data barang!");
                BackToMenu();
            }
        }
        public static void ShowList()
        {
            Console.Clear();
            Console.WriteLine("=== DAFTAR BARANG DI GUDANG TOKO XYZ ===\n");

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].name} ({items[i].stock}) - Rp. {items[i].price}");
                }
            }
        }

        public static void AddItem()
        {
            Console.Clear();
            Console.WriteLine("=== TAMBAH DATA BARANG ===\n");

            Console.Write("Masukkan jumlah barang: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < num; i++)
            {
                Console.Write($"Nama barang ke-{i + 1}: ");
                string inputName = Console.ReadLine();
                Console.Write($"Harga satuan barang ke-{i + 1}: ");
                decimal inputPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write($"Stock barang ke-{i + 1}: ");
                int inputStock = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                //items.Add(Console.ReadLine());
                items.Add(new Product { name = inputName, price = inputPrice, stock = inputStock });
            }
            BackToMenu();
        }

        public static void DeleteItem()
        {
            Console.Clear();
            Console.WriteLine("=== HAPUS DATA BARANG ===\n");

            if (items.Count > 0)
            {
                Console.WriteLine("Penghapusan Barang\n");
                Console.WriteLine("1. Hapus salah satu");
                Console.WriteLine("2. Hapus semua data\n");
                Console.Write("Pilihan anda: ");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        ShowList();
                        Console.Write("\nHapus barang no. berapa? ");
                        int rmIndex = Convert.ToInt32(Console.ReadLine());

                        items.RemoveAt(rmIndex-1);

                        Console.Clear();
                        Console.Write($"Barang no. {rmIndex} sudah terhapus! \n");

                        BackToMenu();
                        break;

                    case 2:
                        items.Clear();
                        Console.WriteLine("Semua data terhapus!");
                        break;

                    default:
                        DeleteItem();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nBelum ada data barang!");
                BackToMenu();
            }
        }
        public static void BackToMenu()
        {
            Console.Write("\n======= Tekan sembarang tombol untuk kembali =======");
            Console.ReadKey(true);
            Menu();
        }

        public static decimal TotalValue(decimal price, int stock)
        {
            return stock * price;
        }

    }
}
