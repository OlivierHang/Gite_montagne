using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWPF
{
    public class Reservation
    {
        private int _id;
        private string _date;
        private int _duree;
        private string _client;

        public Reservation() { }

        public Reservation(int id, string date, int duree, string client)
        {
            Id = id;
            Date = date;
            Duree = duree;
            Client = client;
        }

        public int Id { get => _id; set => _id = value; }
        public string Date { get => _date; set => _date = value; }
        public int Duree { get => _duree; set => _duree = value; }
        public string Client { get => _client; set => _client = value; }
    }
}
