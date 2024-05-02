using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static Reservation[,] reservations;
    static void Main(string[] args)
    {
        string filePath = "Data.json";

        // JSON dosyasından odaları yükle
        string jsonString = File.ReadAllText(filePath);
        var roomData = JsonSerializer.Deserialize<RoomData>(
                                jsonString,
                                new JsonSerializerOptions()
                                {
                                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                                });

        // Menü döngüsü
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Rezervasyon Yap");
            Console.WriteLine("2. Rezervasyon İptal Et");
            Console.WriteLine("3. Bu Haftanın Rezervasyonlarını Göster");
            Console.WriteLine("4. Çıkış");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MakeReservation(roomData);
                    break;
                case "2":
                    CancelReservation();
                    break;
                case "3":
                    ShowWeeklyReservations(reservations);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }

    // Rezervasyon yap
    static void MakeReservation(RoomData roomData)
    {
        // RoomData nesnesi null ise uygun bir mesaj göster ve fonksiyondan çık
        if (roomData == null || roomData.Rooms == null || roomData.Rooms.Length == 0)
        {
            Console.WriteLine("Oda bilgileri bulunamadı veya eksik. Rezervasyon yapmak için önce odaları yükleyin.");
            return;
        }

        // reservations dizisini başlat
        if (reservations == null)
        {
            // varsayılan boyutlarla başlat, gerektiğinde boyutu artırabilirsiniz
            reservations = new Reservation[7, 24];
        }

        Console.WriteLine("Room ID girin:");
        string roomId = Console.ReadLine();

        Console.WriteLine("Rezervasyon tarihini girin (YYYY-MM-DD):");
        DateTime dateTime;
        if (!DateTime.TryParse(Console.ReadLine(), out dateTime))
        {
            Console.WriteLine("Geçersiz tarih formatı.");
            return;
        }

        Console.WriteLine("Rezervasyon yapan kişinin adını girin:");
        string reserverName = Console.ReadLine();

        Room selectedRoom = FindRoomById(roomData.Rooms, roomId);
        if (selectedRoom != null)
        {
            Reservation reservation = new Reservation
            {
                Room = selectedRoom,
                DateTime = dateTime,
                ReserverName = reserverName
            };

            // reservations dizisine rezervasyonu ekle
            // bu örnek kodda aynı zaman diliminde birden fazla rezervasyon yapılabileceği için uygun bir algoritma uygulanmalıdır
            // burada sadece ilk boş konuma ekleniyor
            for (int i = 0; i < reservations.GetLength(0); i++)
            {
                for (int j = 0; j < reservations.GetLength(1); j++)
                {
                    if (reservations[i, j] == null)
                    {
                        reservations[i, j] = reservation;
                        break;
                    }
                }
            }

            Console.WriteLine("Rezervasyon oluşturuldu:");
            Console.WriteLine($"Room ID: {reservation.Room.roomId}, Room Name: {reservation.Room.roomName}, Capacity: {reservation.Room.capacity}");
            Console.WriteLine($"Rezervasyon Tarihi: {reservation.DateTime}, Yapan Kişi: {reservation.ReserverName}");
        }
        else
        {
            Console.WriteLine("Geçersiz oda ID'si.");
        }
    }


    // Rezervasyon iptal et
    static void CancelReservation()
    {
        // Implementasyonu buraya ekleyin
    }

    // Bu haftalık rezervasyonları göster
    static void ShowWeeklyReservations(Reservation[,] reservations)
    {
        // Rezervasyonlar null ise uygun mesajı göster
        if (reservations == null)
        {
            Console.WriteLine("Rezervasyon bulunmamaktadır.");
            return;
        }

        // Rezervasyonlar varsa göster
        bool hasReservations = false;
        for (int i = 0; i < reservations.GetLength(0); i++)
        {
            for (int j = 0; j < reservations.GetLength(1); j++)
            {
                if (reservations[i, j] != null)
                {
                    hasReservations = true;
                    Console.WriteLine($"Oda: {reservations[i, j].Room.roomName}, Tarih: {reservations[i, j].DateTime}, İsim: {reservations[i, j].ReserverName}");
                }
            }
        }

        // Rezervasyon yoksa mesaj göster
        if (!hasReservations)
        {
            Console.WriteLine("Yapılan rezervasyon bulunmamaktadır.");
        }

        // Geri menüye dön
        Console.WriteLine("Menüye dönmek için bir tuşa basın...");
        Console.ReadLine();
    }


    // ID'ye göre oda bul
    static Room FindRoomById(Room[] rooms, string roomId)
    {
        foreach (var room in rooms)
        {
            if (room.roomId == roomId)
            {
                return room;
            }
        }
        return null;
    }
}


